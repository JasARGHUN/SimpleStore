using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Products;

        public Product SaveProduct(Product productDataUpdate) //Метод сохраняет обьект в БД.
        {
            var prod = _context.Products.Attach(productDataUpdate);
            prod.State = EntityState.Modified;
            _context.SaveChanges();
            return productDataUpdate;
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = _context.Products.FirstOrDefault(i => i.ProductID == productID);
            if(dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public Product Add(Product product) //Метод добавляет обьект в БД.
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        public async Task<Product> GetProduct(int? id) //Метод получает обьект из БД.
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
