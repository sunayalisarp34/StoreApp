using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using System.Runtime.CompilerServices;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index() 
        {
            var model = _manager.ProductService.GetAllProducts(false);

            return View(model);
        }
        public IActionResult Get([FromRoute(Name ="id")] int id) 
        {
            //Product product = _context.Products.First(p => p.ProductId.Equals(id));
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
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
