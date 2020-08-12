using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




namespace StudentDatabase.View
{
    [FirstNameMustBeDifferentFromMiddleName(ErrorMessage ="First name can't be the same as Middlename")]
    public abstract class StudentManipulation 
    {
        [Required(ErrorMessage ="Enter first name")]
        [MaxLength(20)]
        public string FirstName { get; set; }
       [MaxLength(20)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Enter Last name")]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Enter date of birth in yyyy-mm-dd format")]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required(ErrorMessage ="Enter state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter Class")]
        public string Classes { get; set; }
    }
}
