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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // templateListBox
            // 
            templateListBox.Dock = DockStyle.Left;
            templateListBox.FormattingEnabled = true;
            templateListBox.Location = new Point(0, 0);
            templateListBox.Name = "templateListBox";
            templateListBox.Size = new Size(221, 754);
            templateListBox.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(247, 26);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(0, 20);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(247, 69);
            resultTextBox.Multiline = true;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(893, 457);
            resultTextBox.TabIndex = 2;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(247, 553);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(777, 155);
            inputTextBox.TabIndex = 3;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(1046, 553);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(94, 155);
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
            menuStrip1.Location = new Point(221, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(953, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            操作ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { syncToolStripMenuItem, generationLogToolStripMenuItem });
            操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            操作ToolStripMenuItem.Size = new Size(53, 24);
            操作ToolStripMenuItem.Text = "操作";
            // 
            // syncToolStripMenuItem
            // 
            syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            syncToolStripMenuItem.Size = new Size(224, 26);
            syncToolStripMenuItem.Text = "同步数据";
            syncToolStripMenuItem.Click += syncToolStripMenuItem_Click;
            // 
            // generationLogToolStripMenuItem
            // 
            generationLogToolStripMenuItem.Name = "generationLogToolStripMenuItem";
            generationLogToolStripMenuItem.Size = new Size(224, 26);
            generationLogToolStripMenuItem.Text = "生成日志";
            // 
            // syncLabel
            // 
            syncLabel.AutoSize = true;
            syncLabel.ForeColor = SystemColors.Highlight;
            syncLabel.Location = new Point(1087, 28);
            syncLabel.Name = "syncLabel";
            syncLabel.Size = new Size(0, 20);
            syncLabel.TabIndex = 6;
            syncLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 754);
            Controls.Add(syncLabel);
            Controls.Add(menuStrip1);
            Controls.Add(generateButton);
            Controls.Add(inputTextBox);
            Controls.Add(resultTextBox);
            Controls.Add(descriptionLabel);
            Controls.Add(templateListBox);
            MainMenuStrip = menuStrip1;
            Name = "MainFrm";
            Text = "PromptKeeper 提示词工具";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}
