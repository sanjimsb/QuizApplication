using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizDbContext;
using QuizModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly QuizContext _context;


    public UserController(QuizContext context)
    {
        _context = context;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUsers()
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var users = await _context.Users.ToListAsync();

        return users;
    }

    // GET: api/users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IdentityUser>> GetUser(string id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(string id, User user)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        if (id != user.Id)
        {
            return BadRequest();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckUserExists(id))
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

    // POST: api/users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<IdentityUser>> PostUser(User user)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        _context.User.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = user.Id });
    }

    // DELETE: api/users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckUserExists(string id)
    {
        return _context.Users.Any(u => u.Id == id);
    }
}
