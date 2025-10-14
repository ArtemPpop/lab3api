using lab3api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab3api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext _context;
        public SalesController(DataContext context) => _context = context;

        [HttpGet("by-date/{date}")]
        public IActionResult GetSalesByDate(DateTime date)
        {
            var sales = _context.Sales
                .Where(s => s.SaleDate.Date == date.Date)
                .ToList();

            if (!sales.Any())
                return NotFound($"Продажи за {date:dd.MM.yyyy} не найдены.");

            var total = sales.Sum(s => s.TotalPrice);

            return Ok(new
            {
                Date = date.ToString("dd.MM.yyyy"),
                Sales = sales,
                TotalAmount = total
            });
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        {
            return await _context.Sales.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Sale>> Create(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = sale.Id }, sale);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
                return NotFound();

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
