using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NbgCrmCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NbgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CrmDbContext db;

        public ProductController(CrmDbContext db)
        {
            this.db = db;
        }
        // GET: api/<ProductController>?productName=chips&maxPrice=2
        [HttpGet]
        public async Task< IEnumerable<Product>> Get(
            [FromQuery] string productName, [FromQuery] decimal? maxPrice)
        {
            var result = db.Products.Select(p => p); 
            if (productName != null)
                result = result.Where(product => product.Name.Contains(productName));

            if (maxPrice != null)
                result = result.Where(product => product.Price <= maxPrice);

            return await result.ToListAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            db.Products.Add(value);
            db.SaveChanges();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            Product product = db.Products.Find(id);
            product.Price = value.Price;
            db.SaveChanges();

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                db.Products.Remove(db.Products.Find(id));
                db.SaveChanges();
                return true;
            }
           catch(Exception e)
            {
                return false;  
            }
        }
    }
}
