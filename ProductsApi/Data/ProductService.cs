using ProductsApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Data
{
    public class ProductService
    {

        public static Double GetTotalPriceOfProducts(IEnumerable<Product> products)
        {
            var totalSum = products.Sum(p => p.Price);
            return totalSum;
        }

        public static IEnumerable<Product> GetValidProducts(IEnumerable<Product> products)
        {
            var validProducts = products.Where(p => p.ValidTo > DateTime.Now).ToList();
            return validProducts;
        }

        public static Double GetTotalPriceOfValidProducts(IEnumerable<Product> products)
        {

            var totalSum = products.Sum(p => p.Price );
            return totalSum;
        }
    }
}
