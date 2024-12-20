using GH_Toolkit_Core.INI;
using IniParser.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.RegularExpressions;
using static GH_Toolkit_Core.QB.QBConstants;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GH_Toolkit_GUI
{
    public partial class CompileSong
    {
        public class SaveData
        {
            public int GhprojVersion = 1;
            [DefaultValue("")]
            public string gameSelect { get; set; } = "";
            [DefaultValue("")]
            public string platformSelect { get; set; } = "";
            [DefaultValue("")]
            public string songName { get; set; } = "";
            [DefaultValue("")]
            public string chartAuthor { get; set; } = "";
            [DefaultValue("")]
            public string title { get; set; } = "";
            [DefaultValue("")]
            public string artist { get; set; } = "";
            [DefaultValue("")]
            public string artistTextCustom { get; set; } = "";
            [DefaultValue("")]
            public string coverArtist { get; set; } = "";
            [DefaultValue("")]
            public string kickPath { get; set; } = "";
            [DefaultValue("")]
            public string snarePath { get; set; } = "";
            [DefaultValue("")]
            public string cymbalsPath { get; set; } = "";
            [DefaultValue("")]
            public string tomsPath { get; set; } = "";
            [DefaultValue("")]
            public string guitarPath { get; set; } = "";
            [DefaultValue("")]
            public string bassPath { get; set; } = "";
            [DefaultValue("")]
            public string vocalsPath { get; set; } = "";
            [DefaultValue("")]
            public string backingPaths { get; set; } = "";
            [DefaultValue("")]
            public string crowdPath { get; set; } = "";
            [DefaultValue("")]
            public string previewAudioPath { get; set; } = "";
            [DefaultValue("")]
            public string guitarPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string rhythmPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string backingPathsGh3 { get; set; } = "";
            [DefaultValue("")]
            public string coopGuitarPath { get; set; } = "";
            [DefaultValue("")]
            public string coopRhythmPath { get; set; } = "";
            [DefaultValue("")]
            public string coopBackingPaths { get; set; } = "";
            [DefaultValue("")]
            public string crowdPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string previewAudioPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string midiPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string perfPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string skaPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string songScriptPathGh3 { get; set; } = "";
            [DefaultValue("")]
            public string midiPath { get; set; } = "";
            [DefaultValue("")]
            public string perfPath { get; set; } = "";
            [DefaultValue("")]
            public string skaPath { get; set; } = "";
            [DefaultValue("")]
            public string lipsyncPath { get; set; } = "";
            [DefaultValue("")]
            public string songScriptPath { get; set; } = "";
            [DefaultValue("")]
            public string compilePath { get; set; } = "";
            [DefaultValue("")]
            public string projectPath { get; set; } = "";
            [DefaultValue("")]
            public string gameIcon { get; set; } = "";
            [DefaultValue("")]
            public string gameCategory { get; set; } = "";
            [DefaultValue("")]
            public string bandWtde { get; set; } = "";
            [DefaultValue("Default")]
            public string gSkeleton { get; set; } = "";
            [DefaultValue("Default")]
            public string bSkeleton { get; set; } = "";
            [DefaultValue("Default")]
            public string dSkeleton { get; set; } = "";
            [DefaultValue("Default")]
            public string vSkeleton { get; set; } = "";
            [DefaultValue("Modern Rock")]
            public string ghwtDrumkit { get; set; } = "Modern Rock";
            [DefaultValue("Modern Rock")]
            public string gh5Drumkit { get; set; } = "Modern Rock";
            [DefaultValue("Modern Rock")]
            public string ghworDrumkit { get; set; } = "Modern Rock";
            [DefaultValue(-1)]
            public int artistText { get; set; } = 0;
            public int songYear { get; set; } = 2024;
            public int coverYear { get; set; } = 2024;
            [DefaultValue(-1)]
            public int wtGenre { get; set; } = 0;
            [DefaultValue(-1)]
            public int gh5Genre { get; set; } = 0;
            [DefaultValue(-1)]
            public int worGenre { get; set; } = 0;
            [DefaultValue(30000)]
            public int previewStart { get; set; }
            [DefaultValue(30000)]
            public int previewEnd { get; set; }
            [DefaultValue(170)]
            public int hmxHopoVal { get; set; } = 170;
            public int skaSourceGh3 { get; set; } = 0;
            public int venueSourceGh3 { get; set; } = 0;
            public int countoffGh3 { get; set; } = 0;
            public int vocalGenderGh3 { get; set; } = 0;
            public int bassistSelect { get; set; } = 0;
            public int skaSource { get; set; } = 0;
            public int venueSource { get; set; } = 0;
            public int countoff { get; set; } = 0;
            public int vocalGender { get; set; } = 0;
            public int hopoMode { get; set; } = 0;
            [DefaultValue(1)]
            public int beat8thLow { get; set; } = 1;
            [DefaultValue(150)]
            public int beat8thHigh { get; set; } = 150;
            [DefaultValue(1)]
            public int beat16thLow { get; set; } = 1;
            [DefaultValue(120)]
            public int beat16thHigh { get; set; } = 120;
            [DefaultValue(1)]
            public int bandTier { get; set; } = 1;
            [DefaultValue(1)]
            public int guitarTier { get; set; } = 1;
            [DefaultValue(1)]
            public int bassTier { get; set; } = 1;
            [DefaultValue(1)]
            public int drumsTier { get; set; } = 1;
            [DefaultValue(1)]
            public int vocalsTier { get; set; } = 1;
            public decimal gtrVolumeGh3 { get; set; } = 0;
            public decimal bandVolumeGh3 { get; set; } = 0;
            [DefaultValue(1)]
            public decimal vocalScrollSpeed { get; set; } = 1;
            public decimal vocalTuningCents { get; set; } = 0;
            [DefaultValue(0.5)]
            public decimal sustainThreshold { get; set; }
            public decimal overallVolume { get; set; } = 0;
            [DefaultValue(-7.0)]
            public decimal previewVolume { get; set; } = -7m;
            [DefaultValue(-7.0)]
            public decimal previewVolumeGh3 { get; set; } = -7m;
            public bool isCover { get; set; } = false;
            public bool isP2Rhythm { get; set; } = false;
            public bool isCoopAudio { get; set; } = false;
            public bool useRenderedPreview { get; set; } = false;
            public bool useRenderedPreviewGh3 { get; set; } = false;
            public bool setEnd { get; set; } = false;
            public bool useBeatTrack { get; set; } = false;
            public bool guitarMic { get; set; } = false;
            public bool bassMic { get; set; } = false;
            public bool useNewClips { get; set; } = false;
            public bool modernStrobes { get; set; } = false;
            public bool easyOpen { get; set; } = false;
        }
        private class SaveDataOld
        {
            public string game { get; set; }
            public string title_input { get; set; }
            public string artist_text_select { get; set; }
            public string artist_text_other { get; set; }
            public string artist_input { get; set; }
            public int year_input { get; set; }
            public string cover_checkbox { get; set; }
            public int cover_year_input { get; set; }
            public string cover_artist_input { get; set; }
            public string genre_select { get; set; }
            public string checksum_input { get; set; }
            public string author_input { get; set; }
            public string ghwt_genre { get; set; }
            public string ghwor_genre { get; set; }
            public string kick_input { get; set; }
            public string snare_input { get; set; }
            public string cymbals_input { get; set; }
            public string toms_input { get; set; }
            public string guitar_input { get; set; }
            public string bass_input { get; set; }
            public string vocals_input { get; set; }
            public string backing_input { get; set; }
            public string crowd_input { get; set; }
            public int preview_minutes { get; set; }
            public int preview_seconds { get; set; }
            public int preview_mills { get; set; }
            public bool ghwt_set_end { get; set; }
            public int length_minutes { get; set; }
            public int length_seconds { get; set; }
            public int length_mills { get; set; }
            // Continue later

        }
        private string GetRelativePath(string filePath)
        {
            if (filePath == null || filePath == string.Empty)
            {
                return string.Empty;
            }
            // Get the directory of the project file
            string projectDir = Path.GetDirectoryName(projectFilePath);

            // Check if the file path is relative and make it absolute if needed
            if (!Path.IsPathRooted(filePath))
            {
                filePath = Path.Combine(projectDir, filePath);
            }

            filePath = Path.GetFullPath(filePath);

            // Convert the absolute file path to a Uri
            Uri fileUri = new Uri(filePath);
            Uri projectUri = new Uri(projectDir + Path.DirectorySeparatorChar); // Ensure it's treated as a directory

            // Get the relative Uri
            Uri relativeUri = projectUri.MakeRelativeUri(fileUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString().Replace('/', Path.DirectorySeparatorChar));

            // Split the relative path into directories
            string[] relativeParts = relativePath.Split(Path.DirectorySeparatorChar);

            // Count the number of ".." in the path to see how many levels it goes up
            int upDirectoryCount = relativeParts.Count(part => part == "..");

            // If it goes up more than one directory, return the full path, otherwise return the relative path
            return upDirectoryCount <= 1 ? relativePath : filePath;
        }

        private string GetAbsolutePath(string filePath)
        {
            if (filePath == null || filePath == string.Empty)
            {
                return string.Empty;
            }

            // Get the directory of the project file
            string projectDir = Path.GetDirectoryName(projectFilePath);

            // Check if the file path is relative and make it absolute if needed
            if (!Path.IsPathRooted(filePath))
            {
                filePath = Path.Combine(projectDir, filePath);
            }

            return Path.GetFullPath(filePath);
        }
        private void SetAllToAbsolute()
        {
            if (projectFilePath == null || projectFilePath == string.Empty)
            {
                return;
            }
            // GHWT
            kickInput.Text = GetAbsolutePath(kickInput.Text);
            snareInput.Text = GetAbsolutePath(snareInput.Text);
            cymbalsInput.Text = GetAbsolutePath(cymbalsInput.Text);
            tomsInput.Text = GetAbsolutePath(tomsInput.Text);
            guitarInput.Text = GetAbsolutePath(guitarInput.Text);
            bassInput.Text = GetAbsolutePath(bassInput.Text);
            vocalsInput.Text = GetAbsolutePath(vocalsInput.Text);
            for (int i = 0; i < backingInput.Items.Count; i++)
            {
                backingInput.Items[i] = GetAbsolutePath(backingInput.Items[i].ToString());
            }
            crowdInput.Text = GetAbsolutePath(crowdInput.Text);
            previewInput.Text = GetAbsolutePath(previewInput.Text);


            // MIDI
            midiFileInput.Text = GetAbsolutePath(midiFileInput.Text);
            perfOverrideInput.Text = GetAbsolutePath(perfOverrideInput.Text);
            skaFilesInput.Text = GetAbsolutePath(skaFilesInput.Text);
            songScriptInput.Text = GetAbsolutePath(songScriptInput.Text);
            gh3SkaFilesInput.Text = GetAbsolutePath(gh3SkaFilesInput.Text);

            // GH3
            guitar_input_gh3.Text = GetAbsolutePath(guitar_input_gh3.Text);
            rhythm_input_gh3.Text = GetAbsolutePath(rhythm_input_gh3.Text);
            for (int i = 0; i < backing_input_gh3.Items.Count; i++)
            {
                backing_input_gh3.Items[i] = GetAbsolutePath(backing_input_gh3.Items[i].ToString());
            }
            coop_guitar_input_gh3.Text = GetAbsolutePath(coop_guitar_input_gh3.Text);
            coop_rhythm_input_gh3.Text = GetAbsolutePath(coop_rhythm_input_gh3.Text);
            for (int i = 0; i < coop_backing_input_gh3.Items.Count; i++)
            {
                coop_backing_input_gh3.Items[i] = GetAbsolutePath(coop_backing_input_gh3.Items[i].ToString());
            }
            crowd_input_gh3.Text = GetAbsolutePath(crowd_input_gh3.Text);
            preview_audio_input_gh3.Text = GetAbsolutePath(preview_audio_input_gh3.Text);
            midi_file_input_gh3.Text = GetAbsolutePath(midi_file_input_gh3.Text);
            perf_override_input_gh3.Text = GetAbsolutePath(perf_override_input_gh3.Text);
            ska_files_input_gh3.Text = GetAbsolutePath(ska_files_input_gh3.Text);
            song_script_input_gh3.Text = GetAbsolutePath(song_script_input_gh3.Text);
        }

        private void SetAllToRelative()
        {
            if (projectFilePath == null || projectFilePath == string.Empty)
            {
                return;
            }
            // GHWT
            kickInput.Text = GetRelativePath(kickInput.Text);
            snareInput.Text = GetRelativePath(snareInput.Text);
            cymbalsInput.Text = GetRelativePath(cymbalsInput.Text);
            tomsInput.Text = GetRelativePath(tomsInput.Text);
            guitarInput.Text = GetRelativePath(guitarInput.Text);
            bassInput.Text = GetRelativePath(bassInput.Text);
            vocalsInput.Text = GetRelativePath(vocalsInput.Text);
            for (int i = 0; i < backingInput.Items.Count; i++)
            {
                backingInput.Items[i] = GetRelativePath(backingInput.Items[i].ToString());
            }
            crowdInput.Text = GetRelativePath(crowdInput.Text);
            previewInput.Text = GetRelativePath(previewInput.Text);

            // MIDI
            midiFileInput.Text = GetRelativePath(midiFileInput.Text);
            perfOverrideInput.Text = GetRelativePath(perfOverrideInput.Text);
            skaFilesInput.Text = GetRelativePath(skaFilesInput.Text);
            songScriptInput.Text = GetRelativePath(songScriptInput.Text);
            gh3SkaFilesInput.Text = GetRelativePath(gh3SkaFilesInput.Text);

            // GH3
            guitar_input_gh3.Text = GetRelativePath(guitar_input_gh3.Text);
            rhythm_input_gh3.Text = GetRelativePath(rhythm_input_gh3.Text);
            for (int i = 0; i < backing_input_gh3.Items.Count; i++)
            {
                backing_input_gh3.Items[i] = GetRelativePath(backing_input_gh3.Items[i].ToString());
            }
            coop_guitar_input_gh3.Text = GetRelativePath(coop_guitar_input_gh3.Text);
            coop_rhythm_input_gh3.Text = GetRelativePath(coop_rhythm_input_gh3.Text);
            for (int i = 0; i < coop_backing_input_gh3.Items.Count; i++)
            {
                coop_backing_input_gh3.Items[i] = GetRelativePath(coop_backing_input_gh3.Items[i].ToString());
            }
            crowd_input_gh3.Text = GetRelativePath(crowd_input_gh3.Text);
            preview_audio_input_gh3.Text = GetRelativePath(preview_audio_input_gh3.Text);
            midi_file_input_gh3.Text = GetRelativePath(midi_file_input_gh3.Text);
            perf_override_input_gh3.Text = GetRelativePath(perf_override_input_gh3.Text);
            ska_files_input_gh3.Text = GetRelativePath(ska_files_input_gh3.Text);
            song_script_input_gh3.Text = GetRelativePath(song_script_input_gh3.Text);
        }

        private SaveData makeSaveClass()
        {
            var data = new SaveData
            {
                // Metadata
                gameSelect = GetGame(),
                platformSelect = GetPlatform(),
                songName = song_checksum.Text,
                chartAuthor = chart_author_input.Text,
                title = title_input.Text,
                artist = artist_input.Text,
                artistTextCustom = artistTextCustom.Text,
                coverArtist = cover_artist_input.Text,

                // GHWT
                // Audio
                kickPath = GetRelativePath(kickInput.Text),
                snarePath = GetRelativePath(snareInput.Text),
                cymbalsPath = GetRelativePath(cymbalsInput.Text),
                tomsPath = GetRelativePath(tomsInput.Text),
                guitarPath = GetRelativePath(guitarInput.Text),
                bassPath = GetRelativePath(bassInput.Text),
                vocalsPath = GetRelativePath(vocalsInput.Text),
                backingPaths = string.Join(";", backingInput.Items.Cast<string>().Select(GetRelativePath).ToArray()),
                crowdPath = GetRelativePath(crowdInput.Text),
                previewAudioPath = GetRelativePath(previewInput.Text),
                previewVolume = previewVolume.Value,
                useRenderedPreview = renderedPreviewCheck.Checked,
                // Song Data
                midiPath = GetRelativePath(midiFileInput.Text),
                easyOpen = easyOpenCheckbox.Checked,
                perfPath = GetRelativePath(perfOverrideInput.Text),
                skaPath = GetRelativePath(skaFilesInput.Text),
                lipsyncPath = GetRelativePath(gh3SkaFilesInput.Text),
                songScriptPath = GetRelativePath(songScriptInput.Text),
                skaSource = skaFileSource.SelectedIndex,
                venueSource = venueSource.SelectedIndex,
                countoff = countoffSelect.SelectedIndex,
                ghwtDrumkit = gameDrumKits["GHWT"],
                gh5Drumkit = gameDrumKits["GH5"],
                ghworDrumkit = gameDrumKits["GHWoR"],
                vocalGender = vocalGenderSelect.SelectedIndex,
                vocalScrollSpeed = vocalScrollSpeed.Value,
                vocalTuningCents = vocalTuningCents.Value,
                sustainThreshold = sustainThreshold.Value,
                overallVolume = overallVolume.Value,
                guitarMic = guitarMicCheck.Checked,
                bassMic = bassMicCheck.Checked,
                // WTDE Settings
                gameIcon = gameIconInput.Text,
                gameCategory = gameCategoryInput.Text,
                bandWtde = bandInput.Text,
                gSkeleton = gSkeletonSelect.Text,
                bSkeleton = bSkeletonSelect.Text,
                dSkeleton = dSkeletonSelect.Text,
                vSkeleton = vSkeletonSelect.Text,
                useNewClips = useNewClipsCheck.Checked,
                modernStrobes = modernStrobesCheck.Checked,

                // WoR Tiers
                bandTier = (int)bandTierValue.Value,
                guitarTier = (int)guitarTierValue.Value,
                bassTier = (int)bassTierValue.Value,
                drumsTier = (int)drumsTierValue.Value,
                vocalsTier = (int)vocalsTierValue.Value,

                // GH3
                // Audio
                guitarPathGh3 = GetRelativePath(guitar_input_gh3.Text),
                rhythmPathGh3 = GetRelativePath(rhythm_input_gh3.Text),
                backingPathsGh3 = string.Join(";", backing_input_gh3.Items.Cast<string>().Select(GetRelativePath).ToArray()),
                coopGuitarPath = GetRelativePath(coop_guitar_input_gh3.Text),
                coopRhythmPath = GetRelativePath(coop_rhythm_input_gh3.Text),
                coopBackingPaths = string.Join(";", coop_backing_input_gh3.Items.Cast<string>().Select(GetRelativePath).ToArray()),
                crowdPathGh3 = GetRelativePath(crowd_input_gh3.Text),
                previewAudioPathGh3 = GetRelativePath(preview_audio_input_gh3.Text),
                gtrVolumeGh3 = gh3_gtr_vol.Value,
                bandVolumeGh3 = gh3_band_vol.Value,
                previewVolumeGh3 = previewVolumeGh3.Value,
                // Song Data
                midiPathGh3 = midi_file_input_gh3.Text,
                perfPathGh3 = perf_override_input_gh3.Text,
                skaPathGh3 = ska_files_input_gh3.Text,
                songScriptPathGh3 = song_script_input_gh3.Text,
                skaSourceGh3 = ska_file_source_gh3.SelectedIndex,
                venueSourceGh3 = venue_source_gh3.SelectedIndex,
                countoffGh3 = countoff_select_gh3.SelectedIndex,
                vocalGenderGh3 = vocal_gender_select_gh3.SelectedIndex,
                bassistSelect = bassist_select_gh3.SelectedIndex,
                isP2Rhythm = p2_rhythm_check.Checked,
                isCoopAudio = coop_audio_check.Checked,
                useRenderedPreviewGh3 = gh3_rendered_preview_check.Checked,
                setEnd = gh3_set_end.Checked,
                // Other
                compilePath = compile_input.Text,
                projectPath = project_input.Text,
                // Metadata
                artistText = artist_text_select.SelectedIndex,
                songYear = (int)year_input.Value,
                coverYear = (int)cover_year_input.Value,
                wtGenre = gameSelectedGenres["GHWT"],
                gh5Genre = gameSelectedGenres["GH5"],
                worGenre = gameSelectedGenres["GHWoR"],
                previewStart = previewStartTime,
                previewEnd = previewEndTime,
                hmxHopoVal = (int)HmxHopoVal.Value,
                hopoMode = hopo_mode_select.SelectedIndex,
                beat8thLow = (int)beat8thLow.Value,
                beat8thHigh = (int)beat8thHigh.Value,
                beat16thLow = (int)beat16thLow.Value,
                beat16thHigh = (int)beat16thHigh.Value,
                isCover = isCover.Checked,
                useBeatTrack = use_beat_check.Checked
            };
            return data;
        }
        private void LoadSaveData(SaveData data)
        {
            isProgrammaticChange = true;
            ClearListBoxes();
            // Metadata
            game_layout.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == data.gameSelect).Checked = true;
            platform_layout.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == data.platformSelect).Checked = true;
            song_checksum.Text = data.songName;
            chart_author_input.Text = data.chartAuthor;
            title_input.Text = data.title;
            artist_input.Text = data.artist;
            artistTextCustom.Text = data.artistTextCustom;
            cover_artist_input.Text = data.coverArtist;


            // GH3 Audio
            guitar_input_gh3.Text = data.guitarPathGh3;
            rhythm_input_gh3.Text = data.rhythmPathGh3;
            if (data.backingPathsGh3 != "")
            {
                backing_input_gh3.Items.AddRange(data.backingPathsGh3.Split(';'));
            }
            coop_guitar_input_gh3.Text = data.coopGuitarPath;
            coop_rhythm_input_gh3.Text = data.coopRhythmPath;
            if (data.coopBackingPaths != "")
            {
                coop_backing_input_gh3.Items.AddRange(data.coopBackingPaths.Split(';'));
            }
            crowd_input_gh3.Text = data.crowdPathGh3;
            preview_audio_input_gh3.Text = data.previewAudioPathGh3;
            previewVolumeGh3.Value = data.previewVolumeGh3;
            gh3_rendered_preview_check.Checked = data.useRenderedPreviewGh3;

            // GH3 Song Data
            midi_file_input_gh3.Text = data.midiPathGh3;
            perf_override_input_gh3.Text = data.perfPathGh3;
            ska_files_input_gh3.Text = data.skaPathGh3;
            song_script_input_gh3.Text = data.songScriptPathGh3;

            // Other Settings
            compile_input.Text = data.compilePath;
            project_input.Text = data.projectPath;

            // Metadata
            artist_text_select.SelectedIndex = data.artistText;
            year_input.Value = data.songYear;
            cover_year_input.Value = data.coverYear;
            gameSelectedGenres["GHWT"] = data.wtGenre;
            gameSelectedGenres["GH5"] = data.gh5Genre;
            gameSelectedGenres["GHWoR"] = data.worGenre;

            HmxHopoVal.Value = data.hmxHopoVal;
            hopo_mode_select.SelectedIndex = data.hopoMode;
            beat8thLow.Value = data.beat8thLow;
            beat8thHigh.Value = data.beat8thHigh;
            beat16thLow.Value = data.beat16thLow;
            beat16thHigh.Value = data.beat16thHigh;
            isCover.Checked = data.isCover;
            use_beat_check.Checked = data.useBeatTrack;

            // GH3 Additional Settings
            ska_file_source_gh3.SelectedIndex = data.skaSourceGh3;
            venue_source_gh3.SelectedIndex = data.venueSourceGh3;
            countoff_select_gh3.SelectedIndex = data.countoffGh3;
            vocal_gender_select_gh3.SelectedIndex = data.vocalGenderGh3;
            bassist_select_gh3.SelectedIndex = data.bassistSelect;
            gh3_gtr_vol.Value = data.gtrVolumeGh3;
            gh3_band_vol.Value = data.bandVolumeGh3;
            p2_rhythm_check.Checked = data.isP2Rhythm;
            coop_audio_check.Checked = data.isCoopAudio;
            gh3_rendered_preview_check.Checked = data.useRenderedPreview;
            gh3_set_end.Checked = data.setEnd;

            // GHWT Audio
            kickInput.Text = data.kickPath;
            snareInput.Text = data.snarePath;
            cymbalsInput.Text = data.cymbalsPath;
            tomsInput.Text = data.tomsPath;
            guitarInput.Text = data.guitarPath;
            bassInput.Text = data.bassPath;
            vocalsInput.Text = data.vocalsPath;
            if (data.backingPaths != "")
            {
                backingInput.Items.AddRange(data.backingPaths.Split(';'));
            }
            crowdInput.Text = data.crowdPath;
            previewInput.Text = data.previewAudioPath;
            previewVolume.Value = data.previewVolume;
            renderedPreviewCheck.Checked = data.useRenderedPreview;

            // Song Data
            midiFileInput.Text = data.midiPath;
            easyOpenCheckbox.Checked = data.easyOpen;
            perfOverrideInput.Text = data.perfPath;
            skaFilesInput.Text = data.skaPath;
            gh3SkaFilesInput.Text = data.lipsyncPath;
            songScriptInput.Text = data.songScriptPath;
            skaFileSource.SelectedIndex = data.skaSource;
            venueSource.SelectedIndex = data.venueSource;
            countoffSelect.SelectedIndex = data.countoff;
            gameDrumKits["GHWT"] = data.ghwtDrumkit;
            gameDrumKits["GH5"] = data.gh5Drumkit;
            gameDrumKits["GHWoR"] = data.ghworDrumkit;
            try
            {
                drumKitSelect.SelectedItem = gameDrumKits[CurrentGame];
            }
            catch
            {

            }
            vocalGenderSelect.SelectedIndex = data.vocalGender;
            vocalScrollSpeed.Value = data.vocalScrollSpeed;
            vocalTuningCents.Value = data.vocalTuningCents;
            sustainThreshold.Value = data.sustainThreshold;
            overallVolume.Value = data.overallVolume;
            guitarMicCheck.Checked = data.guitarMic;
            bassMicCheck.Checked = data.bassMic;

            // WTDE Settings
            gameIconInput.Text = data.gameIcon;
            gameCategoryInput.Text = data.gameCategory;
            bandInput.Text = data.bandWtde;
            gSkeletonSelect.Text = data.gSkeleton;
            bSkeletonSelect.Text = data.bSkeleton;
            dSkeletonSelect.Text = data.dSkeleton;
            vSkeletonSelect.Text = data.vSkeleton;
            useNewClipsCheck.Checked = data.useNewClips;
            modernStrobesCheck.Checked = data.modernStrobes;
            previewStartTime = data.previewStart;
            previewEndTime = data.previewEnd;
            UpdatePreviewFields(); // This needs to be changed. Currently broken
            isProgrammaticChange = false;

            // WoR Tiers
            bandTierValue.Value = data.bandTier;
            guitarTierValue.Value = data.guitarTier;
            bassTierValue.Value = data.bassTier;
            drumsTierValue.Value = data.drumsTier;
            vocalsTierValue.Value = data.vocalsTier;

            SetAll();
        }
        private void SaveProject()
        {
            if (File.Exists(projectFilePath))
            {
                var data = makeSaveClass();

                // Custom serializer settings to ignore default values
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };

                string json = JsonConvert.SerializeObject(data, settings);
                File.WriteAllText(projectFilePath, json);
            }
            else
            {
                SaveProjectAs();
            }
        }

        private void SaveProjectAs()
        {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = ghprojFileFilter;
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    project_input.Text = saveFileDialog.FileName;
                    var data = makeSaveClass();
                    // Custom serializer settings to ignore default values
                    var settings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    };

                    string json = JsonConvert.SerializeObject(data, settings);
                    File.WriteAllText(saveFileDialog.FileName, json); // Use the selected file name for saving
                }
            }
        }
        private void LoadProject(string filePath)
        {
            if (File.Exists(filePath))
            {
                isLoading = true;
                string json = File.ReadAllText(filePath);
                SaveData data = JsonConvert.DeserializeObject<SaveData>(json);
                projectFilePath = filePath;

                LoadSaveData(data);
                isLoading = false;
            }
        }
        private void LoadFromChFolder(string folderPath)
        {
            string game = CurrentGame;
            string platform = CurrentPlatform;
            // Clear everything by loading the default template
            DefaultTemplateCheck();
            game_layout.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == game).Checked = true;
            platform_layout.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Text == platform).Checked = true;
            bool isOld = CurrentGame == GAME_GH3 || CurrentGame == GAME_GHA;
            isProgrammaticChange = true;
            foreach (string file in Directory.GetFiles(folderPath))
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".ini")
                {
                    var ini = iniParser.ReadIniFromPath(file);
                    string songData = null;

                    // Check for the section in a case-insensitive manner
                    foreach (var section in ini.Sections)
                    {
                        if (string.Equals(section.SectionName, "song", StringComparison.OrdinalIgnoreCase))
                        {
                            songData = section.SectionName; // This retains the original casing ("song" or "Song")
                            break;
                        }
                    }

                    // Proceed only if a matching section was found
                    if (songData != null)
                    {
                        GetDataFromSongIni(ini, songData);
                    }
                }
                else if (Regex.IsMatch(file, midiRegexCh))
                {
                    midi_file_input_gh3.Text = file;
                    midiFileInput.Text = file;
                }
            }
            var assignment = iniParser.AssignFiles(folderPath, "GH3");
            // Update GH3-specific UI
            guitar_input_gh3.Text = assignment.Guitar ?? guitar_input_gh3.Text;
            rhythm_input_gh3.Text = assignment.Rhythm ?? rhythm_input_gh3.Text;
            crowd_input_gh3.Text = assignment.Crowd ?? crowd_input_gh3.Text;
            preview_audio_input_gh3.Text = assignment.Preview ?? preview_audio_input_gh3.Text;
            backing_input_gh3.Items.Clear();
            backing_input_gh3.Items.AddRange(assignment.BackingTracks.ToArray());
            gh3_rendered_preview_check.Checked = assignment.RenderedPreview;


            assignment = iniParser.AssignFiles(folderPath, "GHWT");
            // Update modern GH-specific UI
            kickInput.Text = assignment.KickDrum ?? kickInput.Text;
            snareInput.Text = assignment.SnareDrum ?? snareInput.Text;
            tomsInput.Text = assignment.Toms ?? tomsInput.Text;
            cymbalsInput.Text = assignment.Cymbals ?? cymbalsInput.Text;
            guitarInput.Text = assignment.Guitar ?? guitarInput.Text;
            bassInput.Text = assignment.Bass ?? bassInput.Text;
            vocalsInput.Text = assignment.Vocals ?? vocalsInput.Text;
            crowdInput.Text = assignment.Crowd ?? crowdInput.Text;
            previewInput.Text = assignment.Preview ?? previewInput.Text;
            backingInput.Items.Clear();
            backingInput.Items.AddRange(assignment.BackingTracks.ToArray());
            renderedPreviewCheck.Checked = assignment.RenderedPreview;

            UpdatePreviewFields();
            isProgrammaticChange = false;
            SetAll();
        }
        private void GetDataFromSongIni(IniData ini, string iniSection)
        {
            var songData = iniParser.ParseSongIni(ini, iniSection);

            title_input.Text = songData.Title ?? string.Empty;
            artist_input.Text = songData.Artist ?? string.Empty;
            chart_author_input.Text = songData.Charter ?? string.Empty;
            song_checksum.Text = songData.Checksum ?? string.Empty;

            if (songData.Year.HasValue)
                year_input.Value = songData.Year.Value;

            if (songData.BandTier.HasValue)
                bandTierValue.Value = songData.BandTier.Value;

            if (songData.GuitarTier.HasValue)
                guitarTierValue.Value = songData.GuitarTier.Value;

            if (songData.BassTier.HasValue)
                bassTierValue.Value = songData.BassTier.Value;

            if (songData.DrumsTier.HasValue)
                drumsTierValue.Value = songData.DrumsTier.Value;

            if (songData.VocalsTier.HasValue)
                vocalsTierValue.Value = songData.VocalsTier.Value;

            if (songData.SustainCutoffThreshold.HasValue)
                sustainThreshold.Value = songData.SustainCutoffThreshold.Value;

            if (songData.HopoFrequency.HasValue)
                HmxHopoVal.Value = songData.HopoFrequency.Value;

            previewStartTime = songData.PreviewStartTime ?? 30000;
            previewEndTime = songData.PreviewEndTime ?? 60000;

        }

    }
}
