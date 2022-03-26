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
    public class CountDownServices
    {
        private readonly OleevDbContext _context;

        public CountDownServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CountDownLanguage> GetAll()
        {
            var countdown = _context.countDownLanguages.Include(x => x.CountDown).Where(x => x.LangCode == "Az").ToList();
            return countdown;
        }

        public CountDown Ccreate(CountDown countDown)
        {
            _context.countdowns.Add(countDown);
            _context.SaveChanges();
            return countDown;
        }

        public void CreateCountDown( int CountDownID,string Title,string LangCode, string SEO, int Count)
        {
           

                CountDownLanguage countDownLanguage = new()
                {
                    Title = Title,
                    LangCode = LangCode,
                    SEO = SEO,
                    CountDownID = CountDownID
                   
                };
                _context.countDownLanguages.Add(countDownLanguage);
            

            _context.SaveChanges();
        }


        public List<CountDownLanguage> GetById(int id)
        {
            return _context.countDownLanguages.Where(x => x.CountDownID== id).ToList();
        }

        public CountDown GetCountById(int id)
        {
            return _context.countdowns.FirstOrDefault(x => x.Id == id);
        }

        public void EditInfoList(CountDown countDown, CountDownLanguage countDownLanguage)
        {
            countDownLanguage.SEO = "asdfg";
            _context.countDownLanguages.Update(countDownLanguage);
            _context.countdowns.Update(countDown);
            _context.SaveChanges();
        }

        public void EditCount(CountDown countDown,  int CountDownID, int LangID, string Title, string LangCode)
        {
                SEO seo = new();

              _context.countdowns.Update(countDown);



            CountDownLanguage countDownLanguage = new()
                {

                    Id = LangID,
                    Title = Title,
                    SEO = seo.SeoURL(Title),
                    LangCode = LangCode,
                    CountDownID = CountDownID

                };

                var updateEntity = _context.Entry(countDownLanguage);
                updateEntity.State = EntityState.Modified;



            
            _context.SaveChanges();
        }
    }
}
