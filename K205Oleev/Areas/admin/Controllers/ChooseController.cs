using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class ChooseController : Controller
    {
        private readonly ChooseServices _services;
        private IWebHostEnvironment _environment;

        public ChooseController(ChooseServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var choose = _services.GetAll();
            return View(choose);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Choose choose, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, List<string> SEO, string PhotoURL, string IconURL)
        {
            _services.Ccreate(choose);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateChoose(choose.Id, Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], SEO[i], PhotoURL, IconURL);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                chooseLanguages = _services.GetById(id),
                choose = _services.GetChooseById(id)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Choose choose, int ChooseID, List<int> LangID, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, string PhotoURL, string IconURL, IFormFile Image, string OldPhoto)
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
                    _services.EditChoose(choose, ChooseID, LangID[i], Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], path, IconURL);
                }

                choose.PhotoURL = path;
            }
            else
            {
                choose.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
