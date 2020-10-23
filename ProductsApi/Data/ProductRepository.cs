using Microsoft.EntityFrameworkCore.Storage;
using ProductsApi.Entities;
using ProductsApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data
{
    public class ProductRepository:IProductRepository
    {
        private DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(ProductModel product)
        {
            var maxId = _context.Products.Max(p => p.Id);
            var newProduct = new Entities.Product()
            { Id = maxId, 
              ValidFrom = product.ValidFrom,
              Name = product.Name,
              Price = product.Price,
              ValidTo = product.ValidTo 
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productToBeDeleted = _context.Products.First(p => p.Id == id);
            if (productToBeDeleted == null)
            {
            }
            _context.Products.Remove(productToBeDeleted);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
           return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {

             _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
