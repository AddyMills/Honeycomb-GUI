namespace GH_Toolkit_GUI
{
    partial class WadTools
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
            button1 = new Button();
            wadFile = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            button6 = new Button();
            button3 = new Button();
            wadFolderToCompile = new TextBox();
            label4 = new Label();
            openPakFile = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            savePakFile = new SaveFileDialog();
            checkBox1 = new CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
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
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(wadFile);
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
            extractButton.Click += extractWad_Click;
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
            // wadFile
            // 
            wadFile.AllowDrop = true;
            wadFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            wadFile.Location = new Point(3, 21);
            wadFile.Name = "wadFile";
            wadFile.Size = new Size(446, 23);
            wadFile.TabIndex = 10;
            wadFile.DragDrop += textBox_DragDrop;
            wadFile.DragEnter += textBox_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 9;
            label1.Text = "WAD File";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(wadFolderToCompile);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(535, 180);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Compile";
            tabPage2.UseVisualStyleBackColor = true;
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
            button6.Click += compileWad_Click;
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
            // wadFolderToCompile
            // 
            wadFolderToCompile.AllowDrop = true;
            wadFolderToCompile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            wadFolderToCompile.Location = new Point(3, 21);
            wadFolderToCompile.Name = "wadFolderToCompile";
            wadFolderToCompile.Size = new Size(446, 23);
            wadFolderToCompile.TabIndex = 16;
            wadFolderToCompile.DragDrop += textBox_DragDrop;
            wadFolderToCompile.DragEnter += textBox_DragEnter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 3);
            label4.Name = "label4";
            label4.Size = new Size(122, 15);
            label4.TabIndex = 15;
            label4.Text = "Extracted WAD Folder";
            // 
            // openPakFile
            // 
            openPakFile.CheckFileExists = false;
            openPakFile.FileName = "openFileDialog1";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(3, 157);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(140, 19);
            checkBox1.TabIndex = 22;
            checkBox1.Text = "Recompile qb pak file";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // WadTools
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 217);
            Controls.Add(tabControl1);
            Name = "WadTools";
            Text = "WAD Tools";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private OpenFileDialog openPakFile;
        private Button button1;
        private TextBox wadFile;
        private Label label1;
        private Button button3;
        private TextBox wadFolderToCompile;
        private Label label4;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button extractButton;
        private Button button6;
        private SaveFileDialog savePakFile;
        private CheckBox checkBox1;
    }
}
