using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SimpleTemplate_1.Models;
using SimpleTemplate_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ViewResult> List(int page = 1)
        {
            int pageSize = 2; // количество объектов на странице.
            IQueryable<Product> source = _repository.Products.AsNoTracking().OrderBy(p => p.ProductID);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProductsListViewModel productsListViewModel = new ProductsListViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };

            return View(productsListViewModel);
        }
        public async Task<ViewResult> Details(int? id)
        {
            Product product = await _repository.GetProduct(id.Value);

            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id.Value);
            }

            return View(product);
        }
    }
}
