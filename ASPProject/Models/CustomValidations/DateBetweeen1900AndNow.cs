using System.ComponentModel.DataAnnotations;

namespace ASPProject.Models.CustomValidations
{
    public class DateBetweeen1900AndNowValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? dt = (DateTime?)value;
            
            if (dt is  null) 
                return  true; 
            return dt>= DateTime.Parse("1/1/1990") && dt <= DateTime.Now;
        }
    }
}
