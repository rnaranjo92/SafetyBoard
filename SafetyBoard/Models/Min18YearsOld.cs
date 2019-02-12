using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SafetyBoard.Models
{
    public class Min18YearsOld : ValidationAttribute
    {
        public static readonly byte LegalAge = 18;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var user = (User)validationContext.ObjectInstance;

            if (user.BirthDate == null)
                return new ValidationResult("Birthdate is required.");
                

            var age = DateTime.Today.Year - user.BirthDate.Value.Year;

            return (age >= LegalAge)
                ? ValidationResult.Success
                : new ValidationResult("Must be 18 years old of age in order to register.");
        }
    }
}