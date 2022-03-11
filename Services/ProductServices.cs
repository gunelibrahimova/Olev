using DataAccess;
using Entities;
using Helper.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices
    {
        private readonly OleevDbContext _context;

        public ProductServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<ProductLanguage> GetAll()
        {
            var product = _context.productLanguages.Include(x => x.Product).Where(x => x.LangCode == "Az").ToList();
            return product;
        }


        public Product Ccreate(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void CreateProduct(int ProductID, string Title, string Description, string LangCode, string SEO)
        {
            ProductLanguage productLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                ProductID = ProductID
            };
            _context.productLanguages.Add(productLanguages);


            _context.SaveChanges();
        }


        public List<ProductLanguage> GetById(int id)
        {
            return _context.productLanguages.Where(x => x.ProductID == id).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.products.FirstOrDefault(x => x.Id == id);
        }

        public void EditProductList(Product product, ProductLanguage productLanguage)
        {
            productLanguage.SEO = "asdfg";
            _context.productLanguages.Update(productLanguage);
            _context.products.Update(product);
            _context.SaveChanges();
        }

        public void EditProduct(Product product, int ProductID, int LangID, string Title, string Description, string LangCode)
        {
            SEO seo = new();




            _context.products.Update(product);



            ProductLanguage productLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                ProductID = ProductID
            };
            var updatedEntity = _context.Entry(productLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
