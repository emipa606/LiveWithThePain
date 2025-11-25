using System.Reflection;
using HarmonyLib;
using Verse;

namespace LiveWithThePain;

[StaticConstructorOnStartup]
public static class LiveWithThePain
{
    static LiveWithThePain()
    {
        new Harmony("Mlie.LiveWithThePain").PatchAll(Assembly.GetExecutingAssembly());
    }

    public static void LogMessages(string message)
    {
        if (!LiveWithThePainMod.Instance.Settings.VerboseLogging)
        {
            return;
        }

        Log.Message($"[LiveWithThePain]: {message}");
    }
}