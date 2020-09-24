using RazorPages_SampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RazorPages_SampleApp.Pages.Products
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly RazorPages_SampleApp.Data.ProductContext _context;

        public EditModel(RazorPages_SampleApp.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                        .Include(p=> p.ProductCategory)
                        .FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateCategoryDropDownList(_context, Product.ProductCategoryID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productToUpdate = await _context.Products.FindAsync(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Product>(
                 productToUpdate,
                 "product",   // Prefix for form value.
                   c => c.AverageCustomerRating, c => c.ProductCategoryID, c => c.ProductName, c => c.PricePerItem))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ProductCategoryID if TryUpdateModelAsync fails.
            PopulateCategoryDropDownList(_context, productToUpdate.ProductCategoryID);
            return Page();
        }       
    }
}
