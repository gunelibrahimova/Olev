using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class CountDownController : Controller
    {
        private readonly CountDownServices _services;

        public CountDownController(CountDownServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            var Countdown = _services.GetAll();
            return View (Countdown);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> LangCode, List<string> SEO, int Count)
        {
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCountDown(Title[i], LangCode[i], SEO[i], Count);
            }


            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //EditVM editVM = new()
            //{
            //    countDownLanguages = _context.countDownLanguages.Include(x => x.CountDown).Where(x => x.CountDownID == id).ToList(),
            //    CountDown = _context.countdowns.FirstOrDefault(x => x.Id == id),
            //};

            //return View(editVM);
            return null;

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int CountDownID, List<int> LangID, List<string> Title, List<string> LangCode)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();
            //    CountDownLanguage countDownLanguage = new()
            //    {

            //        Id = LangID[i],
            //        Title = Title[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        CountDownID = CountDownID

            //    };

            //    var updateEntity = _context.Entry(countDownLanguage);
            //    updateEntity.State = EntityState.Modified;



            //}
            //_context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
