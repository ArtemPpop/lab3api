using lab3api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAll()
        {
            return await _context.Purchases.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Purchase>> Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = purchase.Id }, purchase);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Purchases.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Purchases.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
