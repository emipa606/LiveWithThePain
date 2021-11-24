using RimWorld;
using Verse;

namespace LiveWithThePain;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class LiveWithThePainSettings : ModSettings
{
    public bool MorningAches;
    public float PainOne = 0.75f;
    public float PainThree = 0.25f;
    public float PainTwo = 0.5f;
    public bool RainAches;
    public int StageOne = GenDate.TicksPerTwelfth;
    public int StageThree = GenDate.TicksPerYear;
    public int StageTwo = GenDate.TicksPerQuadrum;
    public bool TempAches;
    public bool VerboseLogging;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref StageOne, "StageOne", GenDate.TicksPerTwelfth);
        Scribe_Values.Look(ref StageTwo, "StageTwo", GenDate.TicksPerQuadrum);
        Scribe_Values.Look(ref StageThree, "StageThree", GenDate.TicksPerYear);
        Scribe_Values.Look(ref PainOne, "PainOne", 0.75f);
        Scribe_Values.Look(ref PainTwo, "PainTwo", 0.5f);
        Scribe_Values.Look(ref PainThree, "PainThree", 0.25f);
        Scribe_Values.Look(ref RainAches, "RainAches");
        Scribe_Values.Look(ref TempAches, "TempAches");
        Scribe_Values.Look(ref MorningAches, "MorningAches");
        Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
    }
}