using Microsoft.EntityFrameworkCore;
using StudentDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDatabase.DbContexts
{
    public class StudentsDb :DbContext 
    {
        public StudentsDb(DbContextOptions<StudentsDb> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Student>().HasData(
                new Student
            {
                Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                FirstName ="Adeola",
                MiddleName="Wuraola",
                LastName="Aderibigbe",
                DateOfBirth= new DateTime(1999, 12, 11),
                Classes =Classes.SS3,
                Gender=Gender.Female,
                State=State.Lagos

            },
                  new Student
                  {
                      Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                      FirstName = "Uriel",
                      MiddleName = "Ayebanengimote",
                      LastName = "Aye",
                      DateOfBirth = new DateTime(1998, 08, 7),
                      Classes = Classes.SS3,
                      Gender = Gender.Male,
                      State = State.Bayelsa

                  }
            );
                
            
        }

    }
}
