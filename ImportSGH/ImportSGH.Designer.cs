namespace GH_Toolkit_GUI
{
    partial class ImportSGH
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            songList = new System.Windows.Forms.CheckedListBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            importSghFile = new System.Windows.Forms.Button();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            consoleLabel = new System.Windows.Forms.Label();
            ConsoleSelect = new System.Windows.Forms.ComboBox();
            convertButton = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(songList, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(419, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // songList
            // 
            songList.CheckOnClick = true;
            songList.Dock = System.Windows.Forms.DockStyle.Fill;
            songList.FormattingEnabled = true;
            songList.Location = new System.Drawing.Point(3, 3);
            songList.Name = "songList";
            songList.ScrollAlwaysVisible = true;
            songList.Size = new System.Drawing.Size(413, 194);
            songList.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(importSghFile, 0, 0);
            tableLayoutPanel3.Controls.Add(convertButton, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 253);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.000624F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.998129F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.000628F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.000624F));
            tableLayoutPanel3.Size = new System.Drawing.Size(413, 194);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // importSghFile
            // 
            importSghFile.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            importSghFile.Location = new System.Drawing.Point(3, 12);
            importSghFile.Name = "importSghFile";
            importSghFile.Size = new System.Drawing.Size(407, 23);
            importSghFile.TabIndex = 1;
            importSghFile.Text = "Import SGH File";
            importSghFile.UseVisualStyleBackColor = true;
            importSghFile.Click += importSgh_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 48);
            tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new System.Drawing.Size(413, 48);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(consoleLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(ConsoleSelect, 1, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 203);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(413, 44);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // consoleLabel
            // 
            consoleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            consoleLabel.AutoSize = true;
            consoleLabel.Location = new System.Drawing.Point(3, 14);
            consoleLabel.Name = "consoleLabel";
            consoleLabel.Size = new System.Drawing.Size(53, 15);
            consoleLabel.TabIndex = 0;
            consoleLabel.Text = "Console:";
            // 
            // ConsoleSelect
            // 
            ConsoleSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            ConsoleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ConsoleSelect.FormattingEnabled = true;
            ConsoleSelect.Items.AddRange(new object[] { "PC", "360", "PS3" });
            ConsoleSelect.Location = new System.Drawing.Point(62, 10);
            ConsoleSelect.Name = "ConsoleSelect";
            ConsoleSelect.Size = new System.Drawing.Size(348, 23);
            ConsoleSelect.TabIndex = 1;
            // 
            // convertButton
            // 
            convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            convertButton.BackColor = System.Drawing.Color.OliveDrab;
            convertButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            convertButton.Location = new System.Drawing.Point(3, 157);
            convertButton.Name = "convertButton";
            convertButton.Size = new System.Drawing.Size(407, 23);
            convertButton.TabIndex = 3;
            convertButton.Text = "Convert!";
            convertButton.UseVisualStyleBackColor = false;
            convertButton.Click += convertButton_Click;
            // 
            // ImportSGH
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(419, 450);
            Controls.Add(tableLayoutPanel1);
            Text = "Import SGH Archive";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private CheckedListBox songList;
        private System.Windows.Forms.Button importSghFile;
        private TableLayoutPanel tableLayoutPanel2;
        private Label consoleLabel;
        private ComboBox ConsoleSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}