using RazorPages_SampleApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RazorPages_SampleApp.Pages.Products
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList CategoryNameSL { get; set; }

        public void PopulateCategoryDropDownList(ProductContext _context,
            object selectedCategory = null)
        {
            var categoriesQuery = from d in _context.ProductCategories
                                   orderby d.Name // Sort by name.
                                   select d;

            CategoryNameSL = new SelectList(categoriesQuery.AsNoTracking(),
                        "ProductCategoryID", "Name", selectedCategory);
        }
    }
}