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
    public class ChooseServices
    {
        private readonly OleevDbContext _context;

        public ChooseServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<ChooseLanguage> GetAll()
        {
            var choose = _context.chooseLanguages.Include(x => x.Choose).Where(x => x.LangCode == "Az").ToList();
            return choose;
        }

        public Choose Ccreate(Choose choose)
        {
            _context.chooses.Add(choose);
            _context.SaveChanges();
            return choose;
        }

        public void CreateChoose(int ChooseID, string Title, string Description, string SubTitle, string Info, string LangCode, string SEO, string PhotoURL, string IconURL)
        {
            ChooseLanguage chooseLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SubTitle = SubTitle,
                Info = Info,
                SEO = SEO,
                ChooseID = ChooseID
            };
            _context.chooseLanguages.Add(chooseLanguages);


            _context.SaveChanges();
        }


        public List<ChooseLanguage> GetById(int id)
        {
            return _context.chooseLanguages.Where(x => x.ChooseID == id).ToList();
        }

        public Choose GetChooseById(int id)
        {

            return _context.chooses.FirstOrDefault(x => x.Id == id);
        }

        public void EditChooseList(Choose choose, ChooseLanguage chooseLanguage)
        {
            chooseLanguage.SEO = "asdfg";
            choose.PhotoURL = "asdfg";
            _context.chooseLanguages.Update(chooseLanguage);
            _context.chooses.Update(choose);
            _context.SaveChanges();
        }

        public void EditChoose(Choose choose, int ChooseID, int LangID, string Title, string Description, string SubTitle, string info, string LangCode, string PhotoURL, string IconURL)
        {
            SEO seo = new();

            choose.PhotoURL = PhotoURL;
            choose.IconURL = IconURL;



            _context.chooses.Update(choose);



            ChooseLanguage chooseLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                Info = info,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                ChooseID = ChooseID
            };
            var updatedEntity = _context.Entry(chooseLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
