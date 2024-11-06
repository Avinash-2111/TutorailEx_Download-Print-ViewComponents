using Microsoft.AspNetCore.Mvc;
using TutorialEx.Factories;
using TutorialEx.Models;
using TutorialEx.Repository;

namespace TutorialEx.ViewComponents
{
    public class TutorialViewComponent:ViewComponent
    {
        private readonly ITutorialFactory _tutorialFactory;

        public TutorialViewComponent(ITutorialFactory tutorialFactory)
        {
            _tutorialFactory = tutorialFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var tutorial = await _tutorialFactory.GetAllTutorials();             
            return View(tutorial);
        }
    }
}
