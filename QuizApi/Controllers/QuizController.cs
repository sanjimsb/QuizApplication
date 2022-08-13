using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizDbContext;
using QuizModels;

namespace QuizApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizContext _context;

    public QuizController(QuizContext context)
    {
        _context = context;
    }

    // GET: api/quizes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizes()
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }
        var quizes = await _context.Quiz.ToListAsync();

        return quizes;
    }

    // GET: api/quizes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Quiz>> GetQuiz(int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var quiz = await _context.Quiz.FindAsync(id);

        if (quiz == null)
        {
            return NotFound();
        }

        return quiz;
    }

    // PUT: api/quizes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuiz(int id, Quiz quiz)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        if (id != quiz.Id)
        {
            return BadRequest();
        }

        _context.Entry(quiz).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckQuizExists(id))
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

    // POST: api/quizes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        _context.Quiz.Add(quiz);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJob", new { id = quiz.Id });
    }

    // DELETE: api/quizes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz (int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var quiz = await _context.Quiz.FindAsync(id);
        if (quiz == null) {
            return NotFound();
        }

        _context.Quiz.Remove(quiz);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckQuizExists(int id)
    {
        return _context.Quiz.Any(q => q.Id == id);
    }
}

