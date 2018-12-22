using PillarKata.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata.Classes.Data
{
    public class MarkdownCatalogue
    {
        public List<Markdown> Markdowns { get; set; }

        public MarkdownCatalogue()
        {
            Markdowns = new List<Markdown>();

            Markdowns.Add(new Markdown("popcorn", 0.10m));
        }
    }
}
