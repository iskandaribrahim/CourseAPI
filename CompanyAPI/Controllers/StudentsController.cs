using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Models;
using CompanyAPI.RequestModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CompanyAPIContext _context;

        public StudentsController(CompanyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            try
            {
                var student = await _context.Students.FindAsync(id);

                student.FirstName = requestModel.FirstName;
                student.SecondName = requestModel.SecondName;
                student.Age = requestModel.Age;
                student.Grade = requestModel.Grade;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudent(StudentRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var course = await _context.Courses.FindAsync(requestModel.CourseId);
            if(course == null)
            {
                return NotFound("There is no course with This Id");
            }
            Student student = new()
            {
                FirstName = requestModel.FirstName,
                SecondName = requestModel.SecondName,
                Age = requestModel.Age,
                Grade = requestModel.Grade,
                Course = course
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok($"Student {student.FirstName} {student.FirstName} created!");
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
