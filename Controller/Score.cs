using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Context;

namespace APIApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScoresController : ControllerBase
{
    private List<Score> Scores = new List<Score>();
    private readonly ApplicationDbContext _context;

    public ScoresController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Score> GetGames()
    {
        return _context.Scores.OrderByDescending(s => s.ScoreNumber).ToList();
    }


}
