using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class ExpertiseController : Controller
    {
        private readonly ExpertiseServices _services;
        private IWebHostEnvironment _environment;

        public ExpertiseController(ExpertiseServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var expertise = _services.GetAll();
            return View(expertise);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Expertise expertise, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, List<string> SEO, string PhotoURL, string IconURL)
        {
            _services.Ccreate(expertise);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateExpertise(expertise.Id, Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], SEO[i], PhotoURL, IconURL);
            }

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                expertiseLanguages = _services.GetById(id),
                Expertise = _services.GetExpertiseById(id)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Expertise expertise, int ExpertiseID, List<int> LangID, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, string PhotoURL, string IconURL, IFormFile Image, string OldPhoto)
        {

            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                for (int i = 0; i < Title.Count; i++)
                {
                    _services.EditExpertise(expertise, ExpertiseID, LangID[i], Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], path, IconURL);
                }

                expertise.PhotoURL = path;
            }
            else
            {
                expertise.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
