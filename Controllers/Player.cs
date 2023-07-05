using Microsoft.AspNetCore.Mvc;
using MyApi.Context;

namespace APIApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private List<Player> Players = new List<Player>();
    private readonly ApplicationDbContext _context;

    public PlayersController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Player> GetPlayers()
    {
        return _context.Player.ToList();
    }



    [HttpPost]
    public async Task<ActionResult<List<Player>>> CreateEntity(Player p)
    {

        await _context.Player.AddAsync(p);
        await _context.SaveChangesAsync();
        return Ok(p);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Player>> DeleteCategory(int id)
    {
        Player Players = await _context.Player.FindAsync(id);
        if (Players == null)
        {
            return NotFound("Category not found");
        }
        _context.Player.Remove(Players);
        await _context.SaveChangesAsync();

        return Ok(Players);
    }

}
