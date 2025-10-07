using lab3api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly DataContext _context;
        public StockController(DataContext context) => _context = context;

        [HttpGet("{article}")]
        public IActionResult GetStockByArticle(string article)
        {
            var purchase = _context.Purchases.FirstOrDefault(p => p.Article == article);
            if (purchase == null)
                return NotFound("Товар с таким артикулом не найден.");

            var totalSold = _context.Sales
                .Where(s => s.Article == article)
                .Sum(s => s.Quantity);

            var available = 10 - totalSold;

            return Ok(new
            {
                purchase.Article,
                purchase.Name,
                purchase.UnitPrice,
                Sold = totalSold,
                Available = available
            });
        }
    }
}
