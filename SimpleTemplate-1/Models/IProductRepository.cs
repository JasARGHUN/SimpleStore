using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get;}
        Product SaveProduct(Product product);
        Product DeleteProduct(int productID);
        Product Add(Product product);
        Task<Product> GetProduct(int? ProductID);
    }
}
