using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Methods
{
    public class SEO
    {
        public string SeoURL(string link)
        {
            link = link.ToLower()
                // bu gün hər şey yaxşıdır
                // bu-gun-her-sey-yaxsidir
                .Replace("ə", "e")
                .Replace(" ", "-")
                .Replace("ğ", "g")
                .Replace("ç", "c")
                .Replace("ü", "u")
                .Replace("ş", "s")
                .Replace("ö", "o");

            return link;



        }
    }
}
