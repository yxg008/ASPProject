using ASPProject.Models;
using Microsoft.EntityFrameworkCore;
namespace ASPProject.Data
{
    public class SMUDbContext : DbContext
    {
        //we want to save Student(s) and Instructor(s) to the database
        //public DbSet<Student> Roster {get;set;}
        // public DbSet<Instructor> Instuctors {get;set;}
        public DbSet<Student> Roster => Set<Student>();

        public DbSet<Instructor> Instuctors => Set<Instructor>();

        //ctor
        public SMUDbContext(DbContextOptions<SMUDbContext> options) : base(options)
        {

        }

        // we add some seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //add data bellow
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    ID = 10,
                    FirstName = "Mike",
                    LastName = "Chen",
                    Department = Departments.CS,
                    DateHired = DateTime.Parse("08/15/2020"),
                    IsTenured = false

                },
                new Instructor()
                {
                    ID = 20,
                    FirstName = "Robert", 
                    LastName = "Johnson",
                    Department = Departments.BUSINESS,
                    DateHired = DateTime.Now,
                    IsTenured = true
                },
                new Instructor()
                {
                    ID = 30,
                    FirstName = "Radana",
                    LastName = "Dvorak",
                    Department = Departments.CS,
                    DateHired = DateTime.Parse("08/15/2021"),
                    IsTenured = true
                },
                new Instructor()
                {
                    ID = 40,
                    FirstName = "Zach",
                    LastName = "Morris",
                    Department = Departments.OTHER,
                    DateHired = DateTime.Parse("07/07/2007"),
                    IsTenured = false
                }
                );




            modelBuilder.Entity<Student>().HasData(
                new Student() 
                {
                    StudentId = 100,  
                    GPA= 2.9, 
                    Major = Major.ART, 
                    IsVeteran= false,
                    Name="William", 
                    AdmissionDate = DateTime.Parse("08/15/2000")
                }
                ,
                  new Student()
                  {
                      StudentId = 200,
                      GPA = 3.2,
                      Major = Major.IT,
                      IsVeteran = true,
                      Name = "Billy",
                      AdmissionDate = DateTime.Parse("07/07/2001")
                  },
                    new Student()
                    {
                        StudentId = 300,
                        GPA = 4.0,
                        Major = Major.CS,
                        IsVeteran = false,
                        Name = "Bill",
                        AdmissionDate = DateTime.Parse("01/01/1999")
                    }

                );


        }
    }

   
}
