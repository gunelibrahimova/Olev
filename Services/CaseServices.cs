using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CaseServices
    {
        private readonly OleevDbContext _context;

        public CaseServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CaseLanguage> GetAll()
        {
            var casee = _context.caseLanguages.Include(x => x.Case).Where(x => x.LangCode == "Az").ToList();
            return casee;
        }

        public Case Ccreate(Case cases)
        {
            _context.cases.Add(cases);
            _context.SaveChanges();
            return cases;
        }

        public void CreateCase(int CaseID, string Title, string LangCode, string SEO, string PhotoURL)
        {
            CaseLanguage caseLanguages = new()
            {
                Title = Title,
                LangCode = LangCode,
                SEO = SEO,
                CaseID = CaseID
            };
            _context.caseLanguages.Add(caseLanguages);

            _context.SaveChanges();
        }
    }
}
