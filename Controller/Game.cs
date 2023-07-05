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
    public async Task<ActionResult<List<Game>>> CreateEntity(Game game)
    {

        await _context.Game.AddAsync(game);
        await _context.SaveChangesAsync();

        return Ok(game);
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

        if (game.IdPlayerWin != 0)
        {
            Player player = await _context.Player.FindAsync(game.IdPlayerWin);
            if (player != null)
            {
                Score score = await _context.Scores.FirstOrDefaultAsync(s => s.Player == game.IdPlayerWin);
                if (score == null)
                {
                    score = new Score { Player = game.IdPlayerWin, ScoreNumber = 1, PlayerName = player.Name };
                    _context.Scores.Add(score);
                }
                else
                {
                    score.ScoreNumber++;
                    _context.Scores.Update(score);
                }
                await _context.SaveChangesAsync();
            }
        }


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

