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
public class ModuleDetailsController : ControllerBase
{

    private readonly QuizContext _context;


    public ModuleDetailsController(QuizContext context)
    {
        _context = context;
    }

    // GET: api/moduledetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModuleDetails>>> GetModuleDetails()
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var moduleDetails = await _context.ModuleDetails!.ToListAsync();

        return moduleDetails;
    }

    // GET: api/moduledetails/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ModuleDetails>> GetModuleDetail(string id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var moduleDetails = await _context.ModuleDetails!.FindAsync(id);

        if (moduleDetails == null)
        {
            return NotFound();
        }

        return moduleDetails;
    }

    // PUT: api/moduledetails/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutModuleDetail(int id, ModuleDetails moduleDetails)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        if (id != moduleDetails.Id)
        {
            return BadRequest();
        }

        _context.Entry(moduleDetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CheckModuleDetails(id))
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

    // POST: api/moduledetails
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ModuleDetails>> PostModuleDetail(ModuleDetails moduleDetails)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        _context.ModuleDetails!.Add(moduleDetails);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUser", new { id = moduleDetails.Id });
    }

    // DELETE: api/moduledetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModuleDetails(int id)
    {
        if (!ModelState.IsValid)
        {
            return NotFound();
        }

        var moduleDetails = await _context.ModuleDetails!.FindAsync(id);
        if (moduleDetails == null)
        {
            return NotFound();
        }

        _context.ModuleDetails.Remove(moduleDetails);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CheckModuleDetails(int id)
    {
        return _context.ModuleDetails!.Any(u => u.Id == id);
    }
}
