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
            EditVM editVM = new()
            {
                ourServiceLanguages = _services.GetById(id),
                OurService = _services.GetServiceById(id)
            };

            return View(editVM);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(OurService ourService,int OurServiceID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, string PhotoURL, string IconURL, IFormFile Image, string OldPhoto)
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
                    _services.EditService(ourService, OurServiceID, LangID[i], Title[i], Description[i], LangCode[i], path, IconURL);
                }

                ourService.PhotoURL = path;
            }
            else
            {
                ourService.PhotoURL = OldPhoto;
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
