using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TutorialEx.Factories;
using TutorialEx.Models;

namespace TutorialEx.Controllers
{
    //[Route("tutorial")]
    public class TutorialController : Controller
    {
        private readonly ITutorialFactory _tutorialFactory;

        public TutorialController(ITutorialFactory tutorialFactory)
        {
            _tutorialFactory = tutorialFactory;
        }
     //   [Route("index")]
        public async Task<IActionResult> Index()
        {
            var list = await _tutorialFactory.GetAllTutorials();
            return View(list);
        }
        [HttpGet]
     //   [Route("addtutorial")]
        public async Task<IActionResult> AddTutorial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTutorial(Tutorial tutorial)
        {
            if (!ModelState.IsValid)
            {
                return View(tutorial);
            }
            var result = await _tutorialFactory.AddTutorial(tutorial);
            return RedirectToAction("Index");
        }
        [HttpGet]
       // [Route("edittutorial/{id}")]
        public async Task<IActionResult> EditTutorial(int id)
        {
            Tutorial tutorial = await _tutorialFactory.GetTutorialById(id);
            return View(tutorial);
        }
        [HttpPost]
      
        public async Task<IActionResult> EditTutorial([FromBody]Tutorial Modifiedtutorial)
        {
            if (ModelState.IsValid)
            {
                Tutorial tutorial = await _tutorialFactory.GetTutorialById((int)Modifiedtutorial.Id);

                tutorial.TutorialName = Modifiedtutorial.TutorialName;
                tutorial.TutorialDescription = Modifiedtutorial.TutorialDescription;
                Tutorial updatedtutorial = await _tutorialFactory.EditTutorial(tutorial);
                // return RedirectToAction("Index");
                return Json(new { success = true, message = "Tutorial updated successfully!" });
            }
            return View(Modifiedtutorial);
        }
        public async Task<IActionResult> DeleteTutorial(int id)
        {
            if (id != 0)
            {
                Tutorial tutorial=await _tutorialFactory.DeleteTutorialById(id);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
