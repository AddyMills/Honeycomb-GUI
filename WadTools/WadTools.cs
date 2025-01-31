using static GH_Toolkit_Core.PS2.HED;
using static GH_Toolkit_Core.PS2.WAD;


namespace GH_Toolkit_GUI
{
    public partial class WadTools : Form
    {
        private UserPreferences Pref = UserPreferences.Default;
        public WadTools()
        {
            InitializeComponent();
            //InitializeDragDropTextBox();
            InitializeDragDropTextBox();
        }
        private void InitializeDragDropTextBox()
        {

            wadFile.AllowDrop = true;
            // Handle DragEnter event
            wadFile.DragEnter += new DragEventHandler(textBox_DragEnter);
            // Handle DragDrop event
            wadFile.DragDrop += new DragEventHandler(textBox_DragDrop);

            wadFolderToCompile.AllowDrop = true;
            // Handle DragEnter event
            wadFolderToCompile.DragEnter += new DragEventHandler(textBox_DragEnter);
            // Handle DragDrop event
            wadFolderToCompile.DragDrop += new DragEventHandler(textBox_DragDrop);
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

                    wadFile.Text = selectedPath;
                    //SetPakOutput();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                wadFolderToCompile.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private async void extractWad_Click(object sender, EventArgs e)
        {
            string folderPath = Path.GetDirectoryName(wadFile.Text);
            string extractPath = Path.Combine(folderPath, "WAD Extract");
            string hedPath = Path.Combine(folderPath, "DATAP.HED");
            string wadPath = Path.Combine(folderPath, "DATAP.WAD");
            string pdPath = Path.Combine(folderPath, "DATAPD.HDP");
            string pfPath = Path.Combine(folderPath, "DATAPF.HDP");

            var filesExist = new string[] { hedPath, wadPath, pdPath, pfPath };
            var allExist = filesExist.All(File.Exists);

            if (!allExist)
            {
                foreach (var file in filesExist)
                {
                    if (!File.Exists(file))
                    {
                        Console.WriteLine($"The file {file} does not exist.");
                    }
                }
                return;
            }

            List<HedEntry> HedFiles = ReadHEDFile(File.ReadAllBytes(hedPath));
            await Task.Run(() => ExtractWADFile(HedFiles, File.ReadAllBytes(wadPath), extractPath, false));
        }

        private async void compileWad_Click(object sender, EventArgs e)
        {
            await Task.Run(() => CompileWADFile(wadFolderToCompile.Text, false));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Pref.RecompileQb = checkBox1.Checked;
            Pref.Save();
        }
    }
}
