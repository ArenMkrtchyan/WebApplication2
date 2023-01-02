using WebApplication2.ViewModels;
using ClassLibrary1.Entities;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Products
                .Select(p => new ProductViewModel
                {
                    Name = p.Name,
                    Discount = p.Discount,
                    Id=p.Id,
                    Price=p.Price
                }).ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Discount = model.Discount,
                Category = model.Category
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
