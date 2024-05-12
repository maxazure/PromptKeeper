using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptKeeper.Models
{
    internal class PromptTemplate
    {
        public string Name { get; set; }
        public string TemplateText { get; set; }
        public string ContextInformation { get; set; }

        public string GeneratePrompt(string userInput)
        {
            return $"{TemplateText} {userInput} {ContextInformation}";
        }
    }
}
