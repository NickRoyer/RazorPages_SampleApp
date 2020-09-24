using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPages_SampleApp.Models;
using System.Collections.Generic;

namespace RazorPages_SampleApp.Data
{
    public class ProductDBSeeder : IContextSeeder
    {
        public void SeedContext(ModelBuilder mb)
        {
            var categories = new ProductCategory[]
            {
               new ProductCategory { ProductCategoryID=1, Name="Shoes" },
               new ProductCategory { ProductCategoryID=2, Name="Electronics" },
               new ProductCategory { ProductCategoryID=3, Name="Automotive" },
               new ProductCategory { ProductCategoryID=4, Name="Health" },
               new ProductCategory { ProductCategoryID=5, Name="Grocery" },
            };

            mb.Entity<ProductCategory>().HasData(categories);

            var products = new Product[]
            {
                new Product {ProductID = 1050, ProductName = "Basketball trainers",      AverageCustomerRating = 4.2M, PricePerItem = 199.99M,
                    ProductCategoryID = categories.Single( s => s.Name == "Shoes").ProductCategoryID
                },
                new Product {ProductID = 4022, ProductName = "Flat Screen TV", AverageCustomerRating = 3.8M, PricePerItem = 529.99M,
                    ProductCategoryID = categories.Single( s => s.Name == "Electronics").ProductCategoryID
                },
                new Product {ProductID = 4041, ProductName = "Truck Battery", AverageCustomerRating = 1.9M, PricePerItem = 125.00M,
                    ProductCategoryID = categories.Single( s => s.Name == "Automotive").ProductCategoryID
                },
                new Product {ProductID = 1045, ProductName = "Cold Medicine",       AverageCustomerRating = 4.8M, PricePerItem=2.25M,
                    ProductCategoryID = categories.Single( s => s.Name == "Health").ProductCategoryID
                },
                new Product {ProductID = 3141, ProductName = "Potato Chips",   AverageCustomerRating = 4.9M, PricePerItem=.99M,
                    ProductCategoryID = categories.Single( s => s.Name == "Grocery").ProductCategoryID
                },
                new Product {ProductID = 2021, ProductName = "Tennis shoe",    AverageCustomerRating = 3.2M, PricePerItem=39.99M,
                    ProductCategoryID = categories.Single( s => s.Name == "Shoes").ProductCategoryID
                },
                new Product {ProductID = 2042, ProductName = "Game System",     AverageCustomerRating = 4.5M, PricePerItem=699.00M,
                    ProductCategoryID = categories.Single( s => s.Name == "Electronics").ProductCategoryID
                },
            };

            mb.Entity<Product>().HasData(products);

        }
    }
}