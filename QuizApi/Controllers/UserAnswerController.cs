using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizDbContext;
using QuizModels;

namespace QuizApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserAnswerController : ControllerBase
{
    private readonly QuizContext _context;

    public UserAnswerController(QuizContext context)
    {
        _context = context;
    }

    // GET: api/userAnswers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAnswer>>> GetAnswers()
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var userAnswers = await _context.UserAnswer.ToListAsync();

        return userAnswers;
    }

    // GET: api/userAnswers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserAnswer>> GetAnswer(int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var userAnswer = await _context.UserAnswer.FindAsync(id);

        if (userAnswer == null)
        {
            return NotFound();
        }

        return userAnswer;
    }

    // PUT: api/userAnswers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnswer(int id, UserAnswer userAnswers)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        if (id != userAnswers.Id)
        {
            return BadRequest();
        }

        _context.Entry(userAnswers).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckAnswerExists(id))
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

    // POST: api/userAnswers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UserAnswer>> PostAnswer(UserAnswer userAnswers)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        _context.UserAnswer.Add(userAnswers);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJob", new { id = userAnswers.Id });
    }

    // DELETE: api/quizes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnswer(int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var userAnswers = await _context.UserAnswer.FindAsync(id);
        if (userAnswers == null)
        {
            return NotFound();
        }

        _context.UserAnswer.Remove(userAnswers);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckAnswerExists(int id)
    {
        return _context.UserAnswer.Any(q => q.Id == id);
    }
}

