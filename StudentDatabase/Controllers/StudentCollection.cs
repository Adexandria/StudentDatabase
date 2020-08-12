using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using StudentDatabase.Entities;
using StudentDatabase.Services;
using StudentDatabase.View;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDatabase.Controllers
{
    [ApiController]
    [Route("api/studentCollection")]
    public class StudentCollection : Controller
    {
        private readonly IData db;
        private IMapper mapper;
        public StudentCollection(IData db, IMapper mapper)
        {
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }
        [HttpGet("{Ids}", Name = "GetStudents")]
        public IActionResult GetCollection([FromRoute] 
        [ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> Ids)
        {
            if (Ids == null)
            {
                return BadRequest();
            }
            var students = db.GetStudentById(Ids);
            if (students == null)
            {
                return NotFound();
            }
            var getstudents = mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(getstudents);

        }
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post(IEnumerable<StudentCreation> creations)
        {
            var newstudents = mapper.Map<IEnumerable<Student>>(creations);
            foreach (var student in newstudents)
            {
                await db.Add(student);


            }
            await db.Save();
            var students = mapper.Map<IEnumerable<StudentDto>>(newstudents);
            var idsAsString = string.Join(",", students.Select(a => a.Id));
            return CreatedAtRoute("GetStudents",new { ids= idsAsString},students);
        }
    }
}
