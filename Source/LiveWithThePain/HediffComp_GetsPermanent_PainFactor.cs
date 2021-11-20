using HarmonyLib;
using RimWorld;
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

            switch (__instance.parent.ageTicks)
            {
                case < GenDate.TicksPerTwelfth:
                    //Log.Message($"Returning default pain ({__result}) for {__instance.parent.pawn.NameShortColored} at age {__instance.parent.ageTicks}");
                    return;
                case < GenDate.TicksPerQuadrum:
                    __result *= 0.75f;
                    //Log.Message($"Returning 75% pain ({__result}) for {__instance.parent.pawn.NameShortColored} at age {__instance.parent.ageTicks}");
                    return;
                case < GenDate.TicksPerYear:
                    __result *= 0.5f;
                    //Log.Message($"Returning 50% pain ({__result}) for {__instance.parent.pawn.NameShortColored} at age {__instance.parent.ageTicks}");
                    return;
                default:
                    __result *= 0.25f;
                    //Log.Message($"Returning 25% pain ({__result}) for {__instance.parent.pawn.NameShortColored} at age {__instance.parent.ageTicks}");
                    break;
            }
        }
    }
}