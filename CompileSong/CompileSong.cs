﻿using GH_Toolkit_Core.Audio;
using GH_Toolkit_Core.PAK;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using GH_Toolkit_Core.QB;
using static GH_Toolkit_Core.QB.QBConstants;
using static GH_Toolkit_Exceptions.Exceptions;
using static GH_Toolkit_Core.Methods.Exceptions;
using static GH_Toolkit_Core.Methods.CreateForGame;
using static GH_Toolkit_GUI.PreCompileChecks;
using GH_Toolkit_Core.Methods;
using GH_Toolkit_Core.PS360;
using IniParser.Model;
using IniParser;
using IniParser.Model.Configuration;
using GH_Toolkit_Core.SKA;
using GH_Toolkit_Core.Methods;
using GH_Toolkit_Core.Checksum;
using GH_Toolkit_Core.PS360;
using System;
using Microsoft.VisualBasic.Devices;
using YamlDotNet.Core.Tokens;

namespace GH_Toolkit_GUI
{
    public partial class CompileSong : Form
    {
        private int ghprojVersion = 1;

        private string DefaultTemplateFolder;
        private string DefaultTemplatePath;
        private string StartupProject;

        private string GH3Path;
        private string GHAPath;
        private string WtSongFolder;
        private string ContentFolder;
        private string MusicFolder;

        // This is needed to force all numbers to use decimals with a period as the decimal separator
        private static CultureInfo Murica = new CultureInfo("en-US");

        private string CurrentGame;
        private string CurrentPlatform;
        private uint ConsoleChecksum;
        private string ConsoleCompile = "";

        // Dictionary to hold the selected genre for each game
        private Dictionary<string, int> gameSelectedGenres = new Dictionary<string, int>()
        {
            { "GHWT", 0 },
            { "GH5", 0 },
            { "GHWoR", 0 }
        };
        // Dictionary to hold the selected drum kit for each game
        private Dictionary<string, string> gameDrumKits = new Dictionary<string, string>()
        {
            { "GHWT", "Modern Rock" },
            { "GH5", "Modern Rock" },
            { "GHWoR", "Modern Rock" }
        };
        // Dictionary to hold the compile folder path for each platform and each game
        private Dictionary<string, Dictionary<string, string>> gamePlatformCompilePaths = new Dictionary<string, Dictionary<string, string>>();


        private RadioButton lastCheckedRadioButton = null;
        private string audioFileFilter = "Audio files (*.mp3, *.ogg, *.flac, *.wav)|*.mp3;*.ogg;*.flac;*.wav|All files (*.*)|*.*";
        private string audioRegex = ".*\\.(mp3|ogg|flac|wav)$";
        private string midiFileFilter = "Guitar Hero Note Files (*.mid, *.q)|*.mid;*.q|MIDI files (*.mid)|*.mid|Q files|*.q|All files (*.*)|*.*";
        private string midiRegexCh = ".*\\.mid$";
        private string qFileFilter = "Q files (*.q)|*.q|All files (*.*)|*.*";
        private string ghprojFileFilter = "GHProj files (*.ghproj)|*.ghproj|All files (*.*)|*.*";

        private Dictionary<string, TabPage> tabPageDict = new Dictionary<string, TabPage>();
        private int previewStartTime;
        private int previewEndTime;
        private decimal nsHopoThreshold;

        private string compileFolderPath = "";
        private string GhwtModsFolderPath = "";
        private string projectFilePath = "";

        private bool isProgrammaticChange = false;
        private bool isLoading = false;
        private bool isExport = false;
        private bool isAudioCompile = false;
        private UserPreferences Pref = UserPreferences.Default;
        private List<QB.QBItem> SongList = new List<QB.QBItem>();
        private string[] QsStrings = [];
        private GhMetadata Metadata = new GhMetadata();
        private string PakFilePath = "";
        private TimeSpan Duration = new TimeSpan();
        private bool IsImport = false;

        private bool RecoverGameSettings = false;

        public CompileSong(string ghproj = "")
        {
            InitializeComponent();

            year_input.Value = DateTime.Now.Year;

            this.Load += new EventHandler(MainForm_Load);
            if (ghproj != "")
            {
                StartupProject = ghproj;
                this.Load += new EventHandler(Startup_Load);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Iterate through all controls in the TableLayoutPanel
            foreach (Control nestedControl in game_layout.Controls)
            {
                // Check if the nested control is a RadioButton
                if (nestedControl is RadioButton radioButton)
                {
                    // Attach the CheckedChanged event handler to the RadioButton
                    radioButton.CheckedChanged += GameSelect_CheckChanged;
                }
            }
            foreach (Control nestedControl in platform_layout.Controls)
            {
                // Check if the nested control is a RadioButton
                if (nestedControl is RadioButton radioButton)
                {
                    // Attach the CheckedChanged event handler to the RadioButton
                    radioButton.CheckedChanged += PlatformSelect_CheckChanged;
                }
            }
            InitializeTabDict();
            SetButtons();
            OneTimeSetup();
            SetAll();
            DefaultPaths();
            DefaultTemplateCheck();
            UpdateNsValue();
        }
        private void OneTimeSetup()
        {
            ska_file_source_gh3.SelectedIndex = 0;
            venue_source_gh3.SelectedIndex = 0;
            countoff_select_gh3.SelectedIndex = 0;
            vocal_gender_select_gh3.SelectedIndex = 0;
            bassist_select_gh3.SelectedIndex = 0;
            hopo_mode_select.SelectedIndex = 0;

            skaFileSource.SelectedIndex = 0;
            venueSource.SelectedIndex = 2;
            countoffSelect.SelectedIndex = 0;
            vocalGenderSelect.SelectedIndex = 0;


            string[] skeletons = LoadTextFile(Path.Combine(ExeDirectory, "List Files", "skeletons.txt"));
            if (skeletons.Length == 0)
            {
                skeletons = ["Default"];
            }

            gSkeletonSelect.Items.AddRange(skeletons);
            bSkeletonSelect.Items.AddRange(skeletons);
            dSkeletonSelect.Items.AddRange(skeletons);
            vSkeletonSelect.Items.AddRange(skeletons);

            gSkeletonSelect.SelectedIndex = 0;
            bSkeletonSelect.SelectedIndex = 0;
            dSkeletonSelect.SelectedIndex = 0;
            vSkeletonSelect.SelectedIndex = 0;

            string[] songCategories = LoadTextFile(Path.Combine(ExeDirectory, "List Files", "songcategories.txt"));
            if (songCategories.Length != 0)
            {
                gameCategoryInput.Items.AddRange(songCategories);
                foreach (string category in songCategories)
                {
                    gameIconInput.Items.Add($"gamelogo_{category}");
                }
            }

            previewMinutes.ValueChanged += allPreviewTimeChange;
            previewSeconds.ValueChanged += allPreviewTimeChange;
            previewMills.ValueChanged += allPreviewTimeChange;
            lengthMinutes.ValueChanged += allPreviewTimeChange;
            lengthSeconds.ValueChanged += allPreviewTimeChange;
            lengthMills.ValueChanged += allPreviewTimeChange;
            preview_minutes_gh3.ValueChanged += allPreviewTimeChange;
            preview_seconds_gh3.ValueChanged += allPreviewTimeChange;
            preview_mills_gh3.ValueChanged += allPreviewTimeChange;
            length_minutes_gh3.ValueChanged += allPreviewTimeChange;
            length_seconds_gh3.ValueChanged += allPreviewTimeChange;
            length_mills_gh3.ValueChanged += allPreviewTimeChange;


        }
        // Method to load a text file and return a list of string for each line in the file
        private string[] LoadTextFile(string filePath)
        {
            // Create a new list to hold the lines of the text file
            List<string> lines = new List<string>();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the text file and add them to the list
                lines = File.ReadAllLines(filePath).ToList();
            }

            // Return the list of lines
            return lines.ToArray();
        }
        private void Startup_Load(object sender, EventArgs e)
        {
            if (File.Exists(StartupProject))
            {
                LoadProject(StartupProject);
            }

        }
        private void SetAll()
        {
            SetGameFields();
            updatePreviewStartTime();
            updatePreviewEndTime();
            DisplayChecksum();
            CheckSustainThreshold();
        }
        private void DefaultPaths()
        {

            DefaultTemplateFolder = Path.Combine(ExeDirectory, "Templates");
            DefaultTemplatePath = Path.Combine(DefaultTemplateFolder, "default.ghproj");
            CurrentGame = GetGame();
            CurrentPlatform = GetPlatform();
        }
        private void DefaultTemplateCheck()
        {
            if (File.Exists(DefaultTemplatePath))
            {
                LoadProject(DefaultTemplatePath);
            }
            else
            {
                Directory.CreateDirectory(DefaultTemplateFolder);
                SaveData data = makeSaveClass();
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(DefaultTemplatePath, json);
            }
        }
        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Data format of the file(s) can be accepted
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Modify the DragDropEffects to provide a visual feedback to the user
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Reject the drop
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Optionally, you can handle multiple files or directories here
            // For this example, let's handle only the first path
            if (fileList != null && fileList.Length > 0)
            {
                TextBox textBox = sender as TextBox; // Cast the sender back to a TextBox
                if (textBox != null)
                {
                    textBox.Text = fileList[0];
                }
            }
        }
        private void InitializeTabDict()
        {
            tabPageDict = new Dictionary<string, TabPage>
            {
                { "metadata_tab", metadata_tab },
                { "audio_tab_wt", audio_tab_wt },
                { "song_data_wt", song_data_tab_wt },
                { "audio_tab_gh3", audio_tab_gh3 },
                { "song_data_gh3", song_data_tab_gh3 },
                { "compile_tab", compile_tab },
                { "wtde_settings", wtde_settings },
                { "wor_settings", wor_settings }

            };
        }
        private void SetButtons()
        {
            // Set the Tag property with both the target TextBox and the dialog type

            // General

            compile_select.Tag = new Tuple<TextBox, string, string>(compile_input, "folder", "");
            project_select.Tag = new Tuple<TextBox, string, string>(project_input, "file", ghprojFileFilter);

            // Attach the event handlers to all general buttons
            compile_select.Click += SelectFileFolder;
            compile_select.Click += SaveCompileString;
            project_select.Click += SelectFileFolder;
            project_input.TextChanged += SaveProjectString;

            // GH3/Aerosmith

            // Audio
            guitar_select_gh3.Tag = new Tuple<TextBox, string, string>(guitar_input_gh3, "file", audioFileFilter);
            rhythm_select_gh3.Tag = new Tuple<TextBox, string, string>(rhythm_input_gh3, "file", audioFileFilter);
            backing_add_gh3.Tag = backing_input_gh3;
            backing_delete_gh3.Tag = backing_input_gh3;

            coop_guitar_select_gh3.Tag = new Tuple<TextBox, string, string>(coop_guitar_input_gh3, "file", audioFileFilter);
            coop_rhythm_select_gh3.Tag = new Tuple<TextBox, string, string>(coop_rhythm_input_gh3, "file", audioFileFilter);
            coop_backing_add_gh3.Tag = coop_backing_input_gh3;
            coop_backing_delete_gh3.Tag = coop_backing_input_gh3;

            crowd_select_gh3.Tag = new Tuple<TextBox, string, string>(crowd_input_gh3, "file", audioFileFilter);
            preview_audio_select_gh3.Tag = new Tuple<TextBox, string, string>(preview_audio_input_gh3, "file", audioFileFilter);

            // Attach the event handlers to all GH3/A Audio tab buttons
            guitar_select_gh3.Click += SelectFileFolder;
            rhythm_select_gh3.Click += SelectFileFolder;
            backing_add_gh3.Click += AddToListBox;
            backing_delete_gh3.Click += DeleteFromListBox;

            coop_guitar_select_gh3.Click += SelectFileFolder;
            coop_rhythm_select_gh3.Click += SelectFileFolder;
            coop_backing_add_gh3.Click += AddToListBox;
            coop_backing_delete_gh3.Click += DeleteFromListBox;

            crowd_select_gh3.Click += SelectFileFolder;
            preview_audio_select_gh3.Click += SelectFileFolder;

            // Song Data
            midi_file_select_gh3.Tag = new Tuple<TextBox, string, string>(midi_file_input_gh3, "file", midiFileFilter);
            perf_override_select_gh3.Tag = new Tuple<TextBox, string, string>(perf_override_input_gh3, "file", qFileFilter);
            ska_files_select_gh3.Tag = new Tuple<TextBox, string, string>(ska_files_input_gh3, "folder", "");
            song_script_select_gh3.Tag = new Tuple<TextBox, string, string>(song_script_input_gh3, "file", qFileFilter);

            // Attach the event handlers to all GH3/A Song Data tab buttons
            midi_file_select_gh3.Click += SelectFileFolder;
            perf_override_select_gh3.Click += SelectFileFolder;
            ska_files_select_gh3.Click += SelectFileFolder;
            song_script_select_gh3.Click += SelectFileFolder;

            // GHWT+

            // Audio
            kickSelect.Tag = new Tuple<TextBox, string, string>(kickInput, "file", audioFileFilter);
            snareSelect.Tag = new Tuple<TextBox, string, string>(snareInput, "file", audioFileFilter);
            cymbalsSelect.Tag = new Tuple<TextBox, string, string>(cymbalsInput, "file", audioFileFilter);
            tomsSelect.Tag = new Tuple<TextBox, string, string>(tomsInput, "file", audioFileFilter);

            guitarSelect.Tag = new Tuple<TextBox, string, string>(guitarInput, "file", audioFileFilter);
            bassSelect.Tag = new Tuple<TextBox, string, string>(bassInput, "file", audioFileFilter);
            vocalsSelect.Tag = new Tuple<TextBox, string, string>(vocalsInput, "file", audioFileFilter);

            backingAdd.Tag = backingInput;
            backingDelete.Tag = backingInput;

            crowdSelect.Tag = new Tuple<TextBox, string, string>(crowdInput, "file", audioFileFilter);
            previewSelect.Tag = new Tuple<TextBox, string, string>(previewInput, "file", audioFileFilter);

            // Attach the event handlers to all GHWT+ Audio tab buttons
            kickSelect.Click += SelectFileFolder;
            snareSelect.Click += SelectFileFolder;
            cymbalsSelect.Click += SelectFileFolder;
            tomsSelect.Click += SelectFileFolder;

            guitarSelect.Click += SelectFileFolder;
            bassSelect.Click += SelectFileFolder;
            vocalsSelect.Click += SelectFileFolder;

            backingAdd.Click += AddToListBox;
            backingDelete.Click += DeleteFromListBox;

            crowdSelect.Click += SelectFileFolder;
            previewSelect.Click += SelectFileFolder;

            // Song Data
            midiFileSelect.Tag = new Tuple<TextBox, string, string>(midiFileInput, "file", midiFileFilter);
            perfOverrideSelect.Tag = new Tuple<TextBox, string, string>(perfOverrideInput, "file", qFileFilter);
            skaFilesSelect.Tag = new Tuple<TextBox, string, string>(skaFilesInput, "folder", "");
            gh3SkaFilesSelect.Tag = new Tuple<TextBox, string, string>(gh3SkaFilesInput, "folder", "");
            songScriptSelect.Tag = new Tuple<TextBox, string, string>(songScriptInput, "file", qFileFilter);

            // Attach the event handlers to all GHWT+ Song Data tab buttons
            midiFileSelect.Click += SelectFileFolder;
            perfOverrideSelect.Click += SelectFileFolder;
            skaFilesSelect.Click += SelectFileFolder;
            gh3SkaFilesSelect.Click += SelectFileFolder;
            songScriptSelect.Click += SelectFileFolder;
        }
        public void SetGameFields()
        {
            var game = GetGame();
            if (game == "")
            {
                return;
            }
            bool isOld = game == "GH3" || game == "GHA";
            EnablePlatforms();
            SetTabs(isOld);
            SetGenres(game);
            SetDrumkit();
            SetBeatLines();
        }
        private void SetBeatLines()
        {
            beat8thLow.Enabled = Pref.OverrideBeatLines;
            beat8thHigh.Enabled = Pref.OverrideBeatLines;
            beat16thLow.Enabled = Pref.OverrideBeatLines;
            beat16thHigh.Enabled = Pref.OverrideBeatLines;
        }
        private void EnablePlatforms()
        {
            platform_pc.Enabled = true;
            platform_ps2.Enabled = false;
            platform_360.Enabled = true;
            platform_ps3.Enabled = true;
            if (CurrentGame == "GH3")
            {
                platform_ps2.Enabled = true;
            }
            else if (CurrentGame == "GHA")
            {
                platform_ps2.Enabled = true;
            }
            else if (CurrentGame == "GHWT")
            {
                platform_360.Enabled = false;
                platform_ps3.Enabled = false;
                platform_pc.Checked = true;
            }
            else
            {
                platform_pc.Enabled = false;
                if (platform_pc.Checked || platform_ps2.Checked)
                {
                    if (Pref.PreferredConsole == CONSOLE_PS3)
                    {
                        platform_ps3.Checked = true;
                    }
                    else
                    {
                        platform_360.Checked = true;
                    }
                }
            }
        }
        private void SetGenres(string game)
        {
            List<string> genreBase = new List<string> { "Rock", "Punk", "Glam Rock", "Black Metal", "Classic Rock", "Pop" };
            List<string> genreWt = new List<string> { "Heavy Metal", "Goth" };
            List<string> genreGh5 = new List<string> { "Alternative", "Big Band", "Blues", "Blues Rock", "Country", "Dance", "Death Metal", "Disco",
                     "Electronic", "Experimental", "Funk", "Grunge", "Hard Rock", "Hardcore", "Hip Hop", "Indie Rock",
                     "Industrial", "International", "Jazz", "Metal", "Modern Rock", "New Wave", "Nu Metal", "Pop Punk",
                     "Pop Rock", "Prog Rock", "R&B", "Reggae", "Rockabilly", "Ska Punk", "Southern Rock", "Speed Metal",
                     "Surf Rock" };
            List<string> genreGh6 = new List<string> { "Hardcore Punk", "Heavy Metal", "Progressive Rock" };

            // Create a merged list based on the game
            List<string> mergedGenres = new List<string>(genreBase); // Start with the base
            if (game == "GHWT")
            {
                mergedGenres.AddRange(genreWt);
            }
            else if (game == "GH5")
            {
                mergedGenres.AddRange(genreGh5);
            }
            else if (game == "GHWoR")
            {
                mergedGenres.AddRange(genreGh5);
                mergedGenres.AddRange(genreGh6);
            }

            mergedGenres.Sort();
            mergedGenres.Add("Other");

            // Set the genre list
            genre_input.Items.Clear();
            if (game != "GH3" && game != "GHA")
            {
                genre_input.Enabled = true;
                genre_input.Items.AddRange(mergedGenres.ToArray());
                if (gameSelectedGenres.ContainsKey(game))
                {
                    genre_input.SelectedIndex = gameSelectedGenres[game];
                }
                else if (!isLoading)
                {
                    genre_input.SelectedIndex = 0;
                }
            }
            else
            {
                genre_input.Enabled = false;
                genre_input.Text = "";
            }
        }
        private void SetDrumkit()
        {
            string game = CurrentGame;
            if (game == GAME_GH3 || game == GAME_GHA)
            {
                return;
            }
            List<string> drumKitBase = new List<string> { "Classic Rock", "Electro", "Fusion", "Heavy Rock", "Hip Hop", "Modern Rock" };
            List<string> drumKitWt = new List<string> { "Blip Hop", "Cheesy", "Computight", "Conga", "Dub", "Eightys", "Gunshot",
                                       "House", "India", "Jazzy", "Old School", "Orchestral", "Scratch", "Scratch_Electro" };
            List<string> drumKitWtde = new List<string> { "And Justice For All" };
            List<string> drumKitGh5 = new List<string> { "Bigroom Rock", "Dance", "Metal", "Noise", "Standard Rock" };

            if (CurrentGame == "GHWT")
            {
                drumKitBase.AddRange(drumKitWt);
                if (CurrentPlatform == "PC")
                {
                    drumKitBase.AddRange(drumKitWtde);
                }
            }
            else
            {
                drumKitBase.AddRange(drumKitGh5);
            }

            drumKitBase.Sort();

            string? tempDrumkit = "";

            if (drumKitSelect.SelectedItem != null)
            {
                tempDrumkit = drumKitSelect.SelectedItem.ToString();
            }

            // Clear drumKitSelect ComboBox entries
            drumKitSelect.Items.Clear();

            // Add the drum kits to the drumKitSelect ComboBox
            drumKitSelect.Items.AddRange(drumKitBase.ToArray());

            // Set the drum kit to the previously selected drum kit
            if (drumKitSelect.Items.Contains(tempDrumkit))
            {
                drumKitSelect.SelectedItem = tempDrumkit;
            }
            else
            {
                drumKitSelect.SelectedItem = "Modern Rock";
            }
        }
        private void SetGh3Fields(string game)
        {
            bool isGha = game == "GHA";
            crowd_label_gh3.Enabled = isGha;
            crowd_input_gh3.Enabled = isGha;
            crowd_select_gh3.Enabled = isGha;
        }
        private void SetTabs(bool isOld)
        {
            compiler_tabs.TabPages.Clear();
            List<(string tab, string tabName)> tabNames;
            if (isOld)
            {
                tabNames = new List<(string tab, string tabName)>
                {
                    ("metadata_tab", "Metadata"),
                    ("audio_tab_gh3", "Audio"),
                    ("song_data_gh3", "Song Data"),
                    ("compile_tab", "Compile")
                };
            }
            else
            {
                tabNames = new List<(string tab, string tabName)>
                {
                    ("metadata_tab", "Metadata"),
                    ("audio_tab_wt", "Audio"),
                    ("song_data_wt", "Song Data"),
                    ("compile_tab", "Compile")
                };
            }
            foreach (var (tab, tabName) in tabNames)
            {
                var newTab = tabPageDict[tab];
                newTab.Text = tabName;
                compiler_tabs.TabPages.Add(newTab);
            }
            if (CurrentGame == GAME_GHWT && CurrentPlatform == "PC")
            {
                compiler_tabs.TabPages.Add(wtde_settings);
            }
            else if (CurrentGame == GAME_GHWOR)
            {
                compiler_tabs.TabPages.Add(wor_settings);
            }
        }
        public string GetGame()
        {
            return GetSelectedFromTable(game_layout);
        }
        public string GetPlatform()
        {
            return GetSelectedFromTable(platform_layout);
        }
        public string GetSkaSourceGh3()
        {
            return GetSkaSource(ska_file_source_gh3.SelectedIndex);

        }
        public string GetSkaSourceGhwt()
        {
            return GAME_GHWT;
            //return GetSkaSource(skaFileSource.SelectedIndex);
        }
        private string GetSkaSource(int skaSource)
        {
            if (skaSource == 2)
            {
                return "GH3";
            }
            else if (skaSource == 1)
            {
                return "GHA";
            }
            else
            {
                return "GHWT";
            }
        }
        public string GetSelectedFromTable(TableLayoutPanel table)
        {
            foreach (Control control in table.Controls)
            {
                // Check if the control is a RadioButton
                if (control is RadioButton radioButton)
                {
                    // Check if the radio button is checked
                    if (radioButton.Checked)
                    {
                        return radioButton.Text;
                    }
                }
            }
            return "";
        }
        private void GameSelect_CheckChanged(object sender, EventArgs e)
        {
            // Sender is the radio button that triggered the event
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                if (!radioButton.Checked && lastCheckedRadioButton == radioButton)
                {
                    // Radio button is unchecked, add or update the entry in the gameSelectedGenres dictionary
                    string gameName = lastCheckedRadioButton.Text;
                    var selectedGenre = genre_input.SelectedIndex; // Get the currently selected genre

                    if (!string.IsNullOrEmpty(gameName))
                    {
                        // Add or update the dictionary entry for the game
                        gameSelectedGenres[gameName] = selectedGenre;
                    }

                    // Reset lastCheckedRadioButton since we've handled the unchecked event
                    lastCheckedRadioButton = null;
                }
                else if (radioButton.Checked)
                {
                    // Update the Current Game field
                    CurrentGame = radioButton.Text;

                    // Radio button is checked, update fields based on the selected game
                    SetGameFields();
                    CheckSustainThreshold();


                    // Remember this radio button as the last one checked
                    lastCheckedRadioButton = radioButton;


                }
            }
        }
        private void CheckSustainThreshold()
        {
            if (CurrentGame == "GH3" || CurrentGame == "GHA")
            {
                return;
            }
            if (CurrentPlatform == "PC")
            {
                if (CurrentGame == "GHWT" && sustainThreshold.Value > 0.44m && sustainThreshold.Value < 0.46m)
                {
                    sustainThreshold.Value = 0.50m;
                }
            }
            else
            {
                if (sustainThreshold.Value > 0.49m && sustainThreshold.Value < 0.51m)
                {
                    sustainThreshold.Value = 0.45m;
                }
            }
        }
        private void PlatformSelect_CheckChanged(object sender, EventArgs e)
        {
            string game = CurrentGame;
            // Sender is the radio button that triggered the event
            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                if (radioButton.Checked)
                {
                    // Update the Current Platform field
                    CurrentPlatform = radioButton.Text;
                    DisplayChecksum();
                    EnableCompileOnly();
                }
            }
        }
        private void DisplayChecksum()
        {
            if (CurrentPlatform == "Xbox 360" || CurrentPlatform == "PS3")
            {
                SetConsoleChecksum();
                dlcChecksumLabel.Visible = true;
                dlcChecksum.Visible = true;
                dlcChecksum.Text = ConsoleChecksum.ToString();
            }
            else
            {
                dlcChecksumLabel.Visible = false;
                dlcChecksum.Visible = false;
            }
        }
        private void EnableCompileOnly()
        {
            compile_pak_button.Enabled = false;
            compile_pak_button.Text = "Disabled";
            if (CurrentPlatform == CONSOLE_PS2 || CurrentPlatform == CONSOLE_WII || CurrentPlatform == CONSOLE_PC)
            {
                compile_pak_button.Enabled = true;
                compile_pak_button.Text = "Compile Song PAK";
            }

        }
            private void SelectFileFolder(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Tuple<TextBox, string, string>)
            {
                var (linkedTextBox, dialogType, fileFilter) = (Tuple<TextBox, string, string>)btn.Tag;

                if (dialogType == "file")
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = fileFilter;
                        openFileDialog.FilterIndex = 1;
                        openFileDialog.RestoreDirectory = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the path of specified file
                            string filePath = openFileDialog.FileName;

                            // Update the linked TextBox with the selected file path
                            linkedTextBox.Text = filePath;
                        }
                    }
                }
                else if (dialogType == "folder")
                {
                    using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                    {
                        folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Get the path of selected folder
                            string folderPath = folderBrowserDialog.SelectedPath;

                            // Update the linked TextBox with the selected folder path
                            linkedTextBox.Text = folderPath;
                        }
                    }
                }
            }
        }
        private void SaveCompileString(object sender, EventArgs e)
        {
            compileFolderPath = compile_input.Text;
        }
        private void SaveProjectString(object sender, EventArgs e)
        {
            projectFilePath = project_input.Text;
        }
        private void AddToListBox(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is ListBox)
            {
                ListBox linkedTextBox = (ListBox)btn.Tag;
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = audioFileFilter;
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            linkedTextBox.Items.Add(file);
                        }
                    }
                }
            }
        }
        private void DeleteFromListBox(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is ListBox)
            {
                ListBox linkedTextBox = (ListBox)btn.Tag;
                if (linkedTextBox.SelectedIndex != -1)
                {
                    linkedTextBox.Items.RemoveAt(linkedTextBox.SelectedIndex);
                }
            }
        }
        private void isCover_CheckedChanged(object sender, EventArgs e)
        {
            coverLabel.Enabled = isCover.Checked;
            cover_artist_input.Enabled = isCover.Checked;
            cover_year_input.Enabled = isCover.Checked;
        }
        // Guitar Hero 3/Aerosmith Logic
        private void p2_rhythm_check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                coop_audio_check.Enabled = true;
                rhythm_label_gh3.Text = "Rhythm";
            }
            else
            {
                coop_audio_check.Enabled = false;
                coop_audio_check.Checked = false;
                rhythm_label_gh3.Text = "Bass";
            }
        }

        private void coop_audio_check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            coop_guitar_label_gh3.Enabled = checkBox.Checked;
            coop_guitar_input_gh3.Enabled = checkBox.Checked;
            coop_rhythm_label_gh3.Enabled = checkBox.Checked;
            coop_rhythm_input_gh3.Enabled = checkBox.Checked;
            coop_backing_label_gh3.Enabled = checkBox.Checked;
            coop_backing_input_gh3.Enabled = checkBox.Checked;
            coop_guitar_select_gh3.Enabled = checkBox.Checked;
            coop_rhythm_select_gh3.Enabled = checkBox.Checked;
            coop_backing_add_gh3.Enabled = checkBox.Checked;
            coop_backing_delete_gh3.Enabled = checkBox.Checked;
        }

        private void gh3_rendered_preview_check_CheckedChanged(object sender, EventArgs e)
        {
            /*if (isProgrammaticChange)
            {
                return;
            }*/
            gh3_preview_audio_label.Enabled = gh3_rendered_preview_check.Checked;
            preview_audio_input_gh3.Enabled = gh3_rendered_preview_check.Checked;
            preview_audio_select_gh3.Enabled = gh3_rendered_preview_check.Checked;

            preview_label_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            preview_minutes_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            preview_seconds_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            preview_mills_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            length_label_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            length_minutes_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            length_seconds_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            length_mills_gh3.Enabled = !gh3_rendered_preview_check.Checked;
            gh3_set_end.Enabled = !gh3_rendered_preview_check.Checked;
        }
        private void updatePreviewStartTime()
        {
            int minutes = (int)preview_minutes_gh3.Value;
            int seconds = (int)preview_seconds_gh3.Value;
            int mills = (int)preview_mills_gh3.Value;
            previewStartTime = (minutes * 60000) + (seconds * 1000) + mills;
        }
        private void updatePreviewEndTime()
        {
            int minutes = (int)length_minutes_gh3.Value;
            int seconds = (int)length_seconds_gh3.Value;
            int mills = (int)length_mills_gh3.Value;
            previewEndTime = (minutes * 60000) + (seconds * 1000) + mills;
        }
        private void previewLengthEndSwap()
        {
            if (gh3_set_end.Checked)
            {
                previewEndTime = previewStartTime + previewEndTime;
            }
            else
            {
                previewEndTime = previewEndTime - previewStartTime;
            }
            UpdatePreviewLengthFields();
        }
        private void UpdatePreviewFields()
        {
            if (previewStartTime < 0)
            {
                previewStartTime = 0;
            }
            if (previewEndTime < 0)
            {
                previewEndTime = 0;
            }
            var startTemp = previewStartTime;
            var endTemp = previewEndTime;
            preview_minutes_gh3.Value = startTemp / 60000;
            preview_seconds_gh3.Value = (startTemp % 60000) / 1000;
            preview_mills_gh3.Value = startTemp % 1000;
            length_minutes_gh3.Value = endTemp / 60000;
            length_seconds_gh3.Value = (endTemp % 60000) / 1000;
            length_mills_gh3.Value = endTemp % 1000;
            previewMinutes.Value = preview_minutes_gh3.Value;
            previewSeconds.Value = preview_seconds_gh3.Value;
            previewMills.Value = preview_mills_gh3.Value;
            lengthMinutes.Value = length_minutes_gh3.Value;
            lengthSeconds.Value = length_seconds_gh3.Value;
            lengthMills.Value = length_mills_gh3.Value;
        }
        private void UpdatePreviewLengthFields()
        {
            length_minutes_gh3.Value = previewEndTime / 60000;
            length_seconds_gh3.Value = (previewEndTime % 60000) / 1000;
            length_mills_gh3.Value = (previewEndTime % 60000) % 1000;
            lengthMinutes.Value = length_minutes_gh3.Value;
            lengthSeconds.Value = length_seconds_gh3.Value;
            lengthMills.Value = length_mills_gh3.Value;
        }
        private void allPreviewTimeChange(object sender, EventArgs e)
        {

            // Sender is the NumericUpDown that triggered the event
            NumericUpDown changed = sender as NumericUpDown;
            if (changed != null)
            {
                var actionMap = new Dictionary<NumericUpDown, Action<NumericUpDown>>()
                {
                    { preview_minutes_gh3, (c) => { previewMinutes.Value = c.Value; updatePreviewStartTime(); } },
                    { preview_seconds_gh3, (c) => { previewSeconds.Value = c.Value; updatePreviewStartTime(); } },
                    { preview_mills_gh3, (c) => { previewMills.Value = c.Value; updatePreviewStartTime(); } },
                    { length_minutes_gh3, (c) => { lengthMinutes.Value = c.Value; updatePreviewEndTime(); } },
                    { length_seconds_gh3, (c) => { lengthSeconds.Value = c.Value; updatePreviewEndTime(); } },
                    { length_mills_gh3, (c) => { lengthMills.Value = c.Value; updatePreviewEndTime(); } },
                    { previewMinutes, (c) => { preview_minutes_gh3.Value = c.Value; updatePreviewStartTime(); } },
                    { previewSeconds, (c) => { preview_seconds_gh3.Value = c.Value; updatePreviewStartTime(); } },
                    { previewMills, (c) => { preview_mills_gh3.Value = c.Value; updatePreviewStartTime(); } },
                    { lengthMinutes, (c) => { length_minutes_gh3.Value = c.Value; updatePreviewEndTime(); } },
                    { lengthSeconds, (c) => { length_seconds_gh3.Value = c.Value; updatePreviewEndTime(); } },
                    { lengthMills, (c) => { length_mills_gh3.Value = c.Value; updatePreviewEndTime(); } },
                };

                if (actionMap.TryGetValue(changed, out var action))
                {
                    if (isProgrammaticChange)
                    {
                        return;
                    }
                    isProgrammaticChange = true;
                    action(changed);
                    isProgrammaticChange = false;
                }
            }

        }
        private void gh3_preview_ValueChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange)
            {
                return;
            }
            updatePreviewStartTime();
        }
        private void gh3_preview_length_ValueChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange)
            {
                return;
            }
            updatePreviewEndTime();
        }
        private void gh3_set_end_CheckedChanged(object sender, EventArgs e)
        {
            isProgrammaticChange = true;
            previewLengthEndSwap();
            setEndTime.Checked = gh3_set_end.Checked;
            isProgrammaticChange = false;
        }

        private void UpdateGhwtModsFolder(string folderPath)
        {
            Pref.WtModsFolder = folderPath;
            Pref.Save();
        }
        // Compiling Logic
        private void PreCompileCheck()
        {
            ConsoleStringCheck();
            string game = CurrentGame;
            if ((game == "GH3" || game == "GHA") && CurrentPlatform == "PC")
            {
                Gh3PcCheck(game);
            }
            if (game == GAME_GHWT)
            {
                if (CurrentPlatform == "PC")
                {
                    if (!Directory.Exists(Pref.WtModsFolder))
                    {
                        MessageBox.Show("Your GHWT mods folder has not been set. Please select your MODS folder now.", "Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateGhwtModsFolder(AskForGamePath());
                    }
                }
            }
            if (CurrentPlatform == "PS2" && !isExport)
            {
                CreateConsoleFolder();
            }
            else if (CurrentPlatform != "PC")
            {
                OnyxCheck();
                CreateConsoleFolder();
            }
            else if (isExport)
            {
                CreateConsoleFolder();
            }

        }
        private void ConsoleStringCheck()
        {
            if (compile_input.Text == "")
            {
                compile_input.Text = Path.GetDirectoryName(project_input.Text);
            }
            if (song_checksum.Text == "")
            {
                CreateChecksum();
            }
            ConsoleCompile = Path.Combine(compile_input.Text, "Console");
        }
        private void CreateConsoleFolder()
        {
            if (!Directory.Exists(ConsoleCompile))
            {
                Directory.CreateDirectory(ConsoleCompile);
            }
        }
        private void ReplaceGh3PakFiles()
        {
            string qbPakLocation = GetGh3PakFile(CurrentGame);
            // Might make this use the backup instead in the future...
            string replaceLocation = Path.Combine(ExeDirectory, "Replacements", CurrentPlatform, CurrentGame, "QB");

            if (Directory.Exists(replaceLocation))
            {
                var pakCompiler = new PAK.PakCompiler(CurrentGame, CurrentPlatform, split: true);
                var replaceFiles = Directory.GetFiles(replaceLocation, "*.qb", SearchOption.AllDirectories);
                var qbPak = PAK.PakEntryDictFromFile(qbPakLocation);
                foreach (var file in replaceFiles)
                {
                    var relPath = Path.GetRelativePath(replaceLocation, file);
                    if (qbPak.TryGetValue(relPath, out var entry))
                    {
                        var qbData = File.ReadAllBytes(file);
                        entry.OverwriteData(qbData);
                    }
                }
                var (pakData, pabData) = pakCompiler.CompilePakFromDictionary(qbPak);
                OverwriteGh3Pak(pakData, pabData!, CurrentGame);
            }
        }

        private void CreateChecksum()
        {
            // Normalize the string to get the diacritics separated
            string formD = title_input.Text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char ch in formD)
            {
                // Keep the char if it is a letter and not a diacritic
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }
            // Remove non-alphabetic characters
            string alphanumericOnly = Regex.Replace(sb.ToString(), "[^A-Za-z]", "").ToLower();

            // Return the normalized string without diacritics and non-alphabetic characters
            song_checksum.Text = alphanumericOnly;
        }

        private string GetVenue(int venueType)
        {
            string venue;
            switch (venueType)
            {
                case 0:
                    venue = "GH3";
                    break;
                case 1:
                    venue = "GHA";
                    break;
                default:
                    venue = "GHWT";
                    break;
            }
            return venue;
        }
        private string GetSongChecksum()
        {
            if (CurrentPlatform == "PC" || CurrentPlatform == "PS2")
            {
                return song_checksum.Text;
            }
            else
            {
                return $"dlc{ConsoleChecksum}";
            }
        }
        private void CompileGh3PakFile()
        {

            string venue = GetVenue(venue_source_gh3.SelectedIndex);

            string checksum = GetSongChecksum();

            var (pakFile, doubleKick) = PAK.CreateSongPackage(
                midiPath: midi_file_input_gh3.Text,
                savePath: compile_input.Text,
                songName: checksum,
                game: CurrentGame,
                gameConsole: CurrentPlatform,
                hopoThreshold: (int)HmxHopoVal.Value,
                skaPath: ska_files_input_gh3.Text,
                perfOverride: perf_override_input_gh3.Text,
                songScripts: song_script_input_gh3.Text,
                skaSource: GetSkaSourceGh3(),
                venueSource: venue,
                rhythmTrack: p2_rhythm_check.Checked,
                overrideBeat: use_beat_check.Checked,
                hopoType: hopo_mode_select.SelectedIndex,
                isSteven: vocal_gender_select_gh3.Text == "Steven Tyler",
                gender: vocal_gender_select_gh3.Text);

            if (isExport)
            {
                File.Move(pakFile, Path.Combine(ConsoleCompile, $"{checksum}_song.pak"), true);
                var songEntry = GenerateGh3SongListEntry();
                QB.QBItem songItem = new QB.QBItem((string)songEntry["checksum"], songEntry);
                var saveQb = Path.Combine(ConsoleCompile, "songs.info");
                var bytes = QB.CompileQbFile([songItem], "songs.info", GAME_GH3, CONSOLE_XBOX);
                if (bytes == null)
                {
                    Console.WriteLine("Failed to compile songs.info");
                    return;
                }
                File.WriteAllBytes(saveQb, bytes);
            }
            else if (CurrentPlatform == "PC")
            {
                AddToPCSetlist();
                MoveToGh3SongsFolder(pakFile);
            }
            else if (CurrentPlatform == "PS2")
            {

            }
            else
            {
                File.Move(pakFile, Path.Combine(ConsoleCompile, $"dlc{ConsoleChecksum}_song.pak"), true);
                CreateConsoleFilesGh3();
            }
            // Add code to delete the folder after processing eventually
        }
        private void SetConsoleChecksum()
        {
            string qbString = $"{CurrentGame}{artist_input.Text}{title_input.Text}{year_input.Value}{chart_author_input.Text}{isCover.Checked}";
            ConsoleChecksum = MakeConsoleChecksum([qbString]);
        }
        private void CompileGhwtPakFile()
        {

            string venue = GetVenue(venueSource.SelectedIndex);

            var (pakFile, doubleKick) = PAK.CreateSongPackage(
                midiPath: midiFileInput.Text,
                savePath: compile_input.Text,
                songName: song_checksum.Text,
                game: CurrentGame,
                gameConsole: CurrentPlatform,
                hopoThreshold: (int)HmxHopoVal.Value,
                skaPath: skaFilesInput.Text,
                perfOverride: perfOverrideInput.Text,
                songScripts: songScriptInput.Text,
                skaSource: GetSkaSourceGhwt(),
                venueSource: venue,
                overrideBeat: use_beat_check.Checked,
                hopoType: hopo_mode_select.SelectedIndex,
                easyOpens: easyOpenCheckbox.Checked);

            if (CurrentPlatform == "PC")
            {
                WtSongFolder = Path.Combine(Pref.WtModsFolder, song_checksum.Text);
                ContentFolder = Path.Combine(WtSongFolder, "Content");
                MusicFolder = Path.Combine(ContentFolder, "Music");
                string pakName = Path.GetFileName(pakFile);

                Directory.CreateDirectory(MusicFolder);

                File.Move(pakFile, Path.Combine(ContentFolder, $"a{pakName}"), true);
                WriteWtdeIni(WtSongFolder);
            }
            // Add code to delete the folder after processing eventually
        }
        private bool CompileGh5PakFile()
        {
            string venue = GetVenue(venueSource.SelectedIndex);
            var diffs = new Dictionary<string, int>()
            {
                {"guitar", (int)guitarTierValue.Value },
                {"bass", (int)bassTierValue.Value },
                {"drums", (int)drumsTierValue.Value },
                {"vocals", (int)vocalsTierValue.Value }
            };

            (PakFilePath, var doubleKick) = PAK.CreateSongPackage(
               midiPath: midiFileInput.Text,
               savePath: compile_input.Text,
               songName: GetSongChecksum(),
               game: CurrentGame,
               gameConsole: CurrentPlatform,
               hopoThreshold: (int)HmxHopoVal.Value,
               skaPath: skaFilesInput.Text,
               perfOverride: perfOverrideInput.Text,
               songScripts: songScriptInput.Text,
               skaSource: GetSkaSourceGhwt(),
               venueSource: venue,
               overrideBeat: use_beat_check.Checked,
               hopoType: hopo_mode_select.SelectedIndex,
               easyOpens: easyOpenCheckbox.Checked,
               diffs: diffs);

            guitarTierValue.Value = diffs["guitar"];
            bassTierValue.Value = diffs["bass"];
            drumsTierValue.Value = diffs["drums"];
            vocalsTierValue.Value = diffs["vocals"];

            Metadata = PackageMetadataGhwtPlus(doubleKick);



            return true;
        }
        private void WriteWtdeIni(string saveFolder)
        {
            var config = new IniParserConfiguration();
            config.AssigmentSpacer = "";
            var noSpaceParser = new IniParser.Parser.IniDataParser(config);

            var parser = new FileIniDataParser(noSpaceParser);
            var ini = GenerateWtdeIni();
            var iniPath = Path.Combine(saveFolder, "song.ini");
            parser.WriteFile(iniPath, ini);
        }
        private void MoveToGh3SongsFolder(string pakPath)
        {
            string gameFolder = GetGh3Folder(CurrentGame);
            string saveFolder = Path.Combine(gameFolder, SONGSPath);
            string savePath = Path.Combine(saveFolder, Path.GetFileName(pakPath));
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            File.Move(pakPath, savePath, true);
        }
        private void MoveToGh3MusicFolder(string audioPath)
        {
            string gameFolder = GetGh3Folder(CurrentGame);
            string saveFolder = Path.Combine(gameFolder, MUSICPath);
            string savePath = Path.Combine(saveFolder, Path.GetFileName(audioPath));
            if (!savePath.EndsWith(".xen"))
            {
                savePath += ".xen";
            }
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            File.Move(audioPath, savePath, true);
        }
        private GhMetadata PackageMetadata(bool doubleKick = false, float hopoValOverride = 500f, bool gh3Convert = false)
        {

            return new GhMetadata
            {
                Checksum = GetSongChecksum(),
                CompileFolder = compile_input.Text,
                Title = title_input.Text,
                Artist = artist_input.Text,
                ArtistTextSelect = artist_text_select.Text,
                ArtistTextCustom = artistTextCustom.Text,
                Year = (int)year_input.Value,
                CoverArtist = cover_artist_input.Text,
                CoverYear = (int)cover_year_input.Value,
                Genre = genre_input.Text,
                ChartAuthor = chart_author_input.Text,
                Bassist = BassistName(),
                Singer = SingerName(),
                IsArtistFamousBy = IsArtistFamousBy(),
                AerosmithBand = aerosmithBand.Text,
                Beat8thLow = (int)beat8thLow.Value,
                Beat8thHigh = (int)beat8thHigh.Value,
                Beat16thLow = (int)beat16thLow.Value,
                Beat16thHigh = (int)beat16thHigh.Value,
                OverrideBeatLines = Pref.OverrideBeatLines,
                CoopAudioCheck = coop_audio_check.Checked,
                P2RhythmCheck = p2_rhythm_check.Checked,
                BandVol = (float)gh3_band_vol.Value,
                GtrVol = (float)gh3_gtr_vol.Value,
                Countoff = countoff_select_gh3.Text,
                HopoThreshold = hopoValOverride,
                Gh3Convert = gh3Convert
            };
        }
        private GhMetadata PackageMetadataGhwtPlus(bool doubleKick = false)
        {
            return new GhMetadata
            {
                Checksum = GetSongChecksum(),
                CompileFolder = compile_input.Text,
                Title = $"\\L{title_input.Text}",
                Artist = $"\\L{artist_input.Text}",
                ArtistTextSelect = artist_text_select.Text,
                ArtistTextCustom = artistTextCustom.Text,
                Year = (int)year_input.Value,
                CoverArtist = cover_artist_input.Text,
                CoverYear = (int)cover_year_input.Value,
                Genre = genre_input.Text,
                ChartAuthor = chart_author_input.Text,
                Singer = vocalGenderSelect.Text,
                IsArtistFamousBy = IsArtistFamousBy(),
                Beat8thLow = (int)beat8thLow.Value,
                Beat8thHigh = (int)beat8thHigh.Value,
                Beat16thLow = (int)beat16thLow.Value,
                Beat16thHigh = (int)beat16thHigh.Value,
                OverrideBeatLines = Pref.OverrideBeatLines,
                BandVol = (float)overallVolume.Value,
                Countoff = countoffSelect.Text,
                DoubleKick = doubleKick,
                VocalTuningCents = (int)vocalTuningCents.Value,
                SustainThreshold = (float)sustainThreshold.Value,
                VocalScrollSpeed = (float)vocalScrollSpeed.Value,
                GuitarMic = guitarMicCheck.Checked,
                BassMic = bassMicCheck.Checked,
                DrumKit = drumKitSelect.Text,
                Duration = GetAudioLength(),
                Game = CurrentGame,
                GuitarTier = (int)guitarTierValue.Value,
                BassTier = (int)bassTierValue.Value,
                DrumsTier = (int)drumsTierValue.Value,
                VocalsTier = (int)vocalsTierValue.Value,
                BandTier = (int)bandTierValue.Value,
            };
        }
        private QBStruct.QBStructData GenerateGh3SongListEntry()
        {
            IsImport = midi_file_input_gh3.Text.ToLower().EndsWith(".q");
            float hopoValOverride = 500f;

            if (IsImport)
            {
                hopoValOverride = (float)NsHopoVal.Value;
            }


            var songListEntry = PackageMetadata(false, hopoValOverride, IsImport);

            return songListEntry.GenerateGh3SongListEntry(CurrentGame, CurrentPlatform);
        }
        private string GetArtistText()
        {
            bool artistIsOther = artist_text_select.Text == "Other";
            string artistText = !artistIsOther ? $"artist_text_{artist_text_select.Text.ToLower().Replace(" ", "_")}" : artistTextCustom.Text;
            return artistText;
        }
        private bool IsArtistFamousBy()
        {
            return artist_text_select.Text == "As Made Famous By";
        }
        private IniData GenerateWtdeIni()
        {
            var config = new IniParserConfiguration();
            config.AssigmentSpacer = "";
            bool cover = isCover.Checked;

            IniData wtdeIni = new IniData();
            wtdeIni.Configuration = config;
            var modInfo = new SectionData("ModInfo");
            modInfo.Keys.AddKey("Name", song_checksum.Text);
            modInfo.Keys.AddKey("Description", "Generated with Addy's Song Compiler");
            modInfo.Keys.AddKey("Author", chart_author_input.Text);
            modInfo.Keys.AddKey("Version", "1");


            var songInfo = new SectionData("SongInfo");
            songInfo.Keys.AddKey("Checksum", song_checksum.Text);
            songInfo.Keys.AddKey("Title", title_input.Text);
            songInfo.Keys.AddKey("Artist", artist_input.Text);
            songInfo.Keys.AddKey("Year", year_input.Value.ToString("G0", Murica));
            songInfo.Keys.AddKey("ArtistText", GetArtistText());
            if (cover)
            {
                songInfo.Keys.AddKey("CoverArtist", cover_artist_input.Text);
                songInfo.Keys.AddKey("CoverYear", cover_year_input.Value.ToString("G0", Murica));
            }
            songInfo.Keys.AddKey("OriginalArtist", cover ? "0" : "1");
            songInfo.Keys.AddKey("Leaderboard", "1");
            songInfo.Keys.AddKey("Singer", vocalGenderSelect.Text);
            songInfo.Keys.AddKey("Genre", genre_input.Text);
            songInfo.Keys.AddKey("Countoff", countoffSelect.Text);
            songInfo.Keys.AddKey("Volume", overallVolume.Value.ToString("G2", Murica));

            if (!string.IsNullOrEmpty(gameIconInput.Text))
            {
                songInfo.Keys.AddKey("GameIcon", gameIconInput.Text);
            }
            if (!string.IsNullOrEmpty(gameCategoryInput.Text))
            {
                songInfo.Keys.AddKey("GameCategory", gameCategoryInput.Text);
            }
            if (!string.IsNullOrEmpty(bandInput.Text))
            {
                songInfo.Keys.AddKey("Band", bandInput.Text);
            }
            if (useNewClipsCheck.Checked)
            {
                songInfo.Keys.AddKey("UseNewClips", "1");
            }
            if (bSkeletonSelect.Text.ToLower() != DEFAULT && !string.IsNullOrEmpty(bSkeletonSelect.Text))
            {
                songInfo.Keys.AddKey("SkeletonTypeB", bSkeletonSelect.Text);
            }
            if (dSkeletonSelect.Text.ToLower() != DEFAULT && !string.IsNullOrEmpty(dSkeletonSelect.Text))
            {
                songInfo.Keys.AddKey("SkeletonTypeD", dSkeletonSelect.Text);
            }
            if (gSkeletonSelect.Text.ToLower() != DEFAULT && !string.IsNullOrEmpty(gSkeletonSelect.Text))
            {
                songInfo.Keys.AddKey("SkeletonTypeG", gSkeletonSelect.Text);
            }
            if (vSkeletonSelect.Text.ToLower() != DEFAULT && !string.IsNullOrEmpty(vSkeletonSelect.Text))
            {
                songInfo.Keys.AddKey("SkeletonTypeV", vSkeletonSelect.Text);
            }
            if (bassMicCheck.Checked)
            {
                songInfo.Keys.AddKey("MicForBassist", "1");
            }
            if (guitarMicCheck.Checked)
            {
                songInfo.Keys.AddKey("MicForGuitarist", "1");
            }
            if (drumKitSelect.SelectedIndex != -1)
            {
                string drumKit = drumKitSelect.SelectedItem.ToString().Replace(" ", "").ToLower();
                songInfo.Keys.AddKey("DrumKit", drumKit);
            }
            if (Pref.OverrideBeatLines)
            {
                songInfo.Keys.AddKey("Low8Bars", beat8thLow.Value.ToString());
                songInfo.Keys.AddKey("High8Bars", beat8thHigh.Value.ToString());
                songInfo.Keys.AddKey("Low16Bars", beat16thLow.Value.ToString());
                songInfo.Keys.AddKey("High16Bars", beat16thHigh.Value.ToString());
            }
            songInfo.Keys.AddKey("Cents", ((int)vocalTuningCents.Value).ToString("G0", Murica));
            songInfo.Keys.AddKey("WhammyCutoff", sustainThreshold.Value.ToString("G2", Murica));
            songInfo.Keys.AddKey("VocalsScrollSpeed", vocalScrollSpeed.Value.ToString("G2", Murica));

            if (modernStrobesCheck.Checked)
            {
                songInfo.Keys.AddKey("ModernStrobes", "1");
            }

            wtdeIni.Sections.Add(modInfo);
            wtdeIni.Sections.Add(songInfo);

            return wtdeIni;
        }
        private string BassistName()
        {
            if (CurrentGame == GAME_GHA)
            {
                return "Default";
            }
            string bassist = bassist_select_gh3.Text;
            if (bassist == "Tom Morello")
            {
                return "Morello";
            }
            else if (bassist == "Lou")
            {
                return "Satan";
            }
            else if (bassist == "God of Rock/Metalhead")
            {
                return CurrentPlatform == CONSOLE_PS2 ? "Metalhead" : "RockGod";
            }
            else if (bassist == "Grim Ripper/Elroy")
            {
                return CurrentPlatform == CONSOLE_PS2 ? "Elroy" : "Ripper";
            }
            return bassist;
        }
        private string SingerName()
        {
            string singer = vocal_gender_select_gh3.Text;
            if (singer == "Bret Michaels")
            {
                return "Bret";
            }
            return singer;
        }
        private void AddToPCSetlist()
        {
            var songListEntry = GenerateGh3SongListEntry();
            var (pakData, pabData) = AddToDownloadList(GetGh3PakFile(CurrentGame), CurrentPlatform, [songListEntry]);
            OverwriteGh3Pak(pakData, pabData!, CurrentGame);
        }
        private void CreateConsoleFilesGh3()
        {
            var otherChecksum = $"download\\dl{ConsoleChecksum}.qb";
            Directory.CreateDirectory(ConsoleCompile);
            CreateConsoleDownloadFilesGh3(ConsoleChecksum, CurrentGame, CurrentPlatform, ConsoleCompile, ResourcePath, [GenerateGh3SongListEntry()]);
            //CreateConsoleDownloadScriptsGh3();
            // text pak is download\download_song{x}.qb where x is the checksum
            // other pak is download\dl{x}.qb where x is the checksum
        }

        private void CreateConsoleFilesGh3Ps2()
        {

            var dummyText = "\\\\Dummy file - just here to fix dependencies.\r\n";
            var hopoOverride = (float)NsHopoVal.Value;
            Metadata = PackageMetadata(hopoValOverride: hopoOverride);
            var songListEntry = Metadata.GenerateGh3SongListEntry(CurrentGame, CurrentPlatform);
            var setlistItem = new QB.QBItem((string)songListEntry["checksum"], songListEntry);

            var ps2Compile = Path.Combine(compile_input.Text, "PS2 Compile");
            Directory.CreateDirectory(ps2Compile);
            var ps2SkaFiles = Path.Combine(compile_input.Text, "PS2 SKA Files");
            var ps2PakFile = Path.Combine(compile_input.Text, $"{song_checksum.Text}.pak.ps2");
            var ps2Msv = Path.Combine(compile_input.Text, "output.msv");
            var ps2MsvCoop = Path.Combine(compile_input.Text, "output_coop.msv");
            var ps2MsvPreview = Path.Combine(compile_input.Text, "preview.msv");
            var spChecksum = CRC.QBKey(song_checksum.Text).Replace("0x", "").ToUpper();
            var mpChecksum = CRC.QBKey($"{song_checksum.Text}_coop").Replace("0x", "").ToUpper();
            var spPath = Path.Combine(ps2Compile, "MUSIC", spChecksum.Substring(0, 1));
            var mpPath = Path.Combine(ps2Compile, "MUSIC", mpChecksum.Substring(0, 1));

            var setlistSave = Path.Combine(ps2Compile, "setlist.q");
            QB.QbToText([setlistItem], setlistSave);
            if (Directory.Exists(ps2SkaFiles))
            {
                var finalSka = Path.Combine(ps2Compile, "WAD", "custom_songs", "ska", Metadata.Checksum);
                Directory.CreateDirectory(finalSka);
                foreach (var file in Directory.GetFiles(ps2SkaFiles))
                {
                    var newSkaPath = Path.Combine(finalSka, Path.GetFileName(file));
                    var relSkaPath = Path.GetRelativePath(Path.Combine(ps2Compile, "WAD"), newSkaPath);
                    relSkaPath = relSkaPath.Substring(0, relSkaPath.IndexOf(".ps2", StringComparison.InvariantCultureIgnoreCase));
                    Metadata.AddPs2ScriptEntry(relSkaPath);
                    File.Move(file, newSkaPath, true);
                }
                var allanimsSave = Path.Combine(ps2Compile, "allanims.q");
                Metadata.SavePs2Script(allanimsSave);
                Directory.Delete(ps2SkaFiles);
            }
            if (File.Exists(ps2PakFile))
            {
                var songsFolder = Path.Combine(ps2Compile, "WAD", "songs");
                Directory.CreateDirectory(songsFolder);
                File.Move(ps2PakFile, Path.Combine(songsFolder, Path.GetFileName(ps2PakFile)), true);
                File.WriteAllText(Path.Combine(songsFolder, $"{song_checksum.Text}_gfx.pak.ps2"), dummyText);
                File.WriteAllText(Path.Combine(songsFolder, $"{song_checksum.Text}_sfx.pak.ps2"), dummyText);
            }
            if (File.Exists(ps2Msv))
            {
                Directory.CreateDirectory(spPath);
                File.Move(ps2Msv, Path.Combine(spPath, Path.GetFileName(ps2Msv).Replace("output.msv", $"{spChecksum}.IMF")), true);
            }
            if (File.Exists(ps2MsvCoop))
            {
                Directory.CreateDirectory(mpPath);
                File.Move(ps2MsvCoop, Path.Combine(mpPath, Path.GetFileName(ps2MsvCoop).Replace("output_coop.msv", $"{mpChecksum}.IMF")), true);
            }
            if (File.Exists(ps2MsvPreview))
            {
                Directory.CreateDirectory(spPath);
                File.Move(ps2MsvPreview, Path.Combine(spPath, Path.GetFileName(ps2Msv).Replace("output.msv", $"{spChecksum}.ISF")), true);
            }
        }
        private void CreateConsolePackage()
        {
            
            if (CurrentGame == GAME_GH3 || CurrentGame == GAME_GHA)
            {
                IsImport = midi_file_input_gh3.Text.ToLower().EndsWith(".q");
                float hopoValOverride = IsImport ? (float)NsHopoVal.Value : 500f;
                Metadata = PackageMetadata(false, hopoValOverride, IsImport);
            }

            Metadata.CreateConsolePackage(CurrentGame, CurrentPlatform, ConsoleCompile, ResourcePath, Pref.OnyxCliPath);
        }
        private async Task CompileGh3Audio()
        {
            if (CurrentPlatform == CONSOLE_PS2)
            {
                var msv = new MSV();
                string[] backingPaths = backing_input_gh3.Items.Cast<string>().ToArray();
                string[] allPaths = backingPaths.Concat([guitar_input_gh3.Text, rhythm_input_gh3.Text]).ToArray();
                string[] coopBackingPaths = coop_backing_input_gh3.Items.Cast<string>().ToArray();
                string outputFolder = Path.Combine(compile_input.Text);

                decimal previewStart = previewStartTime / 1000m;
                decimal previewLength = previewEndTime / 1000m;
                if (gh3_set_end.Checked)
                {
                    previewLength -= previewStart;
                }
                decimal fadeIn = UserPreferences.Default.PreviewFadeIn;
                decimal fadeOut = UserPreferences.Default.PreviewFadeOut;
                var previewSave = Path.Combine(outputFolder, "preview.wav");

                var audioTask = msv.CreatePs2Msv(guitar_input_gh3.Text, rhythm_input_gh3.Text, backingPaths, coop_guitar_input_gh3.Text, coop_rhythm_input_gh3.Text, coopBackingPaths, outputFolder, 33075);
                var previewTask = msv.MakePreviewPs2(allPaths, previewSave, previewStart, previewLength, fadeIn, fadeOut, previewVolumeGh3.Value, 33075);


                await previewTask;

                await msv.CreatePs2Preview(previewSave);

                await audioTask;
            }
            else
            {
                await CompileGh3ModernConsoles();
            }

        }
        private async Task CompileGh3ModernConsoles()
        {
            string fileName = GetSongChecksum();
            string gtrOutput = Path.Combine(compile_input.Text, $"{fileName}_guitar.mp3");
            string rhythmOutput = Path.Combine(compile_input.Text, $"{fileName}_rhythm.mp3");
            string backingOutput = Path.Combine(compile_input.Text, $"{fileName}_song.mp3");
            string coopGtrOutput = Path.Combine(compile_input.Text, $"{fileName}_coop_guitar.mp3");
            string coopRhythmOutput = Path.Combine(compile_input.Text, $"{fileName}_coop_rhythm.mp3");
            string coopBackingOutput = Path.Combine(compile_input.Text, $"{fileName}_coop_song.mp3");
            string crowdOutput = Path.Combine(compile_input.Text, $"{fileName}_crowd.mp3");
            string previewOutput = Path.Combine(compile_input.Text, $"{fileName}_preview.mp3");
            string[] spFiles = { gtrOutput, rhythmOutput, backingOutput };
            string[] coopFiles = { coopGtrOutput, coopRhythmOutput, coopBackingOutput };
            var filesToProcess = new List<string>();
            filesToProcess.AddRange(spFiles);
            filesToProcess.AddRange(coopFiles);
            filesToProcess.Add(crowdOutput);
            filesToProcess.Add(previewOutput);
            string fsbOutput = Path.Combine(compile_input.Text, GetSongChecksum());
            try
            {
                Console.WriteLine("Compiling Audio...");
                string[] backingPaths = backing_input_gh3.Items.Cast<string>().ToArray();

                string[] coopBackingPaths = coop_backing_input_gh3.Items.Cast<string>().ToArray();

                FSB fsb = new FSB();

                Task gtrStem = fsb.ConvertToMp3(guitar_input_gh3.Text, gtrOutput);
                Task rhythmStem = fsb.ConvertToMp3(rhythm_input_gh3.Text, rhythmOutput);
                Task backingStem = fsb.MixFiles(backingPaths, backingOutput);

                var tasksToAwait = new List<Task> { gtrStem, rhythmStem, backingStem };
                if (CurrentGame == GAME_GHA && File.Exists(crowd_input_gh3.Text))
                {
                    Task crowdStem = fsb.ConvertToMp3(crowd_input_gh3.Text, crowdOutput);
                    tasksToAwait.Add(crowdStem);
                }
                if (coop_audio_check.Checked)
                {
                    Task coopGtrStem = fsb.ConvertToMp3(coop_guitar_input_gh3.Text, coopGtrOutput);
                    Task coopRhythmStem = fsb.ConvertToMp3(coop_rhythm_input_gh3.Text, coopRhythmOutput);
                    Task coopBackingStem = fsb.MixFiles(coopBackingPaths, coopBackingOutput);
                    tasksToAwait.AddRange(new List<Task> { coopGtrStem, coopRhythmStem, coopBackingStem });
                }


                // Await all started tasks. This ensures all conversions are completed before moving on.
                await Task.WhenAll(tasksToAwait.ToArray());

                // Create the preview audio
                if (gh3_rendered_preview_check.Checked && File.Exists(preview_audio_input_gh3.Text))
                {
                    Task previewStem = fsb.ConvertToMp3(preview_audio_input_gh3.Text, previewOutput);
                    await previewStem;
                }
                else
                {
                    decimal previewStart = previewStartTime / 1000m;
                    decimal previewLength = previewEndTime / 1000m;
                    if (gh3_set_end.Checked)
                    {
                        previewLength -= previewStart;
                    }

                    decimal fadeIn = UserPreferences.Default.PreviewFadeIn;
                    decimal fadeOut = UserPreferences.Default.PreviewFadeOut;
                    Task previewStem = fsb.MakePreview(spFiles, previewOutput, previewStart, previewLength, fadeIn, fadeOut, previewVolumeGh3.Value);
                    await previewStem;
                }
                Console.WriteLine("Combining Audio...");
                var (fsbOut, datOut) = fsb.CombineFSB3File(filesToProcess, fsbOutput);
                if (isExport)
                {
                    File.Move(fsbOut, Path.Combine(ConsoleCompile, $"{fileName}.fsb"), true);
                    File.Move(datOut, Path.Combine(ConsoleCompile, $"{fileName}.dat"), true);
                }
                else if (isAudioCompile)
                {

                }
                else if (CurrentPlatform == "PC")
                {
                    MoveToGh3MusicFolder(fsbOut);
                    MoveToGh3MusicFolder(datOut);
                }
                else if (CurrentPlatform == "PS2")
                {

                }
                else
                {
                    File.Move(fsbOut, Path.Combine(ConsoleCompile, $"dlc{ConsoleChecksum}.fsb"), true);
                    File.Move(datOut, Path.Combine(ConsoleCompile, $"dlc{ConsoleChecksum}.dat"), true);
                }
                Console.WriteLine("Audio Compilation Complete!");
            }
            catch (Exception ex)
            {
                HandleException(ex, "Audio Compilation Failed!");
                throw;
            }
            finally
            {

                foreach (string file in filesToProcess)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
        private async Task CompileGhwtAudio(bool encrypt = false)
        {
            string songChecksum = GetSongChecksum();
            string drumsKickOutput = Path.Combine(compile_input.Text, $"{songChecksum}_drumsKick.mp3");
            string drumsSnareOutput = Path.Combine(compile_input.Text, $"{songChecksum}_drumsSnare.mp3");
            string drumsTomsOutput = Path.Combine(compile_input.Text, $"{songChecksum}_drumsToms.mp3");
            string drumsCymbalOutput = Path.Combine(compile_input.Text, $"{songChecksum}_drumsCymbal.mp3");

            string guitarOutput = Path.Combine(compile_input.Text, $"{songChecksum}_guitar.mp3");
            string rhythmOutput = Path.Combine(compile_input.Text, $"{songChecksum}_rhythm.mp3");
            string vocalsOutput = Path.Combine(compile_input.Text, $"{songChecksum}_vocals.mp3");

            string crowdOutput = Path.Combine(compile_input.Text, $"{songChecksum}_crowd.mp3");
            string backingOutput = Path.Combine(compile_input.Text, $"{songChecksum}_song.mp3");

            string previewOutput = Path.Combine(compile_input.Text, $"{songChecksum}_preview.mp3");

            string[] drumFiles = { drumsKickOutput, drumsSnareOutput, drumsTomsOutput, drumsCymbalOutput };
            string[] otherFiles = { guitarOutput, rhythmOutput, vocalsOutput };
            string[] backingFiles = { backingOutput, crowdOutput };

            var filesToProcess = new List<string>();
            filesToProcess.AddRange(drumFiles);
            filesToProcess.AddRange(otherFiles);
            filesToProcess.AddRange(backingFiles);
            filesToProcess.Add(previewOutput);

            string fsbOutput = Path.Combine(compile_input.Text, $"{songChecksum}");
            try
            {
                Console.WriteLine("Compiling Audio...");
                //string[] backingPaths = backingInput.Items.Cast<string>().ToArray();
                string[] backingPaths = backingInput.Items.Cast<string>()
                    .ToArray();

                FSB fsb = new FSB();

                Task drums1Stem = fsb.ConvertToMp3(kickInput.Text, drumsKickOutput);
                Task drums2Stem = fsb.ConvertToMp3(snareInput.Text, drumsSnareOutput);
                Task drums3Stem = fsb.ConvertToMp3(cymbalsInput.Text, drumsCymbalOutput);
                Task drums4Stem = fsb.ConvertToMp3(tomsInput.Text, drumsTomsOutput);

                Task guitarStem = fsb.ConvertToMp3(guitarInput.Text, guitarOutput);
                Task rhythmStem = fsb.ConvertToMp3(bassInput.Text, rhythmOutput);
                Task vocalsStem = fsb.ConvertToMp3(vocalsInput.Text, vocalsOutput);

                Task backingStem = fsb.MixFiles(backingPaths, backingOutput);
                Task crowdStem = fsb.ConvertToMp3(crowdInput.Text, crowdOutput);

                var tasksToAwait = new List<Task> { drums1Stem, drums2Stem, drums3Stem, drums4Stem, guitarStem, rhythmStem, vocalsStem, backingStem, crowdStem };

                // Await all started tasks. This ensures all conversions are completed before moving on.
                await Task.WhenAll(tasksToAwait.ToArray());

                // Create the preview audio
                if (renderedPreviewCheck.Checked && File.Exists(previewInput.Text))
                {
                    Task previewStem = fsb.ConvertToMp3(previewInput.Text, previewOutput);
                    await previewStem;
                }
                else
                {
                    string[] previewFiles = { drumsKickOutput, drumsSnareOutput, drumsCymbalOutput, drumsTomsOutput, guitarOutput, rhythmOutput, vocalsOutput, backingOutput };
                    decimal previewStart = previewStartTime / 1000m;
                    decimal previewLength = previewEndTime / 1000m;
                    if (setEndTime.Checked)
                    {
                        previewLength -= previewStart;
                    }
                    decimal fadeIn = UserPreferences.Default.PreviewFadeIn;
                    decimal fadeOut = UserPreferences.Default.PreviewFadeOut;
                    Task previewStem = fsb.MakePreview(previewFiles, previewOutput, previewStart, previewLength, fadeIn, fadeOut, previewVolume.Value);
                    await previewStem;
                }
                Console.WriteLine("Combining Audio...");
                var fsbList = fsb.CombineFSB4File(drumFiles, otherFiles, backingFiles, [previewOutput], fsbOutput);

                if (CurrentPlatform == "PC" && !isAudioCompile)
                {
                    foreach (string file in fsbList)
                    {
                        File.Move(file, Path.Combine(MusicFolder, $"{Path.GetFileName(file)}.xen"), true);
                    }
                }
                Console.WriteLine("Audio Compilation Complete!");
            }
            catch (Exception ex)
            {
                HandleException(ex, "Audio Compilation Failed!");
                throw;
            }
            finally
            {
                foreach (string file in filesToProcess)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
        private int GetAudioLength()
        {
            var fsb = new FSB();
            var backing = backingInput.Items.Cast<string>().ToArray();
            var allAudio = new List<string> { kickInput.Text, snareInput.Text, cymbalsInput.Text, tomsInput.Text, guitarInput.Text, bassInput.Text, vocalsInput.Text };
            allAudio.AddRange(backing);
            int duration = 0;
            foreach (string audio in allAudio)
            {
                try
                {
                    var timespan = fsb.GetAudioDuration(audio);
                    duration = Math.Max(duration, (int)Math.Round(timespan.TotalSeconds));
                }
                catch
                {

                }

            }
            return duration;
        }
        private void ConvertLipsyncToWT()
        {

            string lipSyncPath = gh3SkaFilesInput.Text;
            string skaPath = skaFilesInput.Text;
            if (!Directory.Exists(skaFilesInput.Text))
            {
                skaFilesInput.Text = lipSyncPath + "-temp";
                skaPath = skaFilesInput.Text;
                Directory.CreateDirectory(skaPath);
            }

            if (Directory.Exists(lipSyncPath))
            {

                foreach (string file in Directory.GetFiles(lipSyncPath, "*.ska*", SearchOption.AllDirectories))
                {
                    string relPath = Path.GetRelativePath(lipSyncPath, file);
                    string skaFile = Path.Combine(skaPath, relPath);
                    var skaBytes = new SkaFile(file, "big");
                    float multiplier = skaFileSource.SelectedIndex;
                    if (multiplier == 0)
                    {
                        multiplier = 1f;
                    }
                    if (File.Exists(skaFile))
                    {
                        File.Delete(skaFile);
                    }
                    File.WriteAllBytes(skaFile, skaBytes.WriteModernStyleSka(SKELETON_WT_ROCKER, CurrentGame, multiplier));
                }
            }
        }
        private async Task CompileAll()
        {
            Console.WriteLine($"Compiling chart and audio for {CurrentGame}");
            SetConsoleChecksum();
            string compileText = compile_all_button.Text;
            compile_all_button.Text = COMPILING;
            DisableCloseButton();
            bool compileSuccess = false;
            bool pakSuccess = false;
            try
            {
                var time1 = DateTime.Now;
                if (CurrentGame == GAME_GH3 || CurrentGame == GAME_GHA)
                {
                    pakSuccess = CompilePakGh3();
                    if (pakSuccess)
                    {
                        await CompileGh3Audio();
                        compileSuccess = true;
                    }
                }
                else if (CurrentGame == GAME_GHWT)
                {
                    pakSuccess = CompilePakGhwt();
                    if (pakSuccess)
                    {
                        await CompileGhwtAudio();
                        compileSuccess = true;
                    }
                }
                else
                {
                    pakSuccess = CompilePakGh5();
                    if (pakSuccess)
                    {
                        await CompileGhwtAudio(true);
                        compileSuccess = true;
                    }
                    MoveGh5Files();
                    (SongList, QsStrings) = Metadata.GenerateGh5SongListEntry();
                    CreateConsoleDownloadFilesGh5(ConsoleChecksum, CurrentGame, CurrentPlatform, ConsoleCompile, ResourcePath, SongList, QsStrings, Metadata.PackageName);
                }
                if (!isExport && compileSuccess && (CurrentPlatform == "PS3" || CurrentPlatform == platform_360.Text))
                {
                    CreateConsolePackage();
                }
                else if (compileSuccess && CurrentPlatform == CONSOLE_PS2)
                {
                    CreateConsoleFilesGh3Ps2();
                }
                else if (isExport)
                {
                    Console.WriteLine("Packing up the song for export...");
                    GHTCP.MakeUnprotectedZip(ConsoleCompile, Path.Combine(compile_input.Text, $"{GetSongChecksum()}.sgh"));
                }
                var time2 = DateTime.Now;

                var timeDiff = time2 - time1;
                string process = compileSuccess ? (isExport ? "Exporting took" : "Chart compilation took") : "Compilation failed after";
                Console.WriteLine($"{process} {timeDiff.TotalSeconds.ToString("G3")} seconds");
            }
            catch (Exception ex)
            {
                HandleException(ex, "Compile Failed!");
            }
            finally
            {
                EnableCloseButton();
                compile_all_button.Text = compileText;
                if (Pref.ShowPostCompile && compileSuccess)
                {
                    ShowPostCompile();
                }
            }
        }
        private void PreChecks()
        {
            SaveProject();
            PreCompileCheck();
        }
        private bool CompilePakGh3()
        {
            bool success = false;
            try
            {
                PreChecks();
                CompileGh3PakFile();
                success = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                string errorMessage = "Compilation has failed due to one or more files having \"Read-Only\" permission. " +
                    "To be able to compile, the Toolkit needs to run a separate tool which requires Administrator permissions.\n\n" +
                    "Pressing OK will launch this tool, and will ask for your permission to run it in Administrator mode.\n\n" +
                    "Otherwise, click Cancel, go to the file path the next Error Box mentions and remove Read-Only mode from it.\n\n" +
                    "You will need to re-compile afterwards for either method used.";
                var nextSteps = MessageBox.Show(errorMessage, "Could not access file", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (nextSteps == DialogResult.OK)
                {
                    string removePath = Path.Combine(ExeDirectory, "Tools", "RemoveReadOnly", "RemoveReadOnly.exe");
                    string gamePath = GetGh3Folder(CurrentGame);
                    ProcessStartInfo startInfo = new ProcessStartInfo(removePath);
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Normal;
                    startInfo.ArgumentList.Add(gamePath);
                    try
                    {
                        // Start the process with the info we specified.
                        // Call WaitForExit and then the using statement will close.
                        using (Process exeProcess = Process.Start(startInfo))
                        {
                            exeProcess.WaitForExit();
                        }
                        MessageBox.Show("Read-Only permissions have been removed from the game folder. Please re-compile the song.", "RemoveReadOnly Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message, "RemoveReadOnly Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    HandleException(ex, "Compile Failed!");
                }
            }
            catch (MidiCompileException ex)
            {
                MidiFailException(ex);
            }
            catch (SkaFileParseException ex)
            {
                SkaFailException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Compile Failed!");
            }
            return success;
        }
        private bool CompilePakGhwt()
        {
            bool success = false;
            try
            {
                PreChecks();
                ConvertLipsyncToWT();
                CompileGhwtPakFile();
                success = true;
            }
            catch (MidiCompileException ex)
            {
                MidiFailException(ex);
            }
            catch (SkaFileParseException ex)
            {
                SkaFailException(ex);
            }
            catch (Exception ex)
            {
                HandleException(ex, "Compile Failed!");
            }
            return success;
        }
        private bool CompilePakGh5(bool ghwor = true)
        {
            bool success = false;
            try
            {
                PreChecks();
                ConvertLipsyncToWT();
                CompileGh5PakFile();
                success = true;
            }
            catch (MidiCompileException ex)
            {
                MidiFailException(ex);
            }
            catch (SkaFileParseException ex)
            {
                SkaFailException(ex);

            }
            catch (Exception ex)
            {
                HandleException(ex, "Compile Failed!");
            }
            return success;
        }
        private void MoveGh5Files()
        {
            Directory.CreateDirectory(ConsoleCompile);
            string currCheck = GetSongChecksum();

            int duration = 0;

            File.Copy(PakFilePath, Path.Combine(ConsoleCompile, $"b{currCheck}_song.pak"), true);
            for (int i = 1; i < 4; i++)
            {
                string audio = Path.Combine(compile_input.Text, $"{currCheck}_{i}.fsb");
                if (!File.Exists(audio))
                {
                    throw new FileNotFoundException($"Missing audio file {audio} for download file creation.");
                }
                if (duration == 0)
                {
                    var fileInfo = new FileInfo(audio);
                    var length = fileInfo.Length - 128; // Data starts at 128
                    duration = (int)Math.Round(length / 4 / 384 * 1152 / 48000f);
                }
                var encryptString = Path.GetFileNameWithoutExtension(audio);
                var encryptedAudio = EncryptDecrypt.EncryptFSB4(File.ReadAllBytes(audio), encryptString);
                var savePath = Path.Combine(ConsoleCompile, $"a{currCheck}_{i}.fsb");
                File.WriteAllBytes(savePath, encryptedAudio);
                //File.Copy(audio, Path.Combine(ConsoleCompile, $"a{currCheck}_{i}.fsb"), true);
            }
            Metadata.Duration = duration;
            if (!File.Exists(Path.Combine(compile_input.Text, $"{currCheck}_preview.fsb")))
            {
                throw new FileNotFoundException($"Missing preview audio file {currCheck}_preview.fsb for download file creation.");
            }
            var previewPath = Path.Combine(compile_input.Text, $"{currCheck}_preview.fsb");
            var previewSave = Path.Combine(ConsoleCompile, $"a{currCheck}_preview.fsb");
            var previewEncryptString = Path.GetFileNameWithoutExtension(previewPath);
            File.WriteAllBytes(previewSave, EncryptDecrypt.EncryptFSB4(File.ReadAllBytes(previewPath), previewEncryptString));
        }
        private async Task CompilePaksAsync()
        {

            Console.WriteLine($"Compiling song for {CurrentGame}");
            SetConsoleChecksum();
            var time1 = DateTime.Now;
            bool success = false;
            if (CurrentGame == GAME_GH3 || CurrentGame == GAME_GHA)
            {
                success = CompilePakGh3();
            }
            else if (CurrentGame == GAME_GHWT)
            {
                success = CompilePakGhwt();
            }
            else
            {
                success = CompilePakGh5();
                if (success)
                {
                    MoveGh5Files();
                    (SongList, QsStrings) = Metadata.GenerateGh5SongListEntry();
                    CreateConsoleDownloadFilesGh5(ConsoleChecksum, CurrentGame, CurrentPlatform, ConsoleCompile, ResourcePath, SongList, QsStrings, Metadata.PackageName);
                }
            }

            if (success)
            {
                if (CurrentPlatform == "PS3" || CurrentPlatform == platform_360.Text)
                {
                    try
                    {
                        CreateConsolePackage();
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex, "Console Package Creation Failed!");
                        success = false;
                    }
                }
                else if (CurrentPlatform == CONSOLE_PS2)
                {
                    CreateConsoleFilesGh3Ps2();
                }
            }
            var time2 = DateTime.Now;
            // Calculate the time it took to compile the song
            var timeDiff = time2 - time1;
            string process = success ? "Chart compilation took" : "Compilation failed after";
            Console.WriteLine($"{process} {timeDiff.TotalSeconds.ToString("G3")} seconds");
            if (Pref.ShowPostCompile && success)
            {
                ShowPostCompile();
            }
        }
        private async void compile_pak_button_Click(object sender, EventArgs e)
        {
            IsImport = false;
            await TaskWithFilePathUpdates(CompilePaksAsync);
        }
        private async void compile_all_button_Click(object sender, EventArgs e)
        {
            IsImport = false;
            await TaskWithFilePathUpdates(CompileAll);
        }
        private async Task TaskWithFilePathUpdates(Func<Task> action)
        {
            SetAllToAbsolute();
            await action();
            SetAllToRelative();
        }
        private void ShowPostCompile()
        {
            if (isExport)
            {
                MessageBox.Show("Export has completed successfully!\n\nYour song has been packaged up and is ready to be shared with others.\n\nIt can be found where you defined the song to be compiled to or next to your .ghproj file.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (CurrentPlatform == platform_pc.Text)
            {
                MessageBox.Show("Compilation has completed successfully!\n\nYour song has been added to the game and can be played immediately.", "Compilation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Compilation has completed successfully!\n\nYour song has been packaged up and is ready to be installed on your console.\n\nIt can be found where you defined the song to be compiled to or next to your .ghproj file.\n\nDon't forget to add it to your custom cache!", "Compilation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Toolstrip Logic

        private void ClearListBoxes()
        {
            backing_input_gh3.Items.Clear();
            coop_backing_input_gh3.Items.Clear();
            backingInput.Items.Clear();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = ghprojFileFilter;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    project_input.Text = openFileDialog.FileName;
                    LoadProject(project_input.Text);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProject(DefaultTemplatePath);
        }
        private void saveTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = ghprojFileFilter;
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = false;
                saveFileDialog.InitialDirectory = DefaultTemplateFolder;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = saveFileDialog.FileName;
                    var data = makeSaveClass();
                    data.projectPath = "";
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(filePath, json);
                }
            }
        }
        private void loadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = ghprojFileFilter;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;
                openFileDialog.InitialDirectory = DefaultTemplateFolder;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    LoadProject(filePath);
                    project_input.Text = "";
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a modal window for the preferences panel
            var prefWindow = new ProgramSettings(TabType.CompileSong);
            prefWindow.ShowDialog();
            SetBeatLines();
        }

        private void artist_text_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (artist_text_select.Text == "Other")
            {
                artistTextCustom.Enabled = true;
            }
            else
            {
                artistTextCustom.Enabled = false;
            }
        }
        private void UpdateNsValue()
        {

        }
        private void HmxHopoVal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void renderedPreviewCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange)
            {
                return;
            }

            previewAudioLabel.Enabled = renderedPreviewCheck.Checked;
            previewInput.Enabled = renderedPreviewCheck.Checked;
            previewSelect.Enabled = renderedPreviewCheck.Checked;

            previewLabel.Enabled = !renderedPreviewCheck.Checked;
            previewMinutes.Enabled = !renderedPreviewCheck.Checked;
            previewSeconds.Enabled = !renderedPreviewCheck.Checked;
            previewMills.Enabled = !renderedPreviewCheck.Checked;
            lengthLabel.Enabled = !renderedPreviewCheck.Checked;
            lengthMinutes.Enabled = !renderedPreviewCheck.Checked;
            lengthSeconds.Enabled = !renderedPreviewCheck.Checked;
            lengthMills.Enabled = !renderedPreviewCheck.Checked;
            setEndTime.Enabled = !renderedPreviewCheck.Checked;
        }

        private void setEndTime_CheckedChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange)
            {
                return;
            }
            gh3_set_end.Checked = setEndTime.Checked;
        }

        private void genre_input_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange || isLoading)
            {
                return;
            }
            gameSelectedGenres[CurrentGame] = genre_input.SelectedIndex;
        }

        private void drumKitSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProgrammaticChange || isLoading)
            {
                return;
            }
            try
            {
                gameDrumKits[CurrentGame] = drumKitSelect.SelectedItem.ToString();
            }
            catch
            {

            }

        }

        private void import_from_other_Click(object sender, EventArgs e)
        {
            // Open a folder choosing dialog to select a folder
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the Clone Hero song folder you want to import.";
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;
                    LoadFromChFolder(folderPath);
                }
            }
        }

        private void vocal_gender_select_gh3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vocal_gender_select_gh3.SelectedIndex == 4)
            {
                aerosmithBand.Enabled = true;
                if (aerosmithBand.SelectedIndex == -1)
                {
                    aerosmithBand.SelectedIndex = 0;
                }
            }
            else
            {
                aerosmithBand.Enabled = false;
            }
        }

        private async void exportSongArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentGame != GAME_GH3)
            {
                MessageBox.Show("Exporting song archives is currently only available for Guitar Hero III songs.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isExport = true;
            await TaskWithFilePathUpdates(CompileAll);
            isExport = false;
        }

        private async void compileAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
            ConsoleStringCheck();
            isAudioCompile = true;
            if (CurrentGame == GAME_GH3 || CurrentGame == GAME_GHA)
            {
                await CompileGh3Audio();
            }
            else if (CurrentGame == GAME_GHWT)
            {
                await CompileGhwtAudio();
            }
            else
            {
                await CompileGhwtAudio(true);
            }
            isAudioCompile = false;
        }

    }
}
