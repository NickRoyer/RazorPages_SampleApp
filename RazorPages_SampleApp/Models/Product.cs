using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages_SampleApp.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ProductID { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Display(Name = "Rating")]
        [Range(0, 5)]
        public decimal AverageCustomerRating { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerItem { get; set; }


        public int ProductCategoryID { get; set; }
        [Display(Name = "Category")]
        public virtual ProductCategory ProductCategory { get; set; }
       
    }
}