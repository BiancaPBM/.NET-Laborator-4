using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Entities;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            var products = _repository.GetAll();
            if (products.ToList().Count == 0)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product =_repository.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            _repository.Create(product);
            return CreatedAtAction("CreateProduct", product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _repository.Delete(id);
            return StatusCode(204);
        }

        [HttpGet("sumprices")]
        public IActionResult GetTotalPriceOfProducts()
        {
            var totalSum = ProductService.GetTotalPriceOfProducts(_repository.GetAll());
            return Ok(totalSum);
        }

        [HttpGet("validproducts")]
        public IActionResult GetValidProducts()
        {
            var validProducts = ProductService.GetValidProducts(_repository.GetAll());
            if (validProducts.ToList().Count == 0)
                return NotFound();
            return Ok(validProducts);
        }

        [HttpGet("sumvalidprices")]
        public IActionResult GetTotalPriceOfValidProducts()
        {
            var totalSum = ProductService.GetTotalPriceOfValidProducts(ProductService.GetValidProducts(_repository.GetAll()));
            return Ok(totalSum);
        }

    }
}