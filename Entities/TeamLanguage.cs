using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TeamLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string Info { get; set; }
        public string LangCode { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
        public string SEO { get; set; }
    }
}
