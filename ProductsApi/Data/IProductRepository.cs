using ProductsApi.Entities;
using ProductsApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void Create(ProductModel product);
        public void Update(Product product);
        public void Delete(int id);
    }
}
