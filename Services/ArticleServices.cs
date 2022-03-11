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
    public class ArticleServices
    {
        private readonly OleevDbContext _context;

        public ArticleServices(OleevDbContext context)
        {
            _context = context;
        }
        public List<ArticleLanguage> GetAll()
        {
            var article = _context.articleLanguages.Include(x => x.Article).Where(x => x.LangCode == "Az").ToList();
            return article;
        }

        public Article Ccreate(Article article)
        {
            _context.articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        public void CreateArticle(int ArticleID, string Title, string Description, string LangCode, string SEO, string PhotoURL, string Date )
        {
            


            ArticleLanguage articleLanguages = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                ArticleID = ArticleID
            };
            _context.articleLanguages.Add(articleLanguages);


            _context.SaveChanges();
        }

        public List<ArticleLanguage> GetById(int id)
        {
            return _context.articleLanguages.Where(x => x.ArticleID == id).ToList();
        }

        public Article GetArticleById(int id)
        {

            return _context.articles.FirstOrDefault(x => x.Id == id);
        }

        public void EditArticleList(Article article, ArticleLanguage articleLanguage)
        {
            articleLanguage.SEO = "asdfg";
            article.PhotoURL = "asdfg";
            _context.articleLanguages.Update(articleLanguage);
            _context.articles.Update(article);
            _context.SaveChanges();
        }

        public void EditArticle(Article article, int ArticleID, int LangID,  string Title, string Description, string Date, string LangCode, string PhotoURL)
        {
            SEO seo = new();



            ArticleLanguage articleLanguage = new()
            {
                Id = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                ArticleID = ArticleID
            };
            var updatedEntity = _context.Entry(articleLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
