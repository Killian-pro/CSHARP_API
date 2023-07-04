using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindApi _context;

        public CategoriesController(NorthwindApi context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categorie>> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        [HttpPost]
        public async Task<ActionResult<Categorie>> CreateCategorie(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
            return categorie;
        }
    }
}
