namespace GH_Toolkit_GUI
{
    partial class PakTools
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            extractButton = new Button();
            convQ = new CheckBox();
            button1 = new Button();
            pakFilesFolder = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            assetContextText = new TextBox();
            assetCheckBox = new CheckBox();
            gameSelect = new ComboBox();
            splitPab = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button6 = new Button();
            pakFileSave = new TextBox();
            label5 = new Label();
            button3 = new Button();
            pakFolderToCompile = new TextBox();
            label4 = new Label();
            openPakFile = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            savePakFile = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(543, 208);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(extractButton);
            tabPage1.Controls.Add(convQ);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(pakFilesFolder);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(535, 180);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Extract";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // extractButton
            // 
            extractButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            extractButton.Location = new Point(455, 153);
            extractButton.Name = "extractButton";
            extractButton.Size = new Size(75, 23);
            extractButton.TabIndex = 16;
            extractButton.Text = "Extract";
            extractButton.UseVisualStyleBackColor = true;
            extractButton.Click += extractPak_Click;
            // 
            // convQ
            // 
            convQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            convQ.AutoSize = true;
            convQ.Location = new Point(3, 155);
            convQ.Name = "convQ";
            convQ.Size = new Size(179, 19);
            convQ.TabIndex = 15;
            convQ.Text = "Don't convert .qb files to text";
            convQ.UseVisualStyleBackColor = false;
            convQ.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(455, 21);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Open";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pakFilesFolder
            // 
            pakFilesFolder.AllowDrop = true;
            pakFilesFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pakFilesFolder.Location = new Point(3, 21);
            pakFilesFolder.Name = "pakFilesFolder";
            pakFilesFolder.Size = new Size(446, 23);
            pakFilesFolder.TabIndex = 10;
            pakFilesFolder.DragDrop += textBox_DragDrop;
            pakFilesFolder.DragEnter += textBox_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(211, 15);
            label1.TabIndex = 9;
            label1.Text = "PAK File or Folder Containing PAK Files";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(assetContextText);
            tabPage2.Controls.Add(assetCheckBox);
            tabPage2.Controls.Add(gameSelect);
            tabPage2.Controls.Add(splitPab);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(pakFileSave);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(pakFolderToCompile);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(535, 180);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Compile";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // assetContextText
            // 
            assetContextText.Enabled = false;
            assetContextText.Location = new Point(3, 112);
            assetContextText.Name = "assetContextText";
            assetContextText.Size = new Size(175, 23);
            assetContextText.TabIndex = 26;
            // 
            // assetCheckBox
            // 
            assetCheckBox.AutoSize = true;
            assetCheckBox.Location = new Point(3, 94);
            assetCheckBox.Name = "assetCheckBox";
            assetCheckBox.Size = new Size(118, 19);
            assetCheckBox.TabIndex = 25;
            assetCheckBox.Text = "Set Asset Context";
            assetCheckBox.UseVisualStyleBackColor = true;
            assetCheckBox.CheckedChanged += assetCheckBox_CheckedChanged;
            // 
            // gameSelect
            // 
            gameSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameSelect.FormattingEnabled = true;
            gameSelect.Items.AddRange(new object[] { "GH3", "GHWT", "GHWoR" });
            gameSelect.Location = new Point(310, 153);
            gameSelect.Name = "gameSelect";
            gameSelect.Size = new Size(139, 23);
            gameSelect.TabIndex = 24;
            gameSelect.Text = "Select Game";
            // 
            // splitPab
            // 
            splitPab.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            splitPab.AutoSize = true;
            splitPab.Location = new Point(231, 156);
            splitPab.Name = "splitPab";
            splitPab.Size = new Size(73, 19);
            splitPab.TabIndex = 23;
            splitPab.Text = "Split PAB";
            splitPab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(3, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 35);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Console";
            // 
            // radioButton4
            // 
            radioButton4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(175, 14);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(42, 19);
            radioButton4.TabIndex = 27;
            radioButton4.TabStop = true;
            radioButton4.Text = "Wii";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(75, 14);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(44, 19);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "PS2";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(125, 14);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(44, 19);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "PS3";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(6, 14);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(63, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "360/PC";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Location = new Point(455, 153);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 21;
            button6.Text = "Compile";
            button6.UseVisualStyleBackColor = true;
            button6.Click += compilePak_Click;
            // 
            // pakFileSave
            // 
            pakFileSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pakFileSave.Location = new Point(3, 65);
            pakFileSave.Name = "pakFileSave";
            pakFileSave.ReadOnly = true;
            pakFileSave.Size = new Size(446, 23);
            pakFileSave.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 47);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 18;
            label5.Text = "Save Location";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(455, 21);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 17;
            button3.Text = "Select";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pakFolderToCompile
            // 
            pakFolderToCompile.AllowDrop = true;
            pakFolderToCompile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pakFolderToCompile.Location = new Point(3, 21);
            pakFolderToCompile.Name = "pakFolderToCompile";
            pakFolderToCompile.Size = new Size(446, 23);
            pakFolderToCompile.TabIndex = 16;
            pakFolderToCompile.TextChanged += pakFolderToCompile_TextChanged;
            pakFolderToCompile.DragDrop += textBox_DragDrop;
            pakFolderToCompile.DragEnter += textBox_DragEnter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 15;
            label4.Text = "Extract Folder";
            // 
            // openPakFile
            // 
            openPakFile.CheckFileExists = false;
            openPakFile.FileName = "openFileDialog1";
            // 
            // PakTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 217);
            Controls.Add(tabControl1);
            Name = "PakTools";
            Text = "PAK Tools";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private OpenFileDialog openPakFile;
        private Button button1;
        private TextBox pakFilesFolder;
        private Label label1;
        private CheckBox convQ;
        private TextBox pakFileSave;
        private Label label5;
        private Button button3;
        private TextBox pakFolderToCompile;
        private Label label4;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button extractButton;
        private Button button6;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton3;
        private SaveFileDialog savePakFile;
        private CheckBox splitPab;
        private ComboBox gameSelect;
        private TextBox assetContextText;
        private CheckBox assetCheckBox;
        private RadioButton radioButton4;
    }
}
