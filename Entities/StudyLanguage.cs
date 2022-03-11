using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StudyLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string LangCode { get; set; }
        public int StudyID { get; set; }
        public virtual Study Study { get; set; }
        public string SEO { get; set; }
    }
}
