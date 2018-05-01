using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Data.Persistence.DataContext;
using NHibernate.Entity.Models;
using NHibernate.Service.Services;

namespace NHibernate.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            var context = new DataContext();
            _productService = new ProductService(context);
        }

        [HttpGet]
        [Produces(typeof(List<Product>))]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [Produces(typeof(Product))]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _productService.Get((int)id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            _productService.Add(product);

            return CreatedAtRoute("GetProduct", new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var dataProduct = _productService.Get(id);
            if (dataProduct == null)
            {
                return NotFound();         
            }

            dataProduct.Description = product.Description;
            _productService.Update(dataProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Remove(product);
            return NoContent();
        }



    }
}
