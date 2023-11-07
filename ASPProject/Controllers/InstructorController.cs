using ASPProject.Data;
using ASPProject.Models;
using ASPProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace ASPProject.Controllers
{
    public class InstructorController : Controller
    {
        //inject service
       // private MyServiceInterface _service;
        private SMUDbContext _dbContext;

        //ctor
        public InstructorController(/*MyServiceInterface myservice*/ SMUDbContext dbContext)
        {
            //_service = myservice;
            _dbContext = dbContext;
        }

        public IActionResult Index(string searchByLastName)
        {
            var instructors = _dbContext.Instuctors.AsEnumerable(); //all instructors

            if(! searchByLastName.IsNullOrEmpty()) // filter down the list of instructors to display
            {
                //instructors = instructors.Where(inst => inst.Contains(searchByLastName));// case sensitive
                instructors = instructors.Where(inst => inst.LastName!.ToLower().Contains(searchByLastName.ToLower())); //no case sensitive

            }

          
            //get a list of all departments for the list of instructors
            var AvailableDepartments = instructors  //LINQ
                         .Select(inst => inst.Department)
                         .Distinct()
                         .OrderBy(department => department);

            ViewBag.AvailableDepartments = AvailableDepartments;

            ViewBag.SearchByLastName = searchByLastName;

            return View(instructors);
        }


        public IActionResult ShowAll()
        {
            return RedirectToAction("Index"); // Index is the action defied above
        }

        public IActionResult DisplayAll()//This action calls a view with a different name
        {
            return View("Index", _dbContext.Instuctors.ToList()); //"index" is the name of  the view to return
        }

        public IActionResult Details(int id)
        {
            /*//find which instrcutor form the list has an ID equal to id - LINQ
            foreach(Instructor i in InstructorsList) //search throgh the list
            {
                if(i.ID == id) //if you find the instructor
                {
                    return View(i);
                }
            }*/
            Instructor? i = _dbContext.Instuctors.FirstOrDefault(i => i.ID == id);//LINQ either first instructor or null
            ViewBag.id = id;
            return View(i);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Instructor newInstructor) // the modle binder will populate this parameter wittth values from the form
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            _dbContext.Instuctors.Add(newInstructor);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Instuctors);  // return to the 'Create' view with the current 'instructor' object if model is not valid
        }

        [HttpGet]
        public IActionResult Edit(int id) //two step process ... stay tuned
        {
                //search for the instructor with the given id
                Instructor? inst = _dbContext.Instuctors.FirstOrDefault(Instructor => Instructor.ID == id);

                if (inst == null) //not found
                       return NotFound();
                else
                    return View(inst);
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Instructor changedInstructor)
        { 
            
                // Find the instructor in the list
            Instructor? instr = _dbContext.Instuctors.FirstOrDefault(inst => inst.ID == changedInstructor.ID);
            if (!ModelState.IsValid)
            {
                return View(instr);
            }
            if (instr != null)// we found the instructor to change
                {
                    instr.LastName =  changedInstructor.LastName; // save changes
                    instr.IsTenured = changedInstructor.IsTenured;
                    instr.DateHired = changedInstructor.DateHired;
                    instr.Department = changedInstructor.Department;
                    _dbContext.SaveChanges();
                }
                else
                {
                    return NotFound(); // return the 404 error
                }


                //return RedirectToAction("Index");  // Redirect to the list of instructors
            

                return RedirectToAction("Index");  
        }

        [HttpGet]
        public IActionResult Delete(int id) //two step process ... stay tuned
        {
            //search for the instructor with the given id
            Instructor? inst = _dbContext.Instuctors.FirstOrDefault(Instructor => Instructor.ID == id);

            if (inst == null) //not found
                return NotFound();
            else
            {
                // _service.allInstructors.Remove(inst);
                //  return RedirectToAction("Index");
                return View(inst);
            }

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id) //two step process ... stay tuned
        {
            //search for the instructor with the given id
            Instructor? inst = _dbContext.Instuctors.FirstOrDefault(Instructor => Instructor.ID == id);

            if (inst == null) //not found
                return NotFound();
            else
            {
                 _dbContext.Instuctors.Remove(inst);
                 _dbContext.SaveChanges();
                 return RedirectToAction("Index");
                
            }

        }

        /* public IActionResult Add(int id) //two step process.. stay tuned
         {
             return View();
         }

         public IActionResult Edit(int id) //two step process ... stay tuned
         {
             return View();
         }

         public IActionResult Delete(int id) //two step process ... stay tuned
         {
             return View();
         }
 */
        //actions: ShowAll(Index), Details (ShowOne), Add, Delete, Edit
    }
}
