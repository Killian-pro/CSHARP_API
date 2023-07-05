using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Context;

namespace APIApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private List<Game> Games = new List<Game>();
    private readonly ApplicationDbContext _context;

    public GamesController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Game> GetGames()
    {
        return _context.Game.ToList();
    }


    [HttpPost]
    public async Task<ActionResult<List<Game>>> CreateEntity(Game c)
    {

        await _context.Game.AddAsync(c);
        await _context.SaveChangesAsync();
        return Ok(c);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Game>> UpdateGame(int id, [FromBody] Game updatedGame)
    {
        // Recherche de l'entité Game existante
        Game game = await _context.Game.FindAsync(id);
        if (game == null)
        {
            return NotFound("Game not found");
        }

        // Mise à jour des propriétés
        game.BoardState = updatedGame.BoardState;
        game.IdPlayerWin = updatedGame.IdPlayerWin;

        // Enregistrement des modifications dans la base de données
        await _context.SaveChangesAsync();

        return Ok(game);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<Game>> DeleteCategory(int id)
    {
        Game Game = await _context.Game.FindAsync(id);
        if (Game == null)
        {
            return NotFound("Category not found");
        }
        _context.Game.Remove(Game);
        await _context.SaveChangesAsync();

        return Ok(Game);
    }
}

