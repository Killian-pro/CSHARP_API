using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Context;

namespace APIApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private List<Categorie> Categories = new List<Categorie>();
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Categorie> GetCategories()
    {
        return _context.Categories.ToList();
    }


    [HttpPost]
    public async Task<ActionResult<List<Categorie>>> CreateEntity(Categorie c)
    {

        await _context.Categories.AddAsync(c);
        await _context.SaveChangesAsync();
        return Ok(c);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Categorie>> DeleteCategory(int id)
    {
        Categorie categorie = await _context.Categories.FindAsync(id);
        if (categorie == null)
        {
            return NotFound("Category not found");
        }
        _context.Categories.Remove(categorie);
        await _context.SaveChangesAsync();

        return Ok(categorie);
    }
}

