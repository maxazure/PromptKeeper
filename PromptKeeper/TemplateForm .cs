using PromptKeeper.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromptKeeper
{
    public partial class TemplateForm : Form
    {
        private Template template;
        private TemplateService templateService = new TemplateService();

        public TemplateForm(Template template = null)
        {
            InitializeComponent();
            this.template = template;

            if (template != null)
            {
                // 如果传入了模板，则是编辑状态，加载模板数据
                txtTitle.Text = template.Name;
                txtDescription.Text = template.Description;
                txtContextInfo.Text = template.ContextInfo;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (template == null)
            {
                template = new Template();
            }

            // 从表单获取数据更新模板
            template.Name = txtTitle.Text;
            template.Description = txtDescription.Text;
            template.ContextInfo = txtContextInfo.Text;

            // 使用 TemplateService 保存模板
            if (template.Id == 0)
                templateService.AddTemplate(template);
            else
                templateService.UpdateTemplate(template);

            this.DialogResult = DialogResult.OK;
        }
    }

}
