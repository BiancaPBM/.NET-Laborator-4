using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductsApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions optionsBuilder): base(optionsBuilder)
        {
        }
        
        public DbSet<Product> Products { get; set; }
    }
}
