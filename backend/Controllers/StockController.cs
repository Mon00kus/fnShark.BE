using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController( ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var stock = _context.Stocks.ToList();
            return Ok(stock);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}
