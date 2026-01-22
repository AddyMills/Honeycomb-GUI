using System.Collections.Generic;
using System.Windows.Forms;
using GH_Toolkit_Core.QB;
using static GH_Toolkit_Core.Methods.CreateForGame;
using static GH_Toolkit_Core.PAK.PAK;
using static GH_Toolkit_Core.QB.QB;
using static GH_Toolkit_Core.QB.QBArray;
using static GH_Toolkit_Core.QB.QBConstants;
using static GH_Toolkit_Core.QB.QBStruct;
using static GH_Toolkit_GUI.PreCompileChecks;
using GH_Toolkit_Core.PAK;

namespace GH_Toolkit_GUI
{
    public partial class SongListManager : Form
    {
        private readonly string sghFileFilter = "SGH Files (*.sgh)|*.sgh|Zip Files (*.zip)|*.zip|All files (*.*)|*.*";
        private readonly Dictionary<string, QBStructData> MasterList = new();
        private static readonly UserPreferences Pref = UserPreferences.Default;
        
        private string Game = GAME_GH3;
        private string PakFile = string.Empty;
        private Dictionary<string, PakEntry> QbPak = new();
        private PakCompiler Compiler = null!;
        private PakEntry Songlist = null!;
        private Dictionary<string, QBItem> SongListEntries = new();
        private QBArrayNode DlSongList = null!;
        private QBStructData DlSongListProps = null!;
        private PakEntry? DownloadQb;
        private Dictionary<string, QBItem>? DownloadQbEntries;
        private QBStructData DownloadList = null!;
        private QBStructData Tier1 = null!;
        private QBArrayNode SongArray = null!;
        private string SghPath = string.Empty;
        private string SghFolder = string.Empty;
        private bool IsSwitching = false;

        public SongListManager()
        {
            InitializeComponent();
            gh3Radio.Checked = true;
            Game = GAME_GH3;
            consoleSelect.SelectedIndex = 0;
        }
        private void SelectAll()
        {
            for (int i = 0; i < songList.Items.Count; i++)
            {
                songList.SetItemChecked(i, true);
            }
        }
        
        private void SelectNone()
        {
            for (int i = 0; i < songList.Items.Count; i++)
            {
                songList.SetItemChecked(i, false);
            }
        }

        private void LoadSetlistHelper()
        {
            Game = gh3Radio.Checked ? GAME_GH3 : GAME_GHA;
            LoadSetlist();
        }

        private void loadSetlist_Click(object sender, EventArgs e) => LoadSetlistHelper();

        private void loadSetlist2_Click(object sender, EventArgs e) => LoadSetlistHelper();

        private void importSghFile_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = sghFileFilter
            };
            
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            SghPath = dialog.FileName;
            LoadSGH();
        }

        private void convertButton_Click(object sender, EventArgs e) => ConvertSongs();

        private void selectAllButton_Click(object sender, EventArgs e) => SelectAll();

        private void selectNoneButton_Click(object sender, EventArgs e) => SelectNone();

        private void tabControl1_TabIndexChanged(object sender, EventArgs e) => ClearAll();

        private void exportToSgh_Click(object sender, EventArgs e) => ExportSongs();

        private void deleteSelected_Click(object sender, EventArgs e) => DeleteSongs();

        private void restoreSetlistButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to restore the original DLC setlist? This will remove all custom songs from your setlist.",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            
            if (confirm == DialogResult.No)
            {
                MessageBox.Show("Restore cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Gh3PcCheck(Game, true);
            MessageBox.Show("Original BetterGH3 setlist is now restored.", "Setlist Restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetExportOptions(bool enabled)
        {
            exportToSgh.Enabled = enabled;
            loadSetlist2.Enabled = enabled;
        }

        private void SetDeleteOptions(bool enabled)
        {
            loadSetlist.Enabled = enabled;
            deleteSelected.Enabled = enabled;
        }

        private void SetImportOptions(bool enabled)
        {
            importSghFile.Enabled = enabled;
            convertButton.Enabled = enabled;
        }

        private void SetAllOptions(bool enabled)
        {
            SetExportOptions(enabled);
            SetDeleteOptions(enabled);
            SetImportOptions(enabled);
        }

        private void consoleSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsSwitching = true;
            SetAllOptions(false);
            ghaRadio.Enabled = false;
            tabControl1.SelectedIndex = 0;
            
            switch (consoleSelect.SelectedIndex)
            {
                case 0: // PC
                    SetAllOptions(true);
                    ghaRadio.Enabled = true;
                    gh3Radio.Checked = true;
                    break;
                case 1: // Xbox 360
                case 2: // PS3
                    SetImportOptions(true);
                    gh3Radio.Checked = true;
                    break;
            }
            
            IsSwitching = false;
        }

        private void gh3Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (IsSwitching) return;
            
            SetAllOptions(false);
            
            if (ghaRadio.Checked)
            {
                tabControl1.SelectedIndex = 2;
                SetDeleteOptions(true);
            }
            else
            {
                SetAllOptions(true);
            }
        }
    }
}
