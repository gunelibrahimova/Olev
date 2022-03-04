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
    public class InfoController : Controller
    {
        private readonly InfoServices _services;

        public InfoController(InfoServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var info = _services.GetAll();
            return View(info);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateInfo(Title[i], Description[i], LangCode[i], SEO[i], PhotoURL);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //EditVM editVM = new()
            //{
            //    infoLanguages = _context.infoLanguages.Include(x => x.Info).Where(x => x.InfoID == id).ToList(),
            //    Info = _context.infos.FirstOrDefault(x => x.Id == id.Value)

            //};
            //return View(editVM);
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int InfoID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, string PhotoURL)
        {
            //for (int i = 0; i < Title.Count; i++)
            //{
            //    SEO seo = new();
            //    InfoLanguage infoLanguage = new()
            //    {

            //        Id = LangID[i],
            //        Title = Title[i],
            //        Description = Description[i],
            //        SEO = seo.SeoURL(Title[i]),
            //        LangCode = LangCode[i],
            //        InfoID = InfoID

            //    };

            //    var updateEntity = _context.Entry(infoLanguage);
            //    updateEntity.State = EntityState.Modified;



            //}
            //_context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
