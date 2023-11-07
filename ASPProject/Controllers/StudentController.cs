using Microsoft.AspNetCore.Mvc;
using  ASPProject.Models;
using ASPProject.Data;

namespace ASPProject.Controllers
{
    //[Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        //to get access to the Roster table ... we need to inject SMUABContext
        private SMUDbContext _dbContext;
        public StudentController(SMUDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //index action that displays all students
        public IActionResult Index()
        {
            return View(_dbContext.Roster.ToList());
        }

       // show details action that displays one student

       //add action that adds a new student

       //edit action that edits an existing student
    }



    
       /* //[Route("")]
       // [Route("Alex")]  // don't have the /  combinate with the controller
       // [Route("/MEZEI")] //  "/" controller level is been ignored
        //[Route("[controller]/[action]/MEZEI")]
        public IActionResult Index()
        {
            return Content("Student Controller, Index action");
        }

       // [Route("SMU/{id}")]
        //[Route("[controller]/[action]/MEZEI/{id?}")]
        //[HttpGet] //  like a filter to only respond to get request
        //[HttpPost] // like a filter to only respond to post request
        public ActionResult Show(int id)  //ViewResult
        {
            Student s = new Student();
            if(id == 1) 
            { 
                // show one student
                s.StudentId = 1;
                s.GPA = 4.0;
                s.Name = "Ada Love Lace";
                s.Major = Major.CS;
                s.AdmissionDate = DateTime.Now;
                s.IsVeteran = true;
            }
            else
            {
                // show another student
              
                s.StudentId = 2;
                s.GPA = 3.89;
                s.Name = "Alan Tudeing";
                s.Major = Major.IT;
                s.AdmissionDate = DateTime.Now;
                s.IsVeteran = true;
            }

            ViewBag.Student = s;

            return View();
        }

        public IActionResult GoToGoogle()
        {
            return Redirect("https://www.google.com");
        }
    }*/
}
