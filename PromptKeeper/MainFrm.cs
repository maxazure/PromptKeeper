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
            // ���������Ĳ˵�����Ӳ˵���
            listBoxContextMenu = new ContextMenuStrip();
            listBoxContextMenu.Items.Add("����ģ��", null, AddTemplate_Click);
            listBoxContextMenu.Items.Add("�޸�", null, EditTemplate_Click);
            listBoxContextMenu.Items.Add("ɾ��", null, DeleteTemplate_Click);

            // �������Ĳ˵������� ListBox
            templateListBox.ContextMenuStrip = listBoxContextMenu;

            // ����������Ĳ˵�ǰ���¼����Ը��²˵���״̬
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
                descriptionLabel.Text = selectedTemplate.Description;  // ���� Label ��ʾѡ����ģ������
            }
            else
            {
                descriptionLabel.Text = "��ѡ��һ��ģ��鿴���顣";  // δѡ���κ�ģ��ʱ��Ĭ���ı�
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

                    // ֻ�е��б�����ѡ����ʱ���޸ĺ�ɾ���˵���ſ���
                    listBoxContextMenu.Items[1].Enabled = itemSelected;  // �޸�
                    listBoxContextMenu.Items[2].Enabled = itemSelected;  // ɾ��
                }
            }
        }


        private void AddTemplate_Click(object sender, EventArgs e)
        {
            // ��ʾ�����ģ��Ĵ���
            var addForm = new TemplateForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadTemplates();
            }
        }

        private void EditTemplate_Click(object sender, EventArgs e)
        {
            // �༭ѡ����ģ��
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
            // ɾ��ѡ����ģ��
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
                // �������ݿ⣨������������ڵĻ���
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
            // ȷ���Ѿ�ѡ����һ��ģ��
            if (templateListBox.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��һ��ģ�壡");
                return;
            }

            // ��ȡѡ����ģ����û�����
            var selectedTemplate = (Template)templateListBox.SelectedItem;
            var userInput = inputTextBox.Text;

            // �������ݣ�����򵥵ؽ�ģ���������û������������
            // ʵ�������߼����ܸ����ӣ�ȡ����ģ��ľ�����;
            var generatedContent = $"{selectedTemplate.ContextInfo} \r\n------\r\n {userInput}";

            // ��ʾ���ɵ�����
            resultTextBox.Text = generatedContent;

            // ʹ�� TemplateService �������ɵ����ݵ����ݿ�
            var templateService = new TemplateService();
            templateService.RecordGeneratedContent(selectedTemplate.Id, generatedContent);

            // ��ѡ����ʾ�ɹ���Ϣ
            MessageBox.Show("�������ɲ��ѱ���ɹ���");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ����Ƿ����� Shift + Enter ��ϼ�
            if (keyData == (Keys.Shift | Keys.Enter))
            {
                // �������ɰ�ť�ĵ���¼�
                generateButton.PerformClick();
                return true;  // ��ʾ�����¼��Ѵ�������Ҫ��һ������
            }

            return base.ProcessCmdKey(ref msg, keyData);  // ����������Ĭ�ϴ���
        }

        private async void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncData();
        }

        private async void SyncData()
        {
            try
            {
                SetSyncStatus("ͬ����...");
                await _networkService.SyncFromServer(LocalDatabaseUpdate);
                var templates = _templateService.GetAllTemplates();
                await _networkService.SyncToServer(templates);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ͬ��ʧ��: " + ex.Message);
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
