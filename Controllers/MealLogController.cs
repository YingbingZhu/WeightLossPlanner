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
    public class MealLogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MealLogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/meallog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealLog>>> GetAllMeals()
        {
            return await _context.MealLogs.Include(m => m.UserProfile).ToListAsync();
        }

        // GET: api/meallog/user/1
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<MealLog>>> GetMealsByUser(int userId)
        {
            return await _context.MealLogs
                .Where(m => m.UserProfileId == userId)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        // POST: api/meallog
        [HttpPost]
        public async Task<ActionResult<MealLog>> CreateMeal(MealLog meal)
        {
            _context.MealLogs.Add(meal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMealsByUser), new { userId = meal.UserProfileId }, meal);
        }

        // DELETE: api/meallog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _context.MealLogs.FindAsync(id);
            if (meal == null)
                return NotFound();

            _context.MealLogs.Remove(meal);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}