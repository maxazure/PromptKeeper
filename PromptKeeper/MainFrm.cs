using PromptKeeper.Data;
using PromptKeeper.Entities;
using System.ComponentModel;

namespace PromptKeeper
{
    public partial class MainFrm : Form
    {

        private readonly NetworkService _networkService;
        private readonly TemplateService _templateService;
        public MainFrm()
        {
            _networkService = new NetworkService();
            _templateService = new TemplateService();

            InitializeComponent();
            InitializeContextMenu();
            this.Load += MainFrm_Load;
            templateListBox.SelectedIndexChanged += TemplateListBox_SelectedIndexChanged;
        }

        private void InitializeContextMenu()
        {
            // 创建上下文菜单并添加菜单项
            listBoxContextMenu = new ContextMenuStrip();
            listBoxContextMenu.Items.Add("新增模板", null, AddTemplate_Click);
            listBoxContextMenu.Items.Add("修改", null, EditTemplate_Click);
            listBoxContextMenu.Items.Add("删除", null, DeleteTemplate_Click);

            // 将上下文菜单关联到 ListBox
            templateListBox.ContextMenuStrip = listBoxContextMenu;

            // 处理打开上下文菜单前的事件，以更新菜单项状态
            listBoxContextMenu.Opening += ListBoxContextMenu_Opening;
        }
        private void TemplateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTemplateDescription();
        }

        private void UpdateTemplateDescription()
        {
            if (templateListBox.SelectedItem != null)
            {
                Template selectedTemplate = templateListBox.SelectedItem as Template;
                descriptionLabel.Text = selectedTemplate.Description;  // 更新 Label 显示选定的模板描述
            }
            else
            {
                descriptionLabel.Text = "请选择一个模板查看详情。";  // 未选择任何模板时的默认文本
            }
        }
        private void ListBoxContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var contextMenuStrip = sender as ContextMenuStrip;
            if (contextMenuStrip != null)
            {
                var listBox = contextMenuStrip.SourceControl as ListBox;
                if (listBox != null)
                {
                    bool itemSelected = listBox.SelectedIndex != -1;

                    // 只有当列表中有选定项时，修改和删除菜单项才可用
                    listBoxContextMenu.Items[1].Enabled = itemSelected;  // 修改
                    listBoxContextMenu.Items[2].Enabled = itemSelected;  // 删除
                }
            }
        }


        private void AddTemplate_Click(object sender, EventArgs e)
        {
            // 显示添加新模板的窗体
            var addForm = new TemplateForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTemplates();
            }
        }

        private void EditTemplate_Click(object sender, EventArgs e)
        {
            // 编辑选定的模板
            if (templateListBox.SelectedItem is Template selectedTemplate)
            {
                var editForm = new TemplateForm(selectedTemplate);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTemplates();
                }
            }
        }

        private void DeleteTemplate_Click(object sender, EventArgs e)
        {
            // 删除选定的模板
            if (templateListBox.SelectedItem is Template selectedTemplate)
            {
                _templateService.DeleteTemplate(selectedTemplate.Id);
                LoadTemplates();
            }
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            EnsureDatabaseCreated();
            LoadTemplates();
            SyncData();
        }
        private void EnsureDatabaseCreated()
        {
            using (var context = new TemplateContext())
            {
                // 创建数据库（如果它还不存在的话）
                context.Database.EnsureCreated();
            }
        }

        private void LoadTemplates()
        {
            try
            {
                var templates = _templateService.GetAllTemplates();
                templateListBox.DataSource = templates;
                templateListBox.DisplayMember = "Name";  // Assumes Template class has a "Name" property to display
                templateListBox.ValueMember = "Id";      // Assumes Template class has an "Id" property as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load templates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void generateButton_Click(object sender, EventArgs e)
        {
            // 确保已经选择了一个模板
            if (templateListBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个模板！");
                return;
            }

            // 获取选定的模板和用户输入
            var selectedTemplate = (Template)templateListBox.SelectedItem;
            var userInput = inputTextBox.Text;

            // 生成内容，这里简单地将模板描述和用户输入组合起来
            // 实际生成逻辑可能更复杂，取决于模板的具体用途
            var generatedContent = $"{selectedTemplate.ContextInfo} \r\n------\r\n {userInput}";

            // 显示生成的内容
            resultTextBox.Text = generatedContent;

            // 使用 TemplateService 保存生成的内容到数据库
            var templateService = new TemplateService();
            templateService.RecordGeneratedContent(selectedTemplate.Id, generatedContent);

            // 可选：显示成功消息
            MessageBox.Show("内容生成并已保存成功！");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 检查是否按下了 Shift + Enter 组合键
            if (keyData == (Keys.Shift | Keys.Enter))
            {
                // 触发生成按钮的点击事件
                generateButton.PerformClick();
                return true;  // 表示键盘事件已处理，不需要进一步传递
            }

            return base.ProcessCmdKey(ref msg, keyData);  // 其他键继续默认处理
        }

        private async void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncData();
        }

        private async void SyncData()
        {
            try
            {
                SetSyncStatus("同步中...");
                await _networkService.SyncFromServer(LocalDatabaseUpdate);
                var templates = _templateService.GetAllTemplates();
                await _networkService.SyncToServer(templates);
            }
            catch (Exception ex)
            {
                MessageBox.Show("同步失败: " + ex.Message);
            }
            finally
            {
                LoadTemplates();
                SetSyncStatus(string.Empty);
            }

        }

        private void LocalDatabaseUpdate(List<Template> templates)
        {
            foreach (var template in templates)
            {
                _templateService.AddOrUpdate(template);
            }
        }

        private void SetSyncStatus(string text)
        {
            syncLabel.Text = text;
        }

    }
}
