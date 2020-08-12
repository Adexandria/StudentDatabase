using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
         public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public State State { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Classes Classes { get; set; } 

    }
}
