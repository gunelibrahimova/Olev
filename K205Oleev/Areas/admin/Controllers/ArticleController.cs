using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class ArticleController : Controller
    {
        private readonly ArticleServices _services;
        private IWebHostEnvironment _environment;

        public ArticleController(ArticleServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var article = _services.GetAll();
            return View(article);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Article article, List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL, string Date)
        {
            _services.Ccreate(article);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateArticle(article.Id, Title[i], Description[i], LangCode[i], SEO[i], PhotoURL, Date);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                articleLanguages = _services.GetById(id),
                Article = _services.GetArticleById(id)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article article, int ArticleID, List<int> LangID, List<string> Title, List<string> Description, string Data, List<string> LangCode, string PhotoURL, IFormFile Image, string OldPhoto)
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
                    _services.EditArticle(article, ArticleID, LangID[i], Title[i], Description[i], Data, LangCode[i], path );
                }

                article.PhotoURL = path;
            }
            else
            {
                article.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
