using AutoMapper;
using CLCOM_SeminarRestApi.Models;
using CLCOM_SeminarRestApi.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLCOM_SeminarRestApi.Controllers
{
    [Route("/students")]
    [Produces("application/json")]
    public class StudentController : Controller
    {
        protected readonly AppDbContext context;
        private readonly IMapper mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Student>> ListAll()
        {
            return await context.Students.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Student), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNew([FromBody] AddStudentResource resource)
        {
            if (!ModelState.IsValid) return BadRequest();

            Student student = mapper.Map<AddStudentResource, Student>(resource);

            var created = await context.Students.AddAsync(student);
            await context.SaveChangesAsync();

            return new CreatedResult($"/students/{created.Entity.Id}", created.Entity);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Student student = context.Students.FirstOrDefault(p => p.Id == id);

            if (student == null) return NotFound();

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
