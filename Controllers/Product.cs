using Microsoft.AspNetCore.Mvc;
using MyApi.Context;

namespace APIApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private List<Products> Products = new List<Products>();
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Products> GetProducts()
    {
        return _context.Products.ToList();
    }



    [HttpPost]
    public async Task<ActionResult<List<Products>>> CreateEntity(Products c)
    {

        await _context.Products.AddAsync(c);
        await _context.SaveChangesAsync();
        return Ok(c);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Products>> DeleteCategory(int id)
    {
        Products Products = await _context.Products.FindAsync(id);
        if (Products == null)
        {
            return NotFound("Category not found");
        }
        _context.Products.Remove(Products);
        await _context.SaveChangesAsync();

        return Ok(Products);
    }

}
