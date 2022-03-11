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
    public class StudyServices
    {
        private readonly OleevDbContext _context;

        public StudyServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<StudyLanguage> GetAll()
        {
            var study = _context.studyLanguages.Include(x => x.Study).Where(x => x.LangCode == "Az").ToList();
            return study;
        }


        public Study Ccreate(Study study)
        {
            _context.study.Add(study);
            _context.SaveChanges();
            return study;
        }

        public void CreateStudy(int StudyID, string Title, string Description, string Name, string Job, string LangCode, string SEO, string PhotoURL)
        {
            StudyLanguage studyLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                Name = Name,
                Job = Job,
                SEO = SEO,
                StudyID = StudyID
            };
            _context.studyLanguages.Add(studyLanguages);


            _context.SaveChanges();
        }

        public List<StudyLanguage> GetById(int id)
        {
            return _context.studyLanguages.Where(x => x.StudyID == id).ToList();
        }

        public Study GetStudyById(int id)
        {

            return _context.study.FirstOrDefault(x => x.Id == id);
        }

        public void EditStudyList(Study study, StudyLanguage studyLanguage)
        {
            studyLanguage.SEO = "asdfg";
            study.PhotoURL = "asdfg";
            _context.studyLanguages.Update(studyLanguage);
            _context.study.Update(study);
            _context.SaveChanges();
        }

        public void EditStudy(Study study, int StudyID, int LangID, string Title, string Description, string Name, string Job, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            study.PhotoURL = PhotoURL;



            _context.study.Update(study);



            StudyLanguage studyLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                Name = Name,
                Job = Job,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                StudyID = StudyID
            };
            var updatedEntity = _context.Entry(studyLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
