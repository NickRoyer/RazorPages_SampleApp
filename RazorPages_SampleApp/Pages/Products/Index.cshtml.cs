using RazorPages_SampleApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RazorPages_SampleApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages_SampleApp.Data.ProductContext _context;

        public IndexModel(RazorPages_SampleApp.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Include( p=> p.ProductCategory) 
                .AsNoTracking()
                .OrderByDescending( p => p.AverageCustomerRating)
                .ToListAsync();
        }
    }
}
