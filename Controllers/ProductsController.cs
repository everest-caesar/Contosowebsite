using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Shifts.Website.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shifts.Website.Controllers

{
    [Route("[controller]")]
    [ApiController]

    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public JsonFileProductService ProductService { get; }
        public ProductsController(JsonFileProductService service)
        {
            this.ProductService = service;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }


        [Route("Rate")]
        [HttpGet]
        
        public ActionResult Get([FromQuery]string ProductId, [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok(); 
        }

    }
}

