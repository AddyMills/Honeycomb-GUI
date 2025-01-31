using GH_Toolkit_Core.PAK;
using static GH_Toolkit_Core.PAK.PAK;


namespace GH_Toolkit_GUI
{
    public partial class PakTools : Form
    {
        public PakTools()
        {
            InitializeComponent();
            //InitializeDragDropTextBox();
            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += ChangeConsole;
            }
            InitializeDragDropTextBox();
        }
        private void InitializeDragDropTextBox()
        {

            pakFilesFolder.AllowDrop = true;
            // Handle DragEnter event
            pakFilesFolder.DragEnter += new DragEventHandler(textBox_DragEnter);
            // Handle DragDrop event
            pakFilesFolder.DragDrop += new DragEventHandler(textBox_DragDrop);

            pakFolderToCompile.AllowDrop = true;
            // Handle DragEnter event
            pakFolderToCompile.DragEnter += new DragEventHandler(textBox_DragEnter);
            // Handle DragDrop event
            pakFolderToCompile.DragDrop += new DragEventHandler(textBox_DragDrop);
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ValidateNames = false; // Allows entering a folder name or selecting a file
                openFileDialog.CheckFileExists = false; // Allows selecting folders
                openFileDialog.CheckPathExists = true; // Ensures the selected path exists

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // If a file is selected, its full path will be returned in FileName.
                    string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);

                    // If the user navigates into a folder without selecting a file, FileName will contain the folder path.
                    if (File.Exists(openFileDialog.FileName))
                    {
                        selectedPath = openFileDialog.FileName;
                    }

                    pakFilesFolder.Text = selectedPath;
                    //SetPakOutput();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pakFolderToCompile.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void ChangeConsole(object sender, EventArgs e)
        {
            // Call SetPakOutput whenever any radio button's checked state changes
            SetPakOutput();
        }
        private void SetPakOutput()
        {
            if (pakFolderToCompile.Text == "")
            {
                pakFileSave.Text = "";
                return;
            }
            else if (!Directory.Exists(pakFolderToCompile.Text))
            {
                pakFolderToCompile.Text = "";
                return;
            }
            string extension;
            if (radioButton1.Checked)
            {
                extension = ".pak.xen";
            }
            else if (radioButton2.Checked)
            {
                extension = ".pak.ps3";
            }
            else if (radioButton3.Checked)
            {
                extension = ".pak.ps2";
            }
            else if (radioButton4.Checked)
            {
                extension = ".pak.ngc";
            }
            else
            {
                extension = ".pak";
            }

            pakFileSave.Text = $"{pakFolderToCompile.Text}{extension}";
        }

        private async Task ExtractPAK()
        {
            List<string> files = GetFilesFromFolder(pakFilesFolder.Text);

            foreach (string file in files)
            {
                try
                {
                    await Task.Run(() => ProcessPAKFromFile(file, !convQ.Checked));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Extraction failed: {ex.Message}");
                }
            }
        }

        private async void extractPak_Click(object sender, EventArgs e)
        {
            if (pakFilesFolder.Text == "" || (!Directory.Exists(pakFilesFolder.Text) && !File.Exists(pakFilesFolder.Text)))
            {
                MessageBox.Show("Please select a PAK file or a folder containing PAK files to unpack.");
                return;
            }
            else
            {
                await ExtractPAK();
            }
        }

        private async Task CompilePak() 
        {
            if (pakFolderToCompile.Text == "" || !Directory.Exists(pakFolderToCompile.Text))
            {
                MessageBox.Show("Please select a folder containing files to compile.");
                return;
            }
            string game = gameSelect.Text;
            if (!game.StartsWith("GH"))
            {
                MessageBox.Show("Please select a game.");
                return;
            }
            string console = SetConsole();
            string? assetContext = assetContextText.Text == "" ? null : assetContextText.Text;
            string folderPath = Path.GetDirectoryName(pakFolderToCompile.Text).ToUpper();
            bool isQb = folderPath == "QB";
            bool split = (isQb && console != "WII") ? true : splitPab.Checked;
            PakCompiler pakCompiler = new PakCompiler(game, console, assetContext, false, split);

            //var (pak, pab) = pakCompiler.CompilePAK(pakFolderToCompile.Text);
            await Task.Run(() =>
            {
                var (pak, pab) = pakCompiler.CompilePAK(pakFolderToCompile.Text);
            
                string pakPath = pakFileSave.Text;
                string pabPath = pakPath.Replace(".pak", ".pab");
                try
                {
                    if (pab != null)
                    {
                        using (FileStream pakFile = new FileStream(pakPath, FileMode.Create, FileAccess.Write))
                        using (FileStream pabFile = new FileStream(pabPath, FileMode.Create, FileAccess.Write))
                        {
                            pakFile.Write(pak);
                            pabFile.Write(pab);
                        }
                    }
                    else
                    {
                        using (FileStream pakFile = new FileStream(pakPath, FileMode.Create, FileAccess.Write))
                        {
                            pakFile.Write(pak);
                            pakFile.Write(pab);
                        }
                    }
                    Console.WriteLine("PAK compiled successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Compile failed: {ex.Message}");
                }
            }
            );
        }

        private async void compilePak_Click(object sender, EventArgs e)
        {
            await CompilePak();
        }

        private string SetConsole()
        {
            if (radioButton3.Checked)
            {
                return "PS2";
            }
            else if (radioButton4.Checked)
            {
                return "WII";
            }
            else
            {
                return "360";
            }
        }

        private void assetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Enable the asset context textbox if the checkbox is checked
            assetContextText.Enabled = assetCheckBox.Checked;
            if (!assetCheckBox.Checked)
            {
                // Clear the contents of the textbox if the checkbox is unchecked
                assetContextText.Clear();
            }
        }

        private void pakFolderToCompile_TextChanged(object sender, EventArgs e)
        {
            SetPakOutput();
        }
    }
}
