using System;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace LiveWithThePain;

[StaticConstructorOnStartup]
internal class LiveWithThePainMod : Mod
{
    private static string currentVersion;

    public static LiveWithThePainMod Instance;

    /// <summary>
    ///     The private settings
    /// </summary>
    public readonly LiveWithThePainSettings Settings;


    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public LiveWithThePainMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<LiveWithThePainSettings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();
        const int spacer = 30;
        listingStandard.Gap();
        Settings.StageOne = (int)Widgets.HorizontalSlider(listingStandard.GetRect(spacer), Settings.StageOne, 0,
            Settings.StageTwo, false,
            $"{"LWTP.StageOne".Translate()}: {"LWTP.Days".Translate(Settings.StageOne / GenDate.TicksPerDay)}",
            null, null, 1);
        Settings.StageTwo = (int)Widgets.HorizontalSlider(listingStandard.GetRect(spacer), Settings.StageTwo,
            Settings.StageOne,
            Settings.StageThree, false,
            $"{"LWTP.StageTwo".Translate()}: {"LWTP.Days".Translate(Settings.StageTwo / GenDate.TicksPerDay)}",
            null, null,
            1);
        Settings.StageThree = (int)Widgets.HorizontalSlider(listingStandard.GetRect(spacer), Settings.StageThree,
            Settings.StageTwo,
            GenDate.TicksPerYear * 2,
            false,
            $"{"LWTP.StageThree".Translate()}: {"LWTP.Days".Translate(Settings.StageThree / GenDate.TicksPerDay)}",
            null, null, 1);

        listingStandard.Gap();
        Settings.PainOne = Widgets.HorizontalSlider(listingStandard.GetRect(spacer), Settings.PainOne,
            0, 2f, false,
            $"{"LWTP.PainOne".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainOne * 100))}");
        Settings.PainTwo = Widgets.HorizontalSlider(listingStandard.GetRect(spacer),
            Settings.PainTwo,
            0, 2f, false,
            $"{"LWTP.PainTwo".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainTwo * 100))}");
        Settings.PainThree = Widgets.HorizontalSlider(listingStandard.GetRect(spacer), Settings.PainThree,
            0, 2f, false,
            $"{"LWTP.PainThree".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainThree * 100))}");

        listingStandard.Gap();


        if (listingStandard.ButtonText("LWTP.Reset".Translate()))
        {
            Settings.StageThree = GenDate.TicksPerYear;
            Settings.StageTwo = GenDate.TicksPerQuadrum;
            Settings.StageOne = GenDate.TicksPerTwelfth;
            Settings.PainOne = 0.75f;
            Settings.PainTwo = 0.5f;
            Settings.PainThree = 0.25f;
            listingStandard.Gap();
        }

        listingStandard.Gap();
        listingStandard.CheckboxLabeled("LWTP.RainAches.Label".Translate(), ref Settings.RainAches,
            "LWTP.RainAches.ToolTip".Translate());
        listingStandard.CheckboxLabeled("LWTP.TempAches.Label".Translate(), ref Settings.TempAches,
            "LWTP.TempAches.ToolTip".Translate());
        listingStandard.CheckboxLabeled("LWTP.MorningAches.Label".Translate(), ref Settings.MorningAches,
            "LWTP.MorningAches.ToolTip".Translate());
        listingStandard.CheckboxLabeled("LWTP.OnlyColonists.Label".Translate(), ref Settings.OnlyColonists,
            "LWTP.OnlyColonists.ToolTip".Translate());
        listingStandard.Gap();
        listingStandard.CheckboxLabeled("LWTP.VerboseLogging.Label".Translate(), ref Settings.VerboseLogging,
            "LWTP.VerboseLogging.ToolTip".Translate());

        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listingStandard.Label("LWTP.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }


    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Live With The Pain";
    }
}