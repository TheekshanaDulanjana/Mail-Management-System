using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailManagementAPI0026.Data;
using MailManagementAPI0026.Models;

namespace MailManagementAPI0026.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class MailsController0026 : ControllerBase
    {
        private readonly MailContext0026 _context;

        public MailsController0026(MailContext0026 context)
        {
            _context = context;
        }

        // GET: api/mails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mail0026>>> GetMails0026(int? senderDepartmentId = null, int? recipientDepartmentId = null)
        {
            var query = _context.Mails.Include(m => m.SenderDepartment).Include(m => m.RecipientDepartment).AsQueryable();

            if (senderDepartmentId.HasValue)
            {
                query = query.Where(m => m.SenderDepartmentId == senderDepartmentId.Value);
            }

            if (recipientDepartmentId.HasValue)
            {
                query = query.Where(m => m.RecipientDepartmentId == recipientDepartmentId.Value);
            }

            return await query.ToListAsync();
        }

        // GET: api/mails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mail0026>> GetMail0026(int id)
        {
            var mail = await _context.Mails
                .Include(m => m.SenderDepartment)
                .Include(m => m.RecipientDepartment)
                .FirstOrDefaultAsync(m => m.MailId == id);

            if (mail == null)
            {
                return NotFound();
            }

            return mail;
        }

        // POST: api/mails
        [HttpPost]
        public async Task<ActionResult<Mail0026>> CreateMail0026(Mail0026 mail)
        {
            // Validate that departments exist
            var senderExists = await _context.Departments.AnyAsync(d => d.DepartmentId == mail.SenderDepartmentId);
            var recipientExists = await _context.Departments.AnyAsync(d => d.DepartmentId == mail.RecipientDepartmentId);

            if (!senderExists || !recipientExists)
            {
                return BadRequest("Invalid sender or recipient department ID.");
            }

            _context.Mails.Add(mail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMail0026), new { id = mail.MailId }, mail);
        }

        // PUT: api/mails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMailStatusById0026(int id, [FromBody] MailStatus0026 status)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            mail.DeliveryStatus = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/mails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMail0026(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/mails/5/status
        [HttpGet("{id}/status")]
        public async Task<ActionResult<MailStatus0026>> GetMailStatus0026(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            return mail.DeliveryStatus;
        }

        // PUT: api/mails/5/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateMailStatus0026(int id, [FromBody] MailStatus0026 status)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }

            mail.DeliveryStatus = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
