using System.ComponentModel.DataAnnotations;

namespace ASPProject.Models
{
    public enum Major {ART, CS, IT, OTHER}
    public class Student
    {
        //properties

        public int StudentId { get; set; }

        public string? Name { get; set; }
       
        public Major Major { get; set; }

        public bool IsVeteran { get; set; }

        public DateTime? AdmissionDate { get; set; }

        public Double GPA { get; set; }


    }
}
