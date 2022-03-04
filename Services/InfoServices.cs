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
    public class InfoServices
    {
        private readonly OleevDbContext _context;

        public InfoServices(OleevDbContext context)
        {
            _context = context;
        }

         public List<InfoLanguage> GetAll()
        {
           var info = _context.infoLanguages.Include(x => x.Info).Where(x => x.LangCode == "Az").ToList();
           return info;
        }

        public void CreateInfo(string Title, string Description, string LangCode, string SEO, string PhotoURL)
        {
            Info info = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
            };
            _context.infos.Add(info);
            _context.SaveChanges();


            InfoLanguage infoLanguage = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                InfoID = info.Id
            };
            _context.infoLanguages.Add(infoLanguage);


            _context.SaveChanges();
        }
    }
}
