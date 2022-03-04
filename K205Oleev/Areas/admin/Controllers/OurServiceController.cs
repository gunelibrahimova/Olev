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
    public class OurServiceController : Controller
    {
        private readonly OurServiceServices _services;
        private IWebHostEnvironment _environment;
        public OurServiceController(OleevDbContext context, IWebHostEnvironment environment, OurServiceServices services)
        {

            _environment = environment;
            _services = services;
        }
        public IActionResult Index()
        {
            var service = _services.GetAll();
            return View(service);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL, string IconURL)
        {
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurService(Title[i], Description[i], LangCode[i], SEO[i], PhotoURL, IconURL);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //EditVM editVM = new()
            //{
            //    ourServiceLanguages = _context.ourServiceLanguages.Include(x => x.OurServices).Where(x => x.OurServiceID == id).ToList(),
            //    OurService = _context.services.FirstOrDefault(x => x.Id == id),
            //};

            //return View(editVM);
            return null;
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int OurServiceID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, string PhotoURL)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();
            //    OurServiceLanguage ourServiceLanguage = new()
            //    {

            //        Id = LangID[i],
            //        Title = Title[i],
            //        Description = Description[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        OurServiceID = OurServiceID

            //    };

            //    var updateEntity = _context.Entry(ourServiceLanguage);
            //    updateEntity.State = EntityState.Modified;



            //}
            //_context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

    }
}
