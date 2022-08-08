using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizDbContext;
using QuizModels;

namespace QuizApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly QuizContext _context;

    public ModuleController(QuizContext context)
    {
        _context = context;
    }

    // GET: api/modules
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Module>>> GetModules()
    {
        var modules = await _context.Module.ToListAsync();

        return modules;
    }

    // GET: api/modules/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Module>> GetModule(int id)
    {
        var module = await _context.Module.FindAsync(id);

        if (module == null)
        {
            return NotFound();
        }

        return module;
    }

    // PUT: api/modules/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutJob(int id, Module module)
    {
        if (id != module.Id)
        {
            return BadRequest();
        }

        _context.Entry(module).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckModuleExists(id))
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

    // POST: api/modules
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Module>> PostModule(Module module)
    {
        _context.Module.Add(module);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJob", new { id = module.Id });
    }

    // DELETE: api/Jobs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModule (int id)
    {
        var module = await _context.Module.FindAsync(id);
        if (module == null) {
            return NotFound();
        }

        _context.Module.Remove(module);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckModuleExists(int id)
    {
        return _context.Module.Any(m => m.Id == id);
    }
}

