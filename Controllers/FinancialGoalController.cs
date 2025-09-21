using System.Security.Claims;
using AuthFinance.Context;
using AuthFinance.DTO;
using AuthFinance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthFinance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialGoalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FinancialGoalController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateGoal(FinancialGoalDTO request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var goal = new FinancialGoal
            {
                Title = request.Title,
                TargetAmount = request.TargetAmount,
                UserId = userId
            };

            _context.FinancialGoals.Add(goal);
            await _context.SaveChangesAsync();

            return Ok(goal);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetGoals()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var goals = await _context.FinancialGoals.Where(x => x.UserId == userId).ToListAsync();

            return Ok(goals);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, FinancialGoalDTO request)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var goal = await _context.FinancialGoals.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            goal.Title = request.Title;
            goal.TargetAmount = request.TargetAmount;

            await _context.SaveChangesAsync();
            return Ok(goal);
        }

        [Authorize]
        [HttpPut("{id}/add-funds")]
        public async Task<IActionResult> AddFunds(int id, [FromBody] decimal amount)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var goal = await _context.FinancialGoals.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            if (amount <= 0)
                return BadRequest("O valor deve ser maior que zero.");

            goal.CurrentAmount += amount;

            if (goal.CurrentAmount >= goal.TargetAmount)
            {
                var completed = new CompletedGoal
                {
                    Title = goal.Title,
                    TargetAmount = goal.TargetAmount,
                    CompletedAt = DateTime.Now,
                    UserId = goal.UserId
                };

                _context.CompletedGoals.Add(completed);
                _context.FinancialGoals.Remove(goal);
            }

            await _context.SaveChangesAsync();
            return Ok(goal);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var goal = await _context.FinancialGoals.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            _context.FinancialGoals.Remove(goal);
            await _context.SaveChangesAsync();
            return Ok($"Meta {goal.Title} deletada!");
        }
    }
}
