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

        public List<InfoLanguage> GetById(int id)
        {
            return _context.infoLanguages.Where(x => x.InfoID == id).ToList();
        }

        public Info GetInfoById(int id)
        {
            return _context.infos.FirstOrDefault(x => x.Id == id);
        }

        public void EditInfoList(Info info, InfoLanguage infoLanguage)
        {
            infoLanguage.SEO = "asdfg";
            info.PhotoURL = "asdfg";
            _context.infoLanguages.Update(infoLanguage);
            _context.infos.Update(info);
            _context.SaveChanges();
        }

        public void EditInfo(Info info, int InfoID, int LangID, string Title, string Description, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            info.PhotoURL = PhotoURL;



            _context.infos.Update(info);



            InfoLanguage infoLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                InfoID = InfoID
            };
            var updatedEntity = _context.Entry(infoLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}