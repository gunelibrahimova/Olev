
using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class StudyController : Controller
    {
        private readonly StudyServices _services;
        private IWebHostEnvironment _environment;

        public StudyController(StudyServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var study = _services.GetAll();
            return View(study);
        }

            [HttpGet]
            public IActionResult Create()
            {
                return View();

            }

            [HttpPost]
            public IActionResult Create(Study study, List<string> Title, List<string> Description, List<string> Name, List<string> Job, List<string> LangCode, List<string> SEO, string PhotoURL)
            {
                _services.Ccreate(study);
                for (int i = 0; i < Title.Count; i++)
                {
                    _services.CreateStudy(study.Id, Title[i], Description[i], Name[i], Job[i], LangCode[i], SEO[i], PhotoURL);
                }

                return RedirectToAction(nameof(Index));
            }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            EditVM editVM = new()
            {
                StudyLanguages = _services.GetById(id.Value),
                Study = _services.GetStudyById(id.Value)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Study study, int StudyID, List<int> LangID, List<string> Title, List<string> Description, List<string> Name, List<string> Job, List<string> LangCode, string PhotoURL, IFormFile Image, string OldPhoto)
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
                    _services.EditStudy(study, StudyID, LangID[i], Title[i], Description[i], Name[i], Job[i], LangCode[i], path);
                }

                study.PhotoURL = path;
            }
            else
            {
                study.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
