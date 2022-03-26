using Entities;
using K205Oleev.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Oleev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly ProductServices _productServices;
        private readonly OurServiceServices _urServiceServices;
        private readonly CountDownServices _countdownServices;
        private readonly CaseServices _caseServices;
        private readonly ChooseServices _chooseServices;
        private readonly StudyServices _studyServices;
        private readonly ExpertiseServices _expertiseServices;
        private readonly ArticleServices _articleServices;
        private readonly TeamServices _teamServices;

        public HomeController(ILogger<HomeController> logger, AboutServices aboutServices, ProductServices productServices, OurServiceServices urServiceServices, CountDownServices countdownServices, CaseServices caseServices, ChooseServices chooseServices, StudyServices studyServices, ExpertiseServices expertiseServices, ArticleServices articleServices, TeamServices teamServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _productServices = productServices;
            _urServiceServices = urServiceServices;
            _countdownServices = countdownServices;
            _caseServices = caseServices;
            _chooseServices = chooseServices;
            _studyServices = studyServices;
            _expertiseServices = expertiseServices;
            _articleServices = articleServices;
            _teamServices = teamServices;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];

            HomeVM homeVM = new()
            {
                AboutLanguages = _aboutServices.GetAll(langCode),
                ProductLanguages = _productServices.GetAll(),
                ourServiceLanguages = _urServiceServices.GetAll(),
                CountDownLanguages = _countdownServices.GetAll(),
                CaseLanguages = _caseServices.GetAll(),
                chooseLanguages = _chooseServices.GetAll(),
                studyLanguages = _studyServices.GetAll(),
                expertiseLanguages = _expertiseServices.GetAll(),
                articleLanguages = _articleServices.GetAll(),
                teamLanguages = _teamServices.GetAll()

            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}