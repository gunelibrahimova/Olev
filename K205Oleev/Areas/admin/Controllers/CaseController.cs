using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class CaseController : Controller
    {
        private readonly CaseServices _services;

        public CaseController(CaseServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var cases = _services.GetAll();
            return View(cases);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Case casee, List<string> Title, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            _services.Ccreate(casee);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCase( casee.Id, Title[i], LangCode[i], SEO[i], PhotoURL);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
