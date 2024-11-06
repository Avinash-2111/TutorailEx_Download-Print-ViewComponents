using TutorialEx.Models;

namespace TutorialEx.Repository
{
    public interface ITutorialRepository
    {
        public  Task<Tutorial> AddTutorial(Tutorial tutorial);
       public  Task<Tutorial> EditTutorial(Tutorial tutorial);

        public Task<Tutorial> DeleteTutorialById(int id);
        public Task<Tutorial> GetTutorialById(int id);
        public Task<List<Tutorial>> GetAllTutorials();
    }
}
