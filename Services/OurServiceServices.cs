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
    }
}
