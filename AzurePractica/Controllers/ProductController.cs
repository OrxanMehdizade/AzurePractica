using AzurePractica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurePractica.Controllers
{
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid? productId)
        {
            var products = _context.Products.ToList();

            if (productId.HasValue)
            {
                products = products.Where(p => p.Id == productId.Value).ToList();
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
