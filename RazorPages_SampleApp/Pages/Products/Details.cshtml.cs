using RazorPages_SampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RazorPages_SampleApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPages_SampleApp.Data.ProductContext _context;

        public DetailsModel(RazorPages_SampleApp.Data.ProductContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                 .Include( p=> p.ProductCategory)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
