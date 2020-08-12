
using StudentDatabase.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ValidationAttributes
{
    public class FirstNameMustBeDifferentFromMiddleName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var course = (StudentManipulation)validationContext.ObjectInstance;

            if (course.FirstName==course.MiddleName)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(StudentManipulation) });
            }

            return ValidationResult.Success;
        }
    }
}
