using System;
using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace LiveWithThePain
{
    [StaticConstructorOnStartup]
    internal class LiveWithThePainMod : Mod
    {
        private static string currentVersion;

        public static LiveWithThePainMod Instance;

        /// <summary>
        ///     The private settings
        /// </summary>
        public LiveWithThePainSettings settings;


        /// <summary>
        ///     Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public LiveWithThePainMod(ModContentPack content) : base(content)
        {
            Instance = this;
            currentVersion =
                VersionFromManifest.GetVersionFromModMetaData(
                    ModLister.GetActiveModWithIdentifier("Mlie.LiveWithThePain"));
        }

        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        public LiveWithThePainSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<LiveWithThePainSettings>();
                }

                return settings;
            }
            set => settings = value;
        }

        /// <summary>
        ///     The title for the mod-settings
        /// </summary>
        /// <returns></returns>
        public override string SettingsCategory()
        {
            return "Live With The Pain";
        }

        /// <summary>
        ///     The settings-window
        ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.Gap();
            var spacer = 30;
            listing_Standard.Gap();
            Settings.StageOne = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(spacer), Settings.StageOne, 0,
                Settings.StageTwo, false,
                $"{"LWTP.StageOne".Translate()}: {"LWTP.Days".Translate(Settings.StageOne / GenDate.TicksPerDay)}",
                null, null, 1);
            Settings.StageTwo = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(spacer), Settings.StageTwo,
                Settings.StageOne,
                Settings.StageThree, false,
                $"{"LWTP.StageTwo".Translate()}: {"LWTP.Days".Translate(Settings.StageTwo / GenDate.TicksPerDay)}",
                null, null,
                1);
            Settings.StageThree = (int)Widgets.HorizontalSlider(listing_Standard.GetRect(spacer), Settings.StageThree,
                Settings.StageTwo,
                GenDate.TicksPerYear * 2,
                false,
                $"{"LWTP.StageThree".Translate()}: {"LWTP.Days".Translate(Settings.StageThree / GenDate.TicksPerDay)}",
                null, null, 1);

            listing_Standard.Gap();
            Settings.PainOne = Widgets.HorizontalSlider(listing_Standard.GetRect(spacer), Settings.PainOne,
                1f,
                Settings.PainTwo + 0.001f, false,
                $"{"LWTP.PainOne".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainOne * 100))}");
            Settings.PainTwo = Widgets.HorizontalSlider(listing_Standard.GetRect(spacer),
                Settings.PainTwo,
                Settings.PainOne - 0.001f,
                Settings.PainThree + 0.001f, false,
                $"{"LWTP.PainTwo".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainTwo * 100))}");
            Settings.PainThree = Widgets.HorizontalSlider(listing_Standard.GetRect(spacer), Settings.PainThree,
                Settings.PainTwo - 0.001f, 0,
                false,
                $"{"LWTP.PainThree".Translate()}: {"LWTP.Percent".Translate(Math.Round(Settings.PainThree * 100))}");

            listing_Standard.Gap();


            if (listing_Standard.ButtonText("LWTP.Reset".Translate()))
            {
                Settings.StageThree = GenDate.TicksPerYear;
                Settings.StageTwo = GenDate.TicksPerQuadrum;
                Settings.StageOne = GenDate.TicksPerTwelfth;
                Settings.PainOne = 0.75f;
                Settings.PainTwo = 0.5f;
                Settings.PainThree = 0.25f;
                listing_Standard.Gap();
            }

            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("LWTP.RainAches.Label".Translate(), ref Settings.RainAches,
                "LWTP.RainAches.ToolTip".Translate());
            listing_Standard.CheckboxLabeled("LWTP.TempAches.Label".Translate(), ref Settings.TempAches,
                "LWTP.TempAches.ToolTip".Translate());
            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("LWTP.VerboseLogging.Label".Translate(), ref Settings.VerboseLogging,
                "LWTP.VerboseLogging.ToolTip".Translate());

            if (currentVersion != null)
            {
                GUI.contentColor = Color.gray;
                listing_Standard.Label("LWTP.version.label".Translate(currentVersion));
                GUI.contentColor = Color.white;
            }

            listing_Standard.End();
        }
    }
}