using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightLossPlannerAPI.Data;
using WeightLossPlannerAPI.Models;

namespace WeightLossPlannerAPI.Controllers
{   
    /// <summary>
    /// Manages user-related actions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseLogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExerciseLogController(AppDbContext context) 
        {
            _context = context;
        }

        // GET: api/exerciselog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseLog>>> GetAllExerciseLogs()
        {
            return await _context.ExerciseLogs.Include(e => e.UserProfile).ToListAsync(); // Also fetch the related UserProfile
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ExerciseLog>>> GetExerciseLogsByUser(int userId)
        {
            return await _context.ExerciseLogs
                .Where(e => e.UserProfileId == userId)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseLog>> Create(ExerciseLog log)
        {
            _context.ExerciseLogs.Add(log);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllExerciseLogs), 
                new { Id = log.Id },  // primary key
                log);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var log = await _context.ExerciseLogs.FindAsync(id);
            if (log == null) return NotFound();

            _context.ExerciseLogs.Remove(log);
            await  _context.SaveChangesAsync();
            return NoContent();
        }









    }
}