using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StudentDatabase.Entities;
using StudentDatabase.Services;
using StudentDatabase.View;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDatabase.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class Students : ControllerBase
    {
        private readonly IData db;
        private IMapper mapper;
        public Students(IData db, IMapper mapper)
        {
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }
        [HttpGet]
        [HttpHead]
        //Get Students
        public ActionResult<StudentDto> Get()
        {
            var query = db.GetStudents;
            return Ok(mapper.Map<IEnumerable<StudentDto>>(query));
        }
         
        [HttpGet("{Id}", Name = "Students")]
          public async Task<ActionResult<StudentDto>> GetbyId(Guid Id)
          {
              var query = await db.GetStudentsById(Id);
              if (query == null)
              {
                  return NotFound();
              }
              var newStudent = mapper.Map<StudentDto>(query);
              return Ok(newStudent);
          }

        //get student by name
     /*  [HttpGet("{name}", Name = "Student")]
        public ActionResult<StudentDto> GetByName(string name)
        {
            var query = db.GetStudentsByName(name);
            if (query.FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<StudentDto>>(query));
        }*/

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Post(StudentCreation creation)
        {
            var query = mapper.Map<Student>(creation);
            await db.Add(query);
            await db.Save();
            var newstudent = mapper.Map<StudentDto>(query);
            return CreatedAtRoute("Students",new {Id=newstudent.Id } ,newstudent);
        }
       
        [HttpPut]
        public async Task<ActionResult<StudentDto>> Put(StudentUpdate update)
        { 
            var query = mapper.Map<Student>(update);
            var database = await db.GetStudentsById(query.Id);
            if( database== null)
            {
                return NotFound();

            }
            
            db.Update(query);
            await db.Save();
            var newstudent = mapper.Map<StudentDto>(query);
            return Ok(newstudent);
        }
    
         [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,PATCH");
            return Ok();
        }
        public override ActionResult ValidationProblem(
          [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
