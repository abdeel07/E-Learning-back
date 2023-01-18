using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_learning_Back.Models;

namespace E_learning_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCoursController : ControllerBase
    {
        private readonly ElearningContext _context;

        public SkillCoursController(ElearningContext context)
        {
            _context = context;
        }

        // GET: api/SkillCours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillCour>>> GetSkillCours()
        {
            return await _context.SkillCours.ToListAsync();
        }

        // GET: api/SkillCours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillCour>> GetSkillCour(int id)
        {
            var skillCour = await _context.SkillCours.FindAsync(id);

            if (skillCour == null)
            {
                return NotFound();
            }

            return skillCour;
        }

        // PUT: api/SkillCours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillCour(int id, SkillCour skillCour)
        {
            if (id != skillCour.IdCours)
            {
                return BadRequest();
            }

            _context.Entry(skillCour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillCourExists(id))
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

        // POST: api/SkillCours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SkillCour>> PostSkillCour(SkillCour skillCour)
        {
            _context.SkillCours.Add(skillCour);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillCourExists(skillCour.IdCours))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkillCour", new { id = skillCour.IdCours }, skillCour);
        }

        // DELETE: api/SkillCours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkillCour(int id)
        {
            var skillCour = await _context.SkillCours.FindAsync(id);
            if (skillCour == null)
            {
                return NotFound();
            }

            _context.SkillCours.Remove(skillCour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillCourExists(int id)
        {
            return _context.SkillCours.Any(e => e.IdCours == id);
        }
    }
}
