using Microsoft.AspNetCore.Mvc;

namespace ASPProject.Controllers
{
    public class HomeController : Controller // this is a controller class
    {
        public IActionResult Index() //  this is an action
        {
            return Content("Hello from Index action, Home Controller");
        }

        public IActionResult SecondAction(int id) 
        {
            return Content($"Hello from the second action{id}^2 = {id*id}");
        }
    }
}
