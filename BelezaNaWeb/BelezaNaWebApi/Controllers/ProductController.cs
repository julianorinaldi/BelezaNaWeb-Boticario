using BelezaNaWebApplication.Services;
using BelezaNaWebDomain;
using BelezaNaWebDomain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.ListAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{sku}")]
        public async Task<Product> Get(string sku)
        {
            return await _productService.GetProductAsync(sku);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _productService.AddProduct(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{sku}")]
        public void Put(string sku, [FromBody] Product value)
        {
            if (string.IsNullOrWhiteSpace(sku) ||
                string.IsNullOrWhiteSpace(value?.SKU))
                throw new Exception("SKU incorreto!");

            _productService.UpdateProduct(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{sku}")]
        public void Delete(string sku)
        {
            _productService.DeleteProduct(sku);
        }
    }
}