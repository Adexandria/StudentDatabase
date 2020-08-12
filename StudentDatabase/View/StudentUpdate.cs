using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.View
{
    public class StudentUpdate :StudentManipulation
    {
        [Required(ErrorMessage ="Enter Id")]
        public Guid Id { get; set; }
    }
}
