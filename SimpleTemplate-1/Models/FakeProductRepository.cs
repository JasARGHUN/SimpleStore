using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public class FakeProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Product 1", Description = "Some description", Price = 500},
            new Product {Name = "Product 2", Description = "Some description", Price = 155},
            new Product {Name = "Product 3", Description = "Some description", Price = 345}
        }.AsQueryable<Product>();
    }
}
