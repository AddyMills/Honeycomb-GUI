namespace GH_Toolkit_GUI
{
    partial class SongListManager
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
            songList = new CheckedListBox();
            tabControl1 = new TabControl();
            importTab = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            importSghFile = new Button();
            convertButton = new Button();
            exportTab = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            loadSetlist2 = new Button();
            exportToSgh = new Button();
            deleteTab = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            deleteSelected = new Button();
            loadSetlist = new Button();
            groupBox1 = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            gh3Radio = new RadioButton();
            ghaRadio = new RadioButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            selectAllButton = new Button();
            selectNoneButton = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            consoleLabel = new Label();
            consoleSelect = new ComboBox();
            tabPage1 = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            restoreSetlistButton = new Button();
            tabControl1.SuspendLayout();
            importTab.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            exportTab.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            deleteTab.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // songList
            // 
            songList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            songList.FormattingEnabled = true;
            songList.Location = new Point(12, 12);
            songList.Name = "songList";
            songList.Size = new Size(571, 202);
            songList.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(importTab);
            tabControl1.Controls.Add(exportTab);
            tabControl1.Controls.Add(deleteTab);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(3, 190);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(565, 183);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_TabIndexChanged;
            // 
            // importTab
            // 
            importTab.Controls.Add(tableLayoutPanel1);
            importTab.Location = new Point(4, 24);
            importTab.Name = "importTab";
            importTab.Padding = new Padding(3);
            importTab.Size = new Size(557, 155);
            importTab.TabIndex = 0;
            importTab.Text = "Import";
            importTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(importSghFile, 0, 0);
            tableLayoutPanel1.Controls.Add(convertButton, 0, 1);
            tableLayoutPanel1.Location = new Point(6, 6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(545, 143);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // importSghFile
            // 
            importSghFile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            importSghFile.Location = new Point(3, 24);
            importSghFile.Name = "importSghFile";
            importSghFile.Size = new Size(539, 23);
            importSghFile.TabIndex = 0;
            importSghFile.Text = "Select SGH File";
            importSghFile.UseVisualStyleBackColor = true;
            importSghFile.Click += importSghFile_Click;
            // 
            // convertButton
            // 
            convertButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            convertButton.BackColor = Color.OliveDrab;
            convertButton.ForeColor = SystemColors.ButtonFace;
            convertButton.Location = new Point(3, 95);
            convertButton.Name = "convertButton";
            convertButton.Size = new Size(539, 23);
            convertButton.TabIndex = 3;
            convertButton.Text = "Import Selected to Game";
            convertButton.UseVisualStyleBackColor = false;
            convertButton.Click += convertButton_Click;
            // 
            // exportTab
            // 
            exportTab.Controls.Add(tableLayoutPanel8);
            exportTab.Location = new Point(4, 24);
            exportTab.Name = "exportTab";
            exportTab.Padding = new Padding(3);
            exportTab.Size = new Size(557, 155);
            exportTab.TabIndex = 1;
            exportTab.Text = "Export";
            exportTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(loadSetlist2, 0, 0);
            tableLayoutPanel8.Controls.Add(exportToSgh, 0, 1);
            tableLayoutPanel8.Location = new Point(6, 6);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Size = new Size(545, 143);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // loadSetlist2
            // 
            loadSetlist2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loadSetlist2.Location = new Point(3, 24);
            loadSetlist2.Name = "loadSetlist2";
            loadSetlist2.RightToLeft = RightToLeft.No;
            loadSetlist2.Size = new Size(539, 23);
            loadSetlist2.TabIndex = 1;
            loadSetlist2.Text = "Load Setlist";
            loadSetlist2.UseVisualStyleBackColor = true;
            loadSetlist2.Click += loadSetlist2_Click;
            // 
            // exportToSgh
            // 
            exportToSgh.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            exportToSgh.BackColor = Color.OliveDrab;
            exportToSgh.ForeColor = SystemColors.ButtonFace;
            exportToSgh.Location = new Point(3, 95);
            exportToSgh.Name = "exportToSgh";
            exportToSgh.Size = new Size(539, 23);
            exportToSgh.TabIndex = 4;
            exportToSgh.Text = "Export Selected Songs to SGH File";
            exportToSgh.UseVisualStyleBackColor = false;
            exportToSgh.Click += exportToSgh_Click;
            // 
            // deleteTab
            // 
            deleteTab.Controls.Add(tableLayoutPanel5);
            deleteTab.Location = new Point(4, 24);
            deleteTab.Name = "deleteTab";
            deleteTab.Padding = new Padding(3);
            deleteTab.Size = new Size(557, 155);
            deleteTab.TabIndex = 2;
            deleteTab.Text = "Delete";
            deleteTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(deleteSelected, 0, 1);
            tableLayoutPanel5.Controls.Add(loadSetlist, 0, 0);
            tableLayoutPanel5.Location = new Point(6, 6);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(545, 143);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // deleteSelected
            // 
            deleteSelected.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            deleteSelected.BackColor = Color.Firebrick;
            deleteSelected.ForeColor = SystemColors.ButtonHighlight;
            deleteSelected.Location = new Point(3, 95);
            deleteSelected.Name = "deleteSelected";
            deleteSelected.Size = new Size(539, 23);
            deleteSelected.TabIndex = 3;
            deleteSelected.Text = "Delete Selected";
            deleteSelected.UseVisualStyleBackColor = false;
            deleteSelected.Click += deleteSelected_Click;
            // 
            // loadSetlist
            // 
            loadSetlist.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            loadSetlist.Location = new Point(3, 24);
            loadSetlist.Name = "loadSetlist";
            loadSetlist.RightToLeft = RightToLeft.No;
            loadSetlist.Size = new Size(539, 23);
            loadSetlist.TabIndex = 1;
            loadSetlist.Text = "Load Setlist";
            loadSetlist.UseVisualStyleBackColor = true;
            loadSetlist.Click += loadSetlist_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel7);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 115);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(565, 69);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Game";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(gh3Radio, 0, 0);
            tableLayoutPanel7.Controls.Add(ghaRadio, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 19);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(559, 47);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // gh3Radio
            // 
            gh3Radio.Anchor = AnchorStyles.Left;
            gh3Radio.AutoSize = true;
            gh3Radio.Location = new Point(3, 14);
            gh3Radio.Name = "gh3Radio";
            gh3Radio.Size = new Size(48, 19);
            gh3Radio.TabIndex = 0;
            gh3Radio.TabStop = true;
            gh3Radio.Text = "GH3";
            gh3Radio.UseVisualStyleBackColor = true;
            gh3Radio.CheckedChanged += gh3Radio_CheckedChanged;
            // 
            // ghaRadio
            // 
            ghaRadio.Anchor = AnchorStyles.Left;
            ghaRadio.AutoSize = true;
            ghaRadio.Location = new Point(282, 14);
            ghaRadio.Name = "ghaRadio";
            ghaRadio.Size = new Size(50, 19);
            ghaRadio.TabIndex = 1;
            ghaRadio.TabStop = true;
            ghaRadio.Text = "GHA";
            ghaRadio.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Controls.Add(tabControl1, 0, 3);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Location = new Point(12, 220);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(571, 376);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(selectAllButton, 0, 0);
            tableLayoutPanel4.Controls.Add(selectNoneButton, 1, 0);
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(565, 50);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // selectAllButton
            // 
            selectAllButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            selectAllButton.Location = new Point(3, 13);
            selectAllButton.Name = "selectAllButton";
            selectAllButton.Size = new Size(276, 23);
            selectAllButton.TabIndex = 0;
            selectAllButton.Text = "Select All";
            selectAllButton.UseVisualStyleBackColor = true;
            selectAllButton.Click += selectAllButton_Click;
            // 
            // selectNoneButton
            // 
            selectNoneButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            selectNoneButton.Location = new Point(285, 13);
            selectNoneButton.Name = "selectNoneButton";
            selectNoneButton.Size = new Size(277, 23);
            selectNoneButton.TabIndex = 1;
            selectNoneButton.Text = "Select None";
            selectNoneButton.UseVisualStyleBackColor = true;
            selectNoneButton.Click += selectNoneButton_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(consoleLabel, 0, 0);
            tableLayoutPanel3.Controls.Add(consoleSelect, 1, 0);
            tableLayoutPanel3.Location = new Point(3, 59);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(565, 50);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // consoleLabel
            // 
            consoleLabel.Anchor = AnchorStyles.Left;
            consoleLabel.AutoSize = true;
            consoleLabel.Location = new Point(3, 17);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new Size(53, 15);
            consoleLabel.TabIndex = 0;
            consoleLabel.Text = "Console:";
            // 
            // consoleSelect
            // 
            consoleSelect.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            consoleSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            consoleSelect.FormattingEnabled = true;
            consoleSelect.Items.AddRange(new object[] { "PC", "360", "PS3" });
            consoleSelect.Location = new Point(62, 13);
            consoleSelect.Name = "consoleSelect";
            consoleSelect.Size = new Size(500, 23);
            consoleSelect.TabIndex = 1;
            consoleSelect.SelectedIndexChanged += consoleSelect_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel6);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(557, 155);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Restore";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(restoreSetlistButton, 0, 0);
            tableLayoutPanel6.Location = new Point(6, 6);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(545, 146);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // restoreSetlistButton
            // 
            restoreSetlistButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            restoreSetlistButton.Location = new Point(3, 3);
            restoreSetlistButton.Name = "restoreSetlistButton";
            restoreSetlistButton.Size = new Size(539, 140);
            restoreSetlistButton.TabIndex = 0;
            restoreSetlistButton.Text = "Click Here to Restore the Original DLC Setlist (Removes all customs)";
            restoreSetlistButton.UseVisualStyleBackColor = true;
            restoreSetlistButton.Click += restoreSetlistButton_Click;
            // 
            // SongListManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 608);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(songList);
            Name = "SongListManager";
            Text = "Song List Manager";
            tabControl1.ResumeLayout(false);
            importTab.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            exportTab.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            deleteTab.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tabPage1.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button importSghFile;

        private System.Windows.Forms.Button convertButton;

        #endregion

        private CheckedListBox songList;
        private System.Windows.Forms.TabControl tabControl1;
        private TabPage importTab;
        private TabPage exportTab;
        private TabPage deleteTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.ComboBox consoleSelect;
        private TableLayoutPanel tableLayoutPanel4;
        private Button selectAllButton;
        private Button selectNoneButton;
        private TableLayoutPanel tableLayoutPanel8;
        private Button loadSetlist2;
        private Button exportToSgh;
        private TableLayoutPanel tableLayoutPanel5;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel7;
        private RadioButton gh3Radio;
        private RadioButton ghaRadio;
        private Button loadSetlist;
        private Button deleteSelected;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel6;
        private Button restoreSetlistButton;
    }
}