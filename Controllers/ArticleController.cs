using Microsoft.AspNetCore.Mvc;
using TutorialEx.Factories;
using TutorialEx.Models;

namespace TutorialEx.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleFactory _articleFactory;

        public ArticleController(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> DisplayArticles(int Id)
        { 
            IEnumerable<Article> articles=await _articleFactory.GetArticleByTutorialId(Id);
            return View(articles);

        }
    }
}
