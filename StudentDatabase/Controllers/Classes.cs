using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentDatabase.Services;
using StudentDatabase.View;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDatabase.Controllers
{
    [ApiController]
    [Route("api/students/classes")]
    public class Classes : ControllerBase
    {
        private readonly IData db;
        private IMapper mapper;
        public Classes(IData db, IMapper mapper)
        {
            this.db = db ?? throw new NullReferenceException(nameof(db));
            this.mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
        }
        [HttpGet("{name}")]
        public ActionResult<StudentDto> Index(string name)
        {
            var query = db.GetStudentsByClass(name);
            if (query.FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<IEnumerable<StudentDto>>(query));
        }
    }
}
