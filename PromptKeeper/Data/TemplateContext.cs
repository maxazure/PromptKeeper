using Microsoft.EntityFrameworkCore;
using PromptKeeper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptKeeper.Data
{
    public class TemplateContext : DbContext
    {
        public DbSet<Template> Templates { get; set; }
        public DbSet<GeneratedContent> GeneratedContents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 指定数据库文件的位置，也可以用绝对路径
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
