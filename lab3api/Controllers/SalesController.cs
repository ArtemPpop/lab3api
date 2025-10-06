using lab3api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
