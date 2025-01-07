using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSales.Data;
using WebSales.Models;

namespace WebSales.Services
{
    public class SalesRecordService
    {
        private readonly WebSalesContext _context;

        public SalesRecordService(WebSalesContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindBydDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);
            if (maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                .Include(x => x.Sell) // Inclui o 
                .ThenInclude(s => s.Dep) // Inclui o departamento do vendedor
                .OrderByDescending(x => x.Date) // Ordena por data
                .ToListAsync();
        }       
        public async Task<List<IGrouping<Department, SalesRecord >>> FindBydDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);
            if (maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);

            return await result
                .Include(x => x.Sell) // Inclui o 
                .ThenInclude(s => s.Dep) // Inclui o departamento do vendedor
                .OrderByDescending(x => x.Date) // Ordena por data
                .GroupBy(x => x.Sell.Dep)
                .ToListAsync();
        }
    }
}
