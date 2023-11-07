using ASPProject.Models.CustomValidations;
using Microsoft.Build.ObjectModelRemoting;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASPProject.Models
{
    public enum Departments {
        [Display(Name ="Computer Science")]
        CS,
        [Display(Name="Mathmatics")]
        MATH,
        [Display(Name ="Business")]
        BUSINESS,  
        [Display(Name ="Chemistry")]
        CHEM,
        [Display(Name ="Other")]
        OTHER 
    }
    public class Instructor
    {
     //   [Required(ErrorMessage="You must Specified an ID")]
      //  [Display(Name = "ID  ")]
        public int? ID { get; set; }

        [Required]
        [Display(Name = "First Name  ")]
        public String FirstName { get; set; }

        [Required]
        [StringLength(5,MinimumLength =2)]
        [Display(Name = "Last Name  ")]
        public String LastName { get; set; }

        [Display(Name = "Is Tenured  ")]
        public bool IsTenured { get; set; }

        [Required(ErrorMessage ="a DATE IS REQUIRED")]
        //[Range(typeof(DateTime),"1/1/1990","10/16/2023")]
        [DateBetweeen1900AndNowValidation(ErrorMessage = "A valid date is between 1990 and today")]
        [Display(Name = "Date Hired  ")]
        [DataType(DataType.Date)]
        public DateTime? DateHired { get; set; }

        [Display(Name = "Department  ")]
        [Required(ErrorMessage ="You must choose a department")]
        public Departments Department { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


    }
}
