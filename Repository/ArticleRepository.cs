using Microsoft.EntityFrameworkCore;
using TutorialEx.Context;
using TutorialEx.Models;

namespace TutorialEx.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public ArticleRepository(TutorialDbContext tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }
        public Task<Article> AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<Article> DeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllArticles()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Article>> GetArticleByTutorialId(int tutorialId)
        {
            try
            {
                var tutorials = await _tutorialDbContext.Tutorials.Where(x => x.Id == tutorialId).ToListAsync();
                var articles = tutorials.Select(tutorial => new Article
                {
                    ArticleTitle = tutorial.TutorialName,
                    ArticleContent = tutorial.TutorialDescription
                }).ToList();
                return articles;
                //var List=await _tutorialDbContext.Articles.Where(x=>x.TutorialId==tutorialId).ToListAsync();
                //return List;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.Message);

              };
        }

        public Task<Article> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
