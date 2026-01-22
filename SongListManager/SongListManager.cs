using GH_Toolkit_Core.Methods;
using GH_Toolkit_Core.QB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GH_Toolkit_Core.Methods.CreateForGame;
using static GH_Toolkit_Core.PAK.PAK;
using static GH_Toolkit_Core.QB.QB;
using static GH_Toolkit_Core.QB.QBArray;
using static GH_Toolkit_Core.QB.QBConstants;
using static GH_Toolkit_Core.QB.QBStruct;
using static GH_Toolkit_GUI.PreCompileChecks;
using GH_Toolkit_Core.PAK;
using static GH_Toolkit_Exceptions.Exceptions;
using GH_Toolkit_Core.PS360;

namespace GH_Toolkit_GUI
{
    public partial class SongListManager : Form
    {
        private readonly string sghFileFilter = "SGH Files (*.sgh)|*.sgh|Zip Files (*.zip)|*.zip|All files (*.*)|*.*";
        private Dictionary<string, QBStruct.QBStructData> MasterList = new Dictionary<string, QBStruct.QBStructData>();
        private static UserPreferences Pref = UserPreferences.Default;
        private string Game;
        private string PakFile;
        private Dictionary<string, PakEntry> QbPak;
        private PakCompiler Compiler;
        private PakEntry Songlist;
        private Dictionary<string, QBItem> SongListEntries;
        private QBArrayNode DlSongList;
        private QBStructData DlSongListProps;
        private PakEntry? DownloadQb;
        private Dictionary<string, QBItem>? DownloadQbEntries;
        private QBStructData DownloadList;
        private QBStructData Tier1;
        private QBArrayNode SongArray;
        private string SghPath = "";
        private string SghFolder = "";
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
            if (gh3Radio.Checked)
            {
                Game = GAME_GH3;
            }
            else
            {
                Game = GAME_GHA;
            }
            LoadSetlist();
        }

        private void loadSetlist_Click(object sender, EventArgs e)
        {
            LoadSetlistHelper();
        }

        private void loadSetlist2_Click(object sender, EventArgs e)
        {
            LoadSetlistHelper();
        }

        private void importSghFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = sghFileFilter;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SghPath = dialog.FileName;
                }
                else
                {
                    return;
                }
                LoadSGH();
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            ConvertSongs();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void selectNoneButton_Click(object sender, EventArgs e)
        {
            SelectNone();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void exportToSgh_Click(object sender, EventArgs e)
        {
            ExportSongs();
        }

        private void deleteSelected_Click(object sender, EventArgs e)
        {
            DeleteSongs();
        }

        private void restoreSetlistButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to restore the original DLC setlist? This will remove all custom songs from your setlist.", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            if (consoleSelect.SelectedIndex == 0)
            {
                SetAllOptions(true);
                ghaRadio.Enabled = true;
                gh3Radio.Checked = true;
            }
            else if (consoleSelect.SelectedIndex == 1)
            {
                SetImportOptions(true);
                gh3Radio.Checked = true;
            }
            else if (consoleSelect.SelectedIndex == 2)
            {
                SetImportOptions(true);
                gh3Radio.Checked = true;
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
