using System.Linq;
using HarmonyLib;
using Verse;

namespace LiveWithThePain;

[HarmonyPatch(typeof(Pawn_HealthTracker), nameof(Pawn_HealthTracker.HealthTickInterval))]
public static class Pawn_HealthTracker_HealthTickInterval
{
    private const int RefreshIntervalTicks = 60;

    public static void Postfix(Pawn_HealthTracker __instance, int delta)
    {
        if (__instance?.hediffSet?.pawn == null)
        {
            return;
        }

        var pawn = __instance.hediffSet.pawn;
        if (!pawn.IsHashIntervalTick(RefreshIntervalTicks, delta))
        {
            return;
        }

        if (!__instance.hediffSet.GetHediffComps<HediffComp_GetsPermanent>().Any(comp => comp.IsPermanent))
        {
            return;
        }

        __instance.hediffSet.DirtyPainCache();
        __instance.CheckForStateChange(null, null);
        pawn.needs?.mood?.thoughts?.situational.Notify_SituationalThoughtsDirty();
    }
}