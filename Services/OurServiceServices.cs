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
    public class OurServiceServices
    {
        private readonly OleevDbContext _context;

        public OurServiceServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<OurServiceLanguage> GetAll()
        {
            var service = _context.ourServiceLanguages.Include(x => x.OurServices).Where(x => x.LangCode == "Az").ToList();
            return service;
        }

        public void CreateOurService(string Title, string Description, string LangCode, string SEO, string PhotoURL, string IconURL)
        {
            OurService ourService = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
                IconURL = IconURL,
            };
            _context.services.Add(ourService);
            _context.SaveChanges();


            OurServiceLanguage ourServiceLanguage = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                OurServiceID = ourService.Id
            };
            _context.ourServiceLanguages.Add(ourServiceLanguage);


            _context.SaveChanges();
        }


        public List<OurServiceLanguage> GetById(int id)
        {
            return _context.ourServiceLanguages.Where(x => x.OurServiceID == id).ToList();
        }

        public OurService GetServiceById(int id)
        {

            return _context.services.FirstOrDefault(x => x.Id == id);
        }

        public void EditServiceList(OurService ourService, OurServiceLanguage ourserviceLanguage)
        {
            ourserviceLanguage.SEO = "asdfg";
            ourService.PhotoURL = "asdfg";
            _context.ourServiceLanguages.Update(ourserviceLanguage);
            _context.services.Update(ourService);
            _context.SaveChanges();
        }

        public void EditService(OurService ourService,int OurServiceID, int LangID, string Title, string Description, string LangCode, string PhotoURL, string IconURL)
        {
            SEO seo = new();

            ourService.PhotoURL = PhotoURL;
            ourService.IconURL = IconURL;


            _context.services.Update(ourService);



            OurServiceLanguage ourServiceLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                OurServiceID = OurServiceID
            };
            var updatedEntity = _context.Entry(ourServiceLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
