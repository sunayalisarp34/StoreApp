using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using System.Runtime.CompilerServices;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IRepositoryManager _manager;
        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index() 
        {
            var model = _manager.Product.GetAllProducts(false);

            return View(model);
        }
        public IActionResult Get(int id) 
        {
            //Product product = _context.Products.First(p => p.ProductId.Equals(id));
            throw new NotImplementedException();
        }
        //Api Veri Atma
        //public IEnumerable<Product> Index()
        //{
            
        //    return _context.Products;
        //    // veri tabanından veri çekme
        //    //var context = new RepositoryContext(
        //    //    new DbContextOptionsBuilder<RepositoryContext>()
        //    //    .UseSqlite("Data Source = C:\\CSharpProjects\\ProductDb.db")
        //    //    .Options);

        //    //return context.Products;

        //    //return new List<Product>() 
        //    //{
        //    //    new Product(){ProductId=1, ProductName="Computer",Price=5}
        //    //};
        //}
    }
}
