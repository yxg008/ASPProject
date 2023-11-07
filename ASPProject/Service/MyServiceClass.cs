using ASPProject.Models;

namespace ASPProject.Services
{
    public class MyServiceClass : MyServiceInterface
    {
        public List<Instructor> allInstructors { get; set; }

        public MyServiceClass()
        {
            allInstructors = new();

            //populate the list
            allInstructors.Add(new Instructor()
            {
                ID = 10,
                FirstName = "Mike",
                LastName = "Chen",
                Department = Departments.CS,
                DateHired = DateTime.Parse("08/15/2020"),
                IsTenured = false
            });

            allInstructors.Add(new Instructor()
            {
                ID = 20,
                FirstName = "Robert",
                LastName = "Johnson",
                Department = Departments.BUSINESS,
                DateHired = DateTime.Now,
                IsTenured = true
            });

            allInstructors.Add(new Instructor()
            {
                ID = 30,
                FirstName = "Radana",
                LastName = "Dvorak",
                Department = Departments.CS,
                DateHired = DateTime.Parse("08/15/2021"),
                IsTenured = true
            });

            allInstructors.Add(new Instructor()
            {
                ID = 40,
                FirstName = "Zach",
                LastName = "Morris",
                Department = Departments.OTHER,
                DateHired = DateTime.Parse("07/07/2007"),
                IsTenured = false
            });

            allInstructors.Add(new Instructor()
            {
                ID = 50,
                FirstName = "Harry",
                LastName = "Robert",
                Department = Departments.MATH,
                DateHired = DateTime.Parse("06/20/2007"),
                IsTenured = true
            });       
        }
       
    }
}
