using TutorialEx.Models;
using TutorialEx.Repository;

namespace TutorialEx.Factories
{
    public class ArticleFactory : IArticleFactory
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleFactory(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IArticleRepository ArticleRepository { get; }

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
            return await _articleRepository.GetArticleByTutorialId(tutorialId);
        }

        public Task<Article> UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
