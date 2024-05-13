namespace PromptKeeper
{
    partial class MainFrm
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
            components = new System.ComponentModel.Container();
            templateListBox = new ListBox();
            descriptionLabel = new Label();
            resultTextBox = new TextBox();
            inputTextBox = new TextBox();
            generateButton = new Button();
            listBoxContextMenu = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            操作ToolStripMenuItem = new ToolStripMenuItem();
            syncToolStripMenuItem = new ToolStripMenuItem();
            generationLogToolStripMenuItem = new ToolStripMenuItem();
            syncLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // templateListBox
            // 
            templateListBox.Dock = DockStyle.Left;
            templateListBox.FormattingEnabled = true;
            templateListBox.ItemHeight = 24;
            templateListBox.Location = new Point(0, 0);
            templateListBox.Margin = new Padding(4);
            templateListBox.Name = "templateListBox";
            templateListBox.Size = new Size(269, 1224);
            templateListBox.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(302, 31);
            descriptionLabel.Margin = new Padding(4, 0, 4, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(0, 24);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultTextBox
            // 
            resultTextBox.Dock = DockStyle.Top;
            resultTextBox.Location = new Point(4, 4);
            resultTextBox.Margin = new Padding(4);
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(1625, 858);
            resultTextBox.TabIndex = 2;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(4, 870);
            inputTextBox.Margin = new Padding(4);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(1498, 322);
            inputTextBox.TabIndex = 3;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(1510, 870);
            generateButton.Margin = new Padding(4);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(115, 322);
            generateButton.TabIndex = 4;
            generateButton.Text = "生成\r\n(Shift+Enter)";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // listBoxContextMenu
            // 
            listBoxContextMenu.ImageScalingSize = new Size(20, 20);
            listBoxContextMenu.Name = "listBoxContextMenu";
            listBoxContextMenu.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 操作ToolStripMenuItem });
            menuStrip1.Location = new Point(269, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1629, 32);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            操作ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { syncToolStripMenuItem, generationLogToolStripMenuItem });
            操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            操作ToolStripMenuItem.Size = new Size(62, 28);
            操作ToolStripMenuItem.Text = "菜单";
            // 
            // syncToolStripMenuItem
            // 
            syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            syncToolStripMenuItem.Size = new Size(182, 34);
            syncToolStripMenuItem.Text = "同步数据";
            syncToolStripMenuItem.Click += syncToolStripMenuItem_Click;
            // 
            // generationLogToolStripMenuItem
            // 
            generationLogToolStripMenuItem.Name = "generationLogToolStripMenuItem";
            generationLogToolStripMenuItem.Size = new Size(182, 34);
            generationLogToolStripMenuItem.Text = "生成日志";
            // 
            // syncLabel
            // 
            syncLabel.AutoSize = true;
            syncLabel.ForeColor = SystemColors.Highlight;
            syncLabel.Location = new Point(1329, 34);
            syncLabel.Margin = new Padding(4, 0, 4, 0);
            syncLabel.Name = "syncLabel";
            syncLabel.Size = new Size(0, 24);
            syncLabel.TabIndex = 6;
            syncLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(resultTextBox);
            flowLayoutPanel1.Controls.Add(inputTextBox);
            flowLayoutPanel1.Controls.Add(generateButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(269, 32);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1629, 1192);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1224);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(syncLabel);
            Controls.Add(menuStrip1);
            Controls.Add(descriptionLabel);
            Controls.Add(templateListBox);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainFrm";
            Text = "PromptKeeper 提示词工具";
            FormClosing += MainFrm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox templateListBox;
        private Label descriptionLabel;
        private TextBox resultTextBox;
        private TextBox inputTextBox;
        private Button generateButton;
        private ContextMenuStrip listBoxContextMenu;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 操作ToolStripMenuItem;
        private ToolStripMenuItem syncToolStripMenuItem;
        private ToolStripMenuItem generationLogToolStripMenuItem;
        private Label syncLabel;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
