using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailManagementAPI0026.Data;
using MailManagementAPI0026.Models;

namespace MailManagementAPI0026.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController0026 : ControllerBase
    {
        private readonly MailContext0026 _context;

        public DepartmentsController0026(MailContext0026 context)
        {
            _context = context;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department0026>>> GetDepartments0026()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department0026>> GetDepartment0026(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // POST: api/departments
        [HttpPost]
        public async Task<ActionResult<Department0026>> CreateDepartment0026(Department0026 department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment0026), new { id = department.DepartmentId }, department);
        }

        // PUT: api/departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment0026(int id, Department0026 department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists0026(id))
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

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment0026(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists0026(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
