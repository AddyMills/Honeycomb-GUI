namespace GH_Toolkit_GUI
{
    partial class MasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            toolStrip1 = new ToolStrip();
            FileButton = new ToolStripDropDownButton();
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            wadExplorerButton = new Button();
            pakToolsButton = new Button();
            importSGH = new Button();
            label1 = new Label();
            songlistManagerButton = new Button();
            consoleOutput = new TextBox();
            toolStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { FileButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(458, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // FileButton
            // 
            FileButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            FileButton.ForeColor = SystemColors.ControlText;
            FileButton.ImageTransparentColor = Color.Magenta;
            FileButton.Name = "FileButton";
            FileButton.ShowDropDownArrow = false;
            FileButton.Size = new Size(29, 22);
            FileButton.Text = "File";
            FileButton.ToolTipText = "File";
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(430, 57);
            button1.TabIndex = 1;
            button1.Text = "Compile a Song";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(wadExplorerButton, 0, 2);
            tableLayoutPanel1.Controls.Add(pakToolsButton, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(importSGH, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 3);
            tableLayoutPanel1.Controls.Add(songlistManagerButton, 0, 5);
            tableLayoutPanel1.Location = new Point(10, 22);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0004959F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9985046F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0005016F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0005016F));
            tableLayoutPanel1.Size = new Size(436, 330);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // wadExplorerButton
            // 
            wadExplorerButton.Dock = DockStyle.Fill;
            wadExplorerButton.Location = new Point(3, 128);
            wadExplorerButton.Name = "wadExplorerButton";
            wadExplorerButton.Size = new Size(430, 56);
            wadExplorerButton.TabIndex = 6;
            wadExplorerButton.Text = "PS2 Archive Tools";
            wadExplorerButton.UseVisualStyleBackColor = true;
            wadExplorerButton.Click += wadExplorerButton_Click;
            // 
            // pakToolsButton
            // 
            pakToolsButton.Dock = DockStyle.Fill;
            pakToolsButton.Location = new Point(3, 66);
            pakToolsButton.Name = "pakToolsButton";
            pakToolsButton.Size = new Size(430, 56);
            pakToolsButton.TabIndex = 5;
            pakToolsButton.Text = "PAK Tools";
            pakToolsButton.UseVisualStyleBackColor = true;
            pakToolsButton.Click += pakToolsButton_Click;
            // 
            // importSGH
            // 
            importSGH.Dock = DockStyle.Fill;
            importSGH.Location = new Point(3, 204);
            importSGH.Margin = new Padding(3, 2, 3, 2);
            importSGH.Name = "importSGH";
            importSGH.Size = new Size(430, 59);
            importSGH.TabIndex = 2;
            importSGH.Text = "Import SGH Archive";
            importSGH.UseVisualStyleBackColor = true;
            importSGH.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 187);
            label1.Name = "label1";
            label1.Size = new Size(430, 15);
            label1.TabIndex = 3;
            label1.Text = "Other Tools";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // songlistManagerButton
            // 
            songlistManagerButton.AutoSize = true;
            songlistManagerButton.Dock = DockStyle.Fill;
            songlistManagerButton.Location = new Point(3, 268);
            songlistManagerButton.Name = "songlistManagerButton";
            songlistManagerButton.Size = new Size(430, 59);
            songlistManagerButton.TabIndex = 4;
            songlistManagerButton.Text = "PC Songlist Manager";
            songlistManagerButton.UseVisualStyleBackColor = true;
            songlistManagerButton.Click += songlistManagerClick;
            // 
            // consoleOutput
            // 
            consoleOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleOutput.Location = new Point(10, 357);
            consoleOutput.Multiline = true;
            consoleOutput.Name = "consoleOutput";
            consoleOutput.ReadOnly = true;
            consoleOutput.ScrollBars = ScrollBars.Vertical;
            consoleOutput.Size = new Size(436, 272);
            consoleOutput.TabIndex = 3;
            // 
            // MasterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 641);
            Controls.Add(consoleOutput);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MasterForm";
            Text = "Guitar Hero Toolkit";
            Load += MasterForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton FileButton;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button importSGH;
        private TextBox consoleOutput;
        private Label label1;
        private Button songlistManagerButton;
        private Button wadExplorerButton;
        private Button pakToolsButton;
    }
}
