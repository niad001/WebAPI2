using System;
using System.Collections.Generic;
using WebApiPractice.Controllers;
using WebApiPractice.Models;

namespace WebApiPractice.Tests.Fixtures {
    public class ProductsControllerFixture : IDisposable {
        public IEnumerable<Product> Products {
            get; set;
        }

        public ProductsController Controller {
            get; set;
        }

        public ProductsControllerFixture() {
            Products = new[] {
                new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };

            Controller = new ProductsController( Products );
        }

        public void Dispose() {
        }
    }
}
