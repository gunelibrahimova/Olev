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
        private IWebHostEnvironment _environment;


        public InfoController(InfoServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
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
            EditVM editVM = new()
            {

                infoLanguages = _services.GetById(id.Value),
                Info = _services.GetInfoById(id.Value)

            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Info info,int InfoID, List<int> LangID, List<string> Title, List<string> Description,  List<string> LangCode, string PhotoURL, IFormFile Image , string OldPhoto)
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
                    _services.EditInfo(info, InfoID, LangID[i], Title[i], Description[i], LangCode[i], path);
                }

                info.PhotoURL = path;
            }

            else
            {
                info.PhotoURL = OldPhoto;
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
