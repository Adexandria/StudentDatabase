using StudentDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;

namespace StudentDatabase.View
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string Classes { get; set; }

    }
}
