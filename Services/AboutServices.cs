using DataAccess;
using Entities;
using Helper.Methods;
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

        public List<İnfoLanguage> GetAll(string lang)
        {
            var about = _context.aboutLanguages.Include(x=>x.About).Where(x=>x.LangCode == lang).ToList();
            return about;
        }


        public About Ccreate(About about)
        {
            _context.abouts.Add(about);
            _context.SaveChanges();
            return about;
        }

        public void CreateAbout(int AboutID, string Title, string Description, string LangCode, string SEO, string PhotoURL)
        {
                İnfoLanguage aboutLanguages = new()
                {
                    Title = Title,
                    Description = Description,
                    LangCode = LangCode,
                    SEO = SEO,

                    AboutID = AboutID
                };
                _context.aboutLanguages.Add(aboutLanguages);
            

            _context.SaveChanges();
        }

        public List<İnfoLanguage> GetById(int id)
        {
            return _context.aboutLanguages.Where(x=>x.AboutID == id).ToList();
        }

        public About GetAboutById(int id)
        {
            
            return _context.abouts.FirstOrDefault(x => x.Id == id);
        }

        public void EditAboutList(About about, İnfoLanguage aboutLanguage)
        {
            aboutLanguage.SEO = "asdfg";
            about.PhotoURL = "asdfg";
            _context.aboutLanguages.Update(aboutLanguage);
            _context.abouts.Update(about);
            _context.SaveChanges();
        }

        public void EditAbout(About about,int AboutID, int LangID, string Title, string Description, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            about.PhotoURL = PhotoURL;



            _context.abouts.Update(about);
            


            İnfoLanguage aboutLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                AboutID = AboutID
            };
            var updatedEntity = _context.Entry(aboutLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
