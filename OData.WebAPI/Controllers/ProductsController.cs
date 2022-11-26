using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.WebAPI.Models;

namespace OData.WebAPI.Controllers
{
   
    public class ProductsController : ODataController
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Products);
        }
    }
}
