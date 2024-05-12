using PromptKeeper.Data;
using PromptKeeper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptKeeper
{
    public class TemplateService
    {
        public void AddTemplate(Template template)
        {
            using (var context = new TemplateContext())
            {
                context.Templates.Add(template);
                context.SaveChanges();
            }
        }

        public List<Template> GetAllTemplates()
        {
            using (var context = new TemplateContext())
            {
                return context.Templates.ToList();
            }
        }

        public void UpdateTemplate(Template template)
        {
            using (var context = new TemplateContext())
            {
                context.Templates.Update(template);
                context.SaveChanges();
            }
        }

        public void DeleteTemplate(int id)
        {
            using (var context = new TemplateContext())
            {
                var template = context.Templates.Find(id);
                if (template != null)
                {
                    context.Templates.Remove(template);
                    context.SaveChanges();
                }
            }
        }
        public void RecordGeneratedContent(int templateId, string content)
        {
            using (var context = new TemplateContext())
            {
                var generatedContent = new GeneratedContent
                {
                    TemplateId = templateId,
                    Content = content
                };
                context.GeneratedContents.Add(generatedContent);
                context.SaveChanges();
            }
        }
        public void AddOrUpdate(Template template)
        {
            using (var context = new TemplateContext())  // 假设 TemplateContext 是您的 DbContext
            {
                var existingTemplate = context.Templates.FirstOrDefault(t => t.Id == template.Id);
                if (existingTemplate != null)
                {
                    // 如果模板已存在，更新它
                    existingTemplate.Name = template.Name;
                    existingTemplate.Description = template.Description;
                    existingTemplate.ContextInfo = template.ContextInfo;
                }
                else
                {
                    // 如果模板不存在，添加新的模板
                    context.Templates.Add(template);
                }
                context.SaveChanges();
            }
        }

    }

}
