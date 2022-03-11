using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChooseLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string Info { get; set; }
        public string LangCode { get; set; }
        public int ChooseID { get; set; }
        public virtual Choose Choose { get; set; }
        public string SEO { get; set; }
    }
}
