using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {

        private readonly ProductServices _services;

        public ProductController(ProductServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var product = _services.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Product product, List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO)
        {
            _services.Ccreate(product);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateProduct(product.Id, Title[i], Description[i], LangCode[i], SEO[i]);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                ProductLanguages = _services.GetById(id),
                Product = _services.GetProductById(id)
            };
            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int ProductID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode)
        {

                for (int i = 0; i < Title.Count; i++)
                {
                    _services.EditProduct(product, ProductID, LangID[i], Title[i], Description[i], LangCode[i]);
                }

            
            return RedirectToAction(nameof(Index));
        }
    }
}
