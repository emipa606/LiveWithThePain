using System.Reflection;
using HarmonyLib;
using Verse;

namespace LiveWithThePain
{
    [StaticConstructorOnStartup]
    public static class LiveWithThePain
    {
        static LiveWithThePain()
        {
            var harmony = new Harmony("Mlie.LiveWithThePain");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}