using HarmonyLib;
using RimWorld;
using Verse;

namespace LiveWithThePain;

[HarmonyPatch(typeof(HediffComp_GetsPermanent), "PainFactor", MethodType.Getter)]
public class HediffComp_GetsPermanent_PainFactor
{
    [HarmonyPostfix]
    public static void Postfix(HediffComp_GetsPermanent __instance, ref float __result)
    {
        if (__result <= 0 || __instance.parent.ageTicks <= 0)
        {
            return;
        }

        var modifier = 1f;

        if (__instance.parent.ageTicks > LiveWithThePainMod.Instance.Settings.StageOne)
        {
            modifier = LiveWithThePainMod.Instance.Settings.PainOne;
        }

        if (__instance.parent.ageTicks > LiveWithThePainMod.Instance.Settings.StageTwo)
        {
            modifier = LiveWithThePainMod.Instance.Settings.PainTwo;
        }

        if (__instance.parent.ageTicks > LiveWithThePainMod.Instance.Settings.StageThree)
        {
            modifier = LiveWithThePainMod.Instance.Settings.PainThree;
        }

        LiveWithThePain.LogMessages(
            $"Painmodifier from wound age for {__instance.parent.pawn.NameFullColored} set to {modifier}");
        __result *= modifier;

        if (LiveWithThePainMod.Instance.Settings.MorningAches)
        {
            var restNeed = __instance.parent?.pawn?.needs?.TryGetNeed(NeedDefOf.Rest);
            if (restNeed is { CurLevelPercentage: > 0.8f } && __instance.parent?.pawn?.jobs?.curDriver?.asleep == false)
            {
                var awakeModifier = 1 + ((restNeed.CurLevelPercentage - 0.8f) / 0.2f);
                LiveWithThePain.LogMessages(
                    $"Pawn is recently awoken, will add modifier of {awakeModifier} for {__instance.parent.pawn.NameFullColored}");
                __result *= awakeModifier;
            }
        }

        if (__instance.parent.pawn.Map == null)
        {
            LiveWithThePain.LogMessages(
                $"Pawn is not currently on a map, will not check for temp/rain. Returning painvalue of {__result} for {__instance.parent.pawn.NameFullColored}");
            return;
        }

        if (LiveWithThePainMod.Instance.Settings.RainAches &&
            __instance.parent.pawn.Map.weatherManager.RainRate > 0)
        {
            __result *= 2f;
            LiveWithThePain.LogMessages(
                $"Pain doubled from rain/snow for {__instance.parent.pawn.NameFullColored}");
        }

        if (LiveWithThePainMod.Instance.Settings.TempAches &&
            __instance.parent.pawn.Map.mapTemperature.OutdoorTemp <
            __instance.parent.pawn.Map.mapTemperature.SeasonalTemp - 10f)
        {
            __result *= 2f;
            LiveWithThePain.LogMessages(
                $"Pain doubled from cold temperature for {__instance.parent.pawn.NameFullColored}");
        }

        LiveWithThePain.LogMessages(
            $"Returning painvalue of {__result} for {__instance.parent.pawn.NameFullColored}");
    }
}