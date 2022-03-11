using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class TeamController : Controller
    {
        private readonly TeamServices _services;
        private IWebHostEnvironment _environment;

        public TeamController(TeamServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var team = _services.GetAll();
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Team team, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            _services.Ccreate(team);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateTeam(team.Id, Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], SEO[i], PhotoURL);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                teamLanguages = _services.GetById(id),
                Team = _services.GetTeamById(id)
            };
            return View(editVM);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Team team, int TeamID, List<int> LangID, List<string> Title, List<string> Description, List<string> SubTitle, List<string> Info, List<string> LangCode, string PhotoURL, IFormFile Image, string OldPhoto)
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
                    _services.EditTeam(team, TeamID, LangID[i], Title[i], Description[i], SubTitle[i], Info[i], LangCode[i], path);
                }

                team.PhotoURL = path;
            }
            else
            {
                team.PhotoURL = OldPhoto;
            }
            //_services.EditAboutList(about, aboutLanguage);
            return RedirectToAction(nameof(Index));
        }
    }
}
