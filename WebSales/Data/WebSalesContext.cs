using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebSales.Models;

namespace WebSales.Data
{
    public class WebSalesContext : DbContext
    {
        public WebSalesContext (DbContextOptions<WebSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
      
    }
}
