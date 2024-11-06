using Microsoft.EntityFrameworkCore;
using TutorialEx.Context;
using TutorialEx.Models;

namespace TutorialEx.Repository
{
    public class TutorialRepository : ITutorialRepository
    {
        private readonly TutorialDbContext _tutorialDbContext;

        public TutorialRepository(TutorialDbContext tutorialDbContext)
        {
            _tutorialDbContext = tutorialDbContext;
        }
      

        public async Task<Tutorial> DeleteTutorialById(int id)
        {
            try {
                var model = await _tutorialDbContext.Tutorials.FindAsync(id);
                if (model != null)
                {
                    var result = _tutorialDbContext.Tutorials.Remove(model);
                    await _tutorialDbContext.SaveChangesAsync();
                    return result.Entity;


                }
                else {
                    throw new NotImplementedException("The Request Cant be Processed");
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            finally {
                _tutorialDbContext.SaveChanges();
            }
            
        }


     

        public async Task<Tutorial> GetTutorialById(int id)
        {
            try { 
                var result=await _tutorialDbContext.Tutorials.FindAsync(id);
                return result;
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.Message);
            }
            finally {
                _tutorialDbContext.SaveChanges();
            }
            
        }

        public async Task<Tutorial> AddTutorial(Tutorial tutorial)
        {
            try
            {
                var result = await _tutorialDbContext.Tutorials.AddAsync(tutorial);
                _tutorialDbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally 
            {
                _tutorialDbContext.SaveChanges();
            }
        }

        public async Task<Tutorial> EditTutorial(Tutorial tutorial)
        {
            try {
                var result = _tutorialDbContext.Tutorials.Update(tutorial);
                _tutorialDbContext.SaveChanges();
                return result.Entity;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            finally { 

                _tutorialDbContext.SaveChanges();
            }
           
        }

       public async  Task<List<Tutorial>> GetAllTutorials()
        {
            try
            {
                var Tutorials = await _tutorialDbContext.Tutorials.ToListAsync();
               
                return Tutorials;
            }
            catch(Exception ex) 
            {
                throw new NotImplementedException(ex.Message);
            }
        }


    }
}
