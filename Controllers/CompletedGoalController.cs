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

    }
}
