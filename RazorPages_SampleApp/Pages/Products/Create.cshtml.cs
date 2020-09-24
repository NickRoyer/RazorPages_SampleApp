using RazorPages_SampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RazorPages_SampleApp.Pages.Products
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly RazorPages_SampleApp.Data.ProductContext _context;

        public CreateModel(RazorPages_SampleApp.Data.ProductContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCategoryDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduct = new Product();

            if (await TryUpdateModelAsync<Product>(
                 emptyProduct,
                 "product",   // Prefix for form value.
                 s => s.ProductID, s => s.ProductCategoryID, s => s.ProductName, s => s.AverageCustomerRating, s => s.PricePerItem))
            {
                _context.Products.Add(emptyProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateCategoryDropDownList(_context, emptyProduct.ProductCategoryID);
            return Page();
        }
      }
}