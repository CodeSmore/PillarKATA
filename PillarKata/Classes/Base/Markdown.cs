using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata.Classes.Base
{
    public class Markdown
    {
        public string ItemName { get; set; }
        public decimal MarkdownAmount { get; set; }

        public Markdown(string name, decimal amount)
        {
            ItemName = name;
            MarkdownAmount = amount;
        }
    }
}
