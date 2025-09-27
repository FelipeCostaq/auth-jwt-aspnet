using System.Security.Claims;
using AuthFinance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthFinance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompletedGoalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompletedGoalController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetCompletedGoals()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var completedGoals = await _context.CompletedGoals.Where(x => x.UserId == userId).ToListAsync();

            return Ok(completedGoals);
        }

        [Authorize]
        [HttpGet("{title}")]
        public async Task<IActionResult> GetCompletedGoalByTitle(string title)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var completedGoals = await _context.CompletedGoals.Where(x => x.UserId == userId && x.Title.Contains(title)).ToListAsync();

            if (completedGoals.Count == 0)
                return NotFound();

            return Ok(completedGoals);
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompletedGoal(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var completedGoal = await _context.CompletedGoals.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (completedGoal == null)
                return NotFound();

            _context.CompletedGoals.Remove(completedGoal);
           await  _context.SaveChangesAsync();
            return Ok(completedGoal);
        }
    }
}
