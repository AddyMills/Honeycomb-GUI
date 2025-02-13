using System.Text;

namespace GH_Toolkit_GUI
{
    public partial class MasterForm : Form
    {
        public MasterForm(string inputFile = "")
        {
            InitializeComponent();
            Console.SetOut(new TextBoxStreamWriter(consoleOutput));
            if (inputFile != "")
            {
                ReadInputFile(inputFile);
            }
        }

        private void ReadInputFile(string inputFile)
        {
            if (Path.GetExtension(inputFile.ToLower()) == ".ghproj")
            {
                OpenCompileSongForm(inputFile);
            }
            else if (Path.GetExtension(inputFile.ToLower()) == ".sgh")
            {
                ImportSGHForm(inputFile);
            }

        }

        private void OpenCompileSongForm(string inputFile = "")
        {
            CompileSong compileSongForm = new CompileSong(inputFile);
            compileSongForm.Show();
        }

        private void ImportSGHForm(string inputFile = "")
        {
            ImportSGH importSGHForm = new ImportSGH(inputFile);
            importSGHForm.Show();
        }

        private void PakToolsForm()
        {
            PakTools pakToolsForm = new PakTools();
            pakToolsForm.Show();
        }

        private void WadToolsForm()
        {
            WadTools wadToolsForm = new WadTools();
            wadToolsForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenCompileSongForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImportSGHForm();
        }

        private void songlistManagerClick(object sender, EventArgs e)
        {
            SongListManager songListManager = new SongListManager();
            songListManager.Show();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MasterForm_Load(object sender, EventArgs e)
        {

        }

        private void pakToolsButton_Click(object sender, EventArgs e)
        {
            PakToolsForm();
        }

        private void wadExplorerButton_Click(object sender, EventArgs e)
        {
            WadToolsForm();
        }
    }
    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox _output = null;

        public TextBoxStreamWriter(TextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            if (_output.InvokeRequired)
            {
                _output.Invoke(new MethodInvoker(delegate { _output.AppendText(value.ToString()); }));
            }
            else
            {
                _output.AppendText(value.ToString());
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
