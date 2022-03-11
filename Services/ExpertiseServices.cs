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
    public class ExpertiseServices
    {
        private readonly OleevDbContext _context;

        public ExpertiseServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<ExpertiseLanguage> GetAll()
        {
            var expertise = _context.expertiseLanguages.Include(x => x.Expertise).Where(x => x.LangCode == "Az").ToList();
            return expertise;
        }

        public Expertise Ccreate(Expertise expertise)
        {
            _context.expertises.Add(expertise);
            _context.SaveChanges();
            return expertise;
        }

        public void CreateExpertise(int ExpertiseID, string Title, string Description, string SubTitle, string Info, string LangCode, string SEO, string PhotoURL, string IconURL)
        {
            ExpertiseLanguage expertiseLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SubTitle = SubTitle,
                Info = Info,
                SEO = SEO,
                ExpertiseID = ExpertiseID
            };
            _context.expertiseLanguages.Add(expertiseLanguages);


            _context.SaveChanges();
        }

        public List<ExpertiseLanguage> GetById(int id)
        {
            return _context.expertiseLanguages.Where(x => x.ExpertiseID == id).ToList();
        }

        public Expertise GetExpertiseById(int id)
        {

            return _context.expertises.FirstOrDefault(x => x.Id == id);
        }

        public void EditExpertiseList(Expertise expertise, ExpertiseLanguage expertiseLanguage)
        {
            expertiseLanguage.SEO = "asdfg";
            expertise.PhotoURL = "asdfg";
            _context.expertiseLanguages.Update(expertiseLanguage);
            _context.expertises.Update(expertise);
            _context.SaveChanges();
        }

        public void EditExpertise(Expertise expertise, int ExpertiseID, int LangID, string Title, string Description, string SubTitle, string info, string LangCode, string PhotoURL, string IconURL)
        {
            SEO seo = new();

            expertise.PhotoURL = PhotoURL;
            expertise.IconURL = IconURL;



            _context.expertises.Update(expertise);



            ExpertiseLanguage expertiseLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                Info = info,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                ExpertiseID = ExpertiseID
            };
            var updatedEntity = _context.Entry(expertiseLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
