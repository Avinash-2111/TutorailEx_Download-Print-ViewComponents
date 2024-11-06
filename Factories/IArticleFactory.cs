using TutorialEx.Models;

namespace TutorialEx.Factories
{
    public interface IArticleFactory
    {
        public Task<Article> AddArticle(Article article);

        public Task<Article> UpdateArticle(Article article);
        public Task<Article> DeleteArticleById(int id);
        public Task<Article> GetArticleById(int id);
        public Task<List<Article>> GetAllArticles();
        public Task<List<Article>> GetArticleByTutorialId(int tutorialId);
    }
}
