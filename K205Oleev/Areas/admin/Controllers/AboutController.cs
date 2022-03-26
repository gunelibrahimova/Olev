using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;


namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly AboutServices _services;
        
        private IWebHostEnvironment _environment;

        public AboutController(IWebHostEnvironment environment, AboutServices services)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var about = _services.GetAll(langCode);


            if(about.Count > 0)
            {
                ViewBag.Sayi = 1;
            }

            else
            {
                ViewBag.Sayi = 0;

            }

            return View(about);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var about = _services.GetAll(langCode);


            if (about.Count > 0)
            {
                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]
        public IActionResult Create( About about,List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            _services.Ccreate(about);
            for (int i = 0; i < Title.Count ; i++)
            {
                _services.CreateAbout(about.Id, Title[i], Description[i], LangCode[i], SEO[i], PhotoURL);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            EditVM editVM = new()
            {
                aboutLanguages = _services.GetById(id.Value),
                About = _services.GetAboutById(id.Value)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about,int AboutID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, string PhotoURL, IFormFile Image, string OldPhoto)
        {
            
            if(Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                for (int i = 0; i < Title.Count; i++)
                {
                    _services.EditAbout(about, AboutID, LangID[i], Title[i], Description[i], LangCode[i], path);
                }

                about.PhotoURL = path;
            }
            else
            {
                about.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
