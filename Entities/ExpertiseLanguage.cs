using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExpertiseLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string Info { get; set; }
        public string LangCode { get; set; }
        public int ExpertiseID { get; set; }
        public virtual Expertise Expertise { get; set; }
        public string SEO { get; set; }
    }
}
