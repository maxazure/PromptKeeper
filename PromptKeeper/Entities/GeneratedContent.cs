using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptKeeper.Entities
{
    public class GeneratedContent
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;

        // 外键关联到 Template
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
