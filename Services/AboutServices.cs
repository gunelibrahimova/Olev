using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutServices
    {
        private readonly OleevDbContext _context;

        public AboutServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<AboutLanguage> GetAll()
        {
            var about = _context.aboutLanguages.Include(x=>x.About).Where(x=>x.LangCode == "AZ").ToList();
            return about;
        }

        public void CreateAbout(string Title, string Description, string LangCode, string SEO, string PhotoURL)
        {
            About about = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
            };
            _context.abouts.Add(about);
            _context.SaveChanges();

           
                AboutLanguage aboutLanguages = new()
                {
                    Title = Title,
                    Description = Description,
                    LangCode = LangCode,
                    SEO = SEO,
                    AboutID = about.Id
                };
                _context.aboutLanguages.Add(aboutLanguages);
            

            _context.SaveChanges();
        }


    }
}
