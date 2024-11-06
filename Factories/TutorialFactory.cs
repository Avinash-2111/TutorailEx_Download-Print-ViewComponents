using TutorialEx.Models;
using TutorialEx.Repository;

namespace TutorialEx.Factories
{
    public class TutorialFactory : ITutorialFactory
    {
        private readonly ITutorialRepository _tutorialRepository;
        public TutorialFactory(ITutorialRepository tutorialRepository)
        {
           _tutorialRepository= tutorialRepository;
        }

        public Task<Tutorial> AddTutorial(Tutorial tutorial)
        {
            try
            {
                var result = _tutorialRepository.AddTutorial(tutorial);
                return result;
            }
            catch (Exception ex)

            {
                throw new NotImplementedException(ex.Message);
            }
           
        }

        public async Task<Tutorial> DeleteTutorialById(int id)
        {
            try
            {
                var result = await _tutorialRepository.DeleteTutorialById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Tutorial> EditTutorial(Tutorial tutorial)
        {
            try
            {
                var result=await _tutorialRepository.EditTutorial(tutorial);
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<Tutorial>> GetAllTutorials()
        {
            try
            { 
                var list=await _tutorialRepository.GetAllTutorials();
                return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Tutorial> GetTutorialById(int id)
        {
            try {
                var result = await _tutorialRepository.GetTutorialById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

       
    }
}
