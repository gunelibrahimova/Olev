using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CaseLanguage : Base
    {
        public string Title { get; set; }
        public string LangCode { get; set; }
        public int CaseID { get; set; }
        public virtual Case Case { get; set; }
        public string SEO { get; set; }
    }
}
