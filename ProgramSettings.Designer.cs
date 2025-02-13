﻿namespace GH_Toolkit_GUI
{
    partial class ProgramSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            OverrideBeatLines = new CheckBox();
            EncryptAudio = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label5 = new Label();
            CompilePopup = new CheckBox();
            WtModsFolder = new TextBox();
            Gh3FolderPath = new TextBox();
            GhaFolderPath = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label4 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            PreviewFadeOut = new NumericUpDown();
            PreviewFadeIn = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            OnyxCliFolder = new TextBox();
            label13 = new Label();
            PreferredConsoleSetting = new ComboBox();
            tabPage2 = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            SongManagerDeleteSongs = new CheckBox();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PreviewFadeOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviewFadeIn).BeginInit();
            tabPage2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 553);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(768, 525);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Compile a Song";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(OverrideBeatLines, 1, 1);
            tableLayoutPanel1.Controls.Add(EncryptAudio, 1, 5);
            tableLayoutPanel1.Controls.Add(label2, 0, 11);
            tableLayoutPanel1.Controls.Add(label1, 0, 10);
            tableLayoutPanel1.Controls.Add(label3, 0, 6);
            tableLayoutPanel1.Controls.Add(label5, 0, 0);
            tableLayoutPanel1.Controls.Add(CompilePopup, 1, 0);
            tableLayoutPanel1.Controls.Add(WtModsFolder, 1, 6);
            tableLayoutPanel1.Controls.Add(Gh3FolderPath, 1, 10);
            tableLayoutPanel1.Controls.Add(GhaFolderPath, 1, 11);
            tableLayoutPanel1.Controls.Add(label8, 0, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 5);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 2);
            tableLayoutPanel1.Controls.Add(label10, 0, 1);
            tableLayoutPanel1.Controls.Add(label11, 0, 7);
            tableLayoutPanel1.Controls.Add(label12, 0, 8);
            tableLayoutPanel1.Controls.Add(OnyxCliFolder, 1, 8);
            tableLayoutPanel1.Controls.Add(label13, 0, 3);
            tableLayoutPanel1.Controls.Add(PreferredConsoleSetting, 1, 3);
            tableLayoutPanel1.Location = new Point(3, 2);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 13;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69248056F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692542F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.69248056F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.689466F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.6936965F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.6936965F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692479F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692543F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692543F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692543F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692479F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692479F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.690557F));
            tableLayoutPanel1.Size = new Size(764, 523);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // OverrideBeatLines
            // 
            OverrideBeatLines.Anchor = AnchorStyles.Left;
            OverrideBeatLines.AutoSize = true;
            OverrideBeatLines.Location = new Point(270, 53);
            OverrideBeatLines.Margin = new Padding(3, 2, 3, 2);
            OverrideBeatLines.Name = "OverrideBeatLines";
            OverrideBeatLines.Size = new Size(15, 14);
            OverrideBeatLines.TabIndex = 15;
            OverrideBeatLines.UseVisualStyleBackColor = true;
            // 
            // EncryptAudio
            // 
            EncryptAudio.Anchor = AnchorStyles.Left;
            EncryptAudio.AutoSize = true;
            EncryptAudio.Location = new Point(270, 213);
            EncryptAudio.Margin = new Padding(3, 2, 3, 2);
            EncryptAudio.Name = "EncryptAudio";
            EncryptAudio.Size = new Size(15, 14);
            EncryptAudio.TabIndex = 13;
            EncryptAudio.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 440);
            label2.Name = "label2";
            label2.Size = new Size(261, 40);
            label2.TabIndex = 5;
            label2.Text = "GHA Folder Path (PC)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 400);
            label1.Name = "label1";
            label1.Size = new Size(261, 40);
            label1.TabIndex = 4;
            label1.Text = "GH3 Folder Path (PC)";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 240);
            label3.Name = "label3";
            label3.Size = new Size(261, 40);
            label3.TabIndex = 3;
            label3.Text = "GHWT MODS Folder Path";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(261, 40);
            label5.TabIndex = 6;
            label5.Text = "Show Compile Success Popup";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CompilePopup
            // 
            CompilePopup.AutoSize = true;
            CompilePopup.Dock = DockStyle.Fill;
            CompilePopup.Location = new Point(270, 2);
            CompilePopup.Margin = new Padding(3, 2, 3, 2);
            CompilePopup.Name = "CompilePopup";
            CompilePopup.Size = new Size(491, 36);
            CompilePopup.TabIndex = 1;
            CompilePopup.UseVisualStyleBackColor = true;
            // 
            // WtModsFolder
            // 
            WtModsFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            WtModsFolder.Location = new Point(270, 248);
            WtModsFolder.Margin = new Padding(3, 2, 3, 2);
            WtModsFolder.Name = "WtModsFolder";
            WtModsFolder.Size = new Size(491, 23);
            WtModsFolder.TabIndex = 8;
            // 
            // Gh3FolderPath
            // 
            Gh3FolderPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Gh3FolderPath.Location = new Point(270, 408);
            Gh3FolderPath.Margin = new Padding(3, 2, 3, 2);
            Gh3FolderPath.Name = "Gh3FolderPath";
            Gh3FolderPath.ReadOnly = true;
            Gh3FolderPath.Size = new Size(491, 23);
            Gh3FolderPath.TabIndex = 9;
            // 
            // GhaFolderPath
            // 
            GhaFolderPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GhaFolderPath.Location = new Point(270, 448);
            GhaFolderPath.Margin = new Padding(3, 2, 3, 2);
            GhaFolderPath.Name = "GhaFolderPath";
            GhaFolderPath.ReadOnly = true;
            GhaFolderPath.Size = new Size(491, 23);
            GhaFolderPath.TabIndex = 10;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label8, 2);
            label8.Location = new Point(248, 172);
            label8.Name = "label8";
            label8.Size = new Size(267, 15);
            label8.TabIndex = 11;
            label8.Text = "Guitar Hero World Tour Definitive Edition Settings";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(3, 212);
            label9.Name = "label9";
            label9.Size = new Size(82, 15);
            label9.TabIndex = 12;
            label9.Text = "Encrypt Audio";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 92);
            label4.Name = "label4";
            label4.Size = new Size(167, 15);
            label4.TabIndex = 2;
            label4.Text = "Preview Fade Values (Seconds)";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(label6, 0, 0);
            tableLayoutPanel2.Controls.Add(label7, 2, 0);
            tableLayoutPanel2.Controls.Add(PreviewFadeOut, 3, 0);
            tableLayoutPanel2.Controls.Add(PreviewFadeIn, 1, 0);
            tableLayoutPanel2.Location = new Point(267, 83);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(497, 34);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(118, 34);
            label6.TabIndex = 0;
            label6.Text = "Fade In:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(251, 0);
            label7.Name = "label7";
            label7.Size = new Size(118, 34);
            label7.TabIndex = 1;
            label7.Text = "Fade Out:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PreviewFadeOut
            // 
            PreviewFadeOut.Anchor = AnchorStyles.Left;
            PreviewFadeOut.DecimalPlaces = 2;
            PreviewFadeOut.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            PreviewFadeOut.Location = new Point(375, 5);
            PreviewFadeOut.Margin = new Padding(3, 2, 3, 2);
            PreviewFadeOut.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            PreviewFadeOut.Name = "PreviewFadeOut";
            PreviewFadeOut.Size = new Size(108, 23);
            PreviewFadeOut.TabIndex = 3;
            PreviewFadeOut.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // PreviewFadeIn
            // 
            PreviewFadeIn.Anchor = AnchorStyles.Left;
            PreviewFadeIn.DecimalPlaces = 2;
            PreviewFadeIn.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            PreviewFadeIn.Location = new Point(127, 5);
            PreviewFadeIn.Margin = new Padding(3, 2, 3, 2);
            PreviewFadeIn.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            PreviewFadeIn.Name = "PreviewFadeIn";
            PreviewFadeIn.Size = new Size(105, 23);
            PreviewFadeIn.TabIndex = 2;
            PreviewFadeIn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Location = new Point(3, 52);
            label10.Name = "label10";
            label10.Size = new Size(183, 15);
            label10.TabIndex = 14;
            label10.Text = "Override Beat Lines (if applicable)";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label11, 2);
            label11.Location = new Point(3, 292);
            label11.Name = "label11";
            label11.Size = new Size(758, 15);
            label11.TabIndex = 16;
            label11.Text = "Other Settings";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Location = new Point(3, 320);
            label12.Name = "label12";
            label12.Size = new Size(82, 40);
            label12.TabIndex = 17;
            label12.Text = "Onyx CLI Path";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OnyxCliFolder
            // 
            OnyxCliFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            OnyxCliFolder.Location = new Point(270, 328);
            OnyxCliFolder.Name = "OnyxCliFolder";
            OnyxCliFolder.Size = new Size(491, 23);
            OnyxCliFolder.TabIndex = 18;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Left;
            label13.AutoSize = true;
            label13.Location = new Point(3, 132);
            label13.Name = "label13";
            label13.Size = new Size(104, 15);
            label13.TabIndex = 19;
            label13.Text = "Preferred Console:";
            // 
            // PreferredConsoleSetting
            // 
            PreferredConsoleSetting.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PreferredConsoleSetting.FormattingEnabled = true;
            PreferredConsoleSetting.Items.AddRange(new object[] { "Xbox 360", "PS3" });
            PreferredConsoleSetting.Location = new Point(270, 128);
            PreferredConsoleSetting.Name = "PreferredConsoleSetting";
            PreferredConsoleSetting.Size = new Size(491, 23);
            PreferredConsoleSetting.TabIndex = 20;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(768, 525);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Songlist Manager";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(SongManagerDeleteSongs, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(762, 521);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // SongManagerDeleteSongs
            // 
            SongManagerDeleteSongs.Anchor = AnchorStyles.Left;
            SongManagerDeleteSongs.AutoSize = true;
            SongManagerDeleteSongs.Location = new Point(3, 120);
            SongManagerDeleteSongs.Name = "SongManagerDeleteSongs";
            SongManagerDeleteSongs.Size = new Size(201, 19);
            SongManagerDeleteSongs.TabIndex = 0;
            SongManagerDeleteSongs.Text = "Delete Files After Removing Song";
            SongManagerDeleteSongs.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(659, 558);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(107, 22);
            button1.TabIndex = 1;
            button1.Text = "Save & Close";
            button1.UseMnemonic = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProgramSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 587);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProgramSettings";
            ShowIcon = false;
            Text = "Settings & Information";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PreviewFadeOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviewFadeIn).EndInit();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox CompilePopup;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label6;
        private Label label7;
        private NumericUpDown PreviewFadeIn;
        private NumericUpDown PreviewFadeOut;
        private TextBox WtModsFolder;
        private TextBox Gh3FolderPath;
        private TextBox GhaFolderPath;
        private Button button1;
        private CheckBox EncryptAudio;
        private Label label8;
        private Label label9;
        private CheckBox OverrideBeatLines;
        private Label label10;
        private TableLayoutPanel tableLayoutPanel3;
        private CheckBox SongManagerDeleteSongs;
        private Label label11;
        private Label label12;
        private TextBox OnyxCliFolder;
        private Label label13;
        private ComboBox PreferredConsoleSetting;
    }
}