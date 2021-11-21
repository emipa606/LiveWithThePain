using HarmonyLib;
using Verse;

namespace LiveWithThePain
{
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
                $"Painmodifier from time for {__instance.parent.pawn.NameFullColored} set to {modifier}");
            __result *= modifier;

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
}