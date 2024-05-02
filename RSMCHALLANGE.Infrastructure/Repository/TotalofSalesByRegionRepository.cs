using Microsoft.EntityFrameworkCore;
using RSMCHALLANGE.Infrastructure.Interface;
using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Repository
{
    public class TotalofSalesByRegionRepository : ITotalofSalesByRegionRepository 
    {
        private readonly AdvWorksDbContext _advWorksDbContext;

        public TotalofSalesByRegionRepository(AdvWorksDbContext advWorksDbContext)
        { 

            _advWorksDbContext =  advWorksDbContext;
        }

        public  async Task<IEnumerable<vTotalofSalesByRegion>> GetSalesByRegionReport()
        {
            return await _advWorksDbContext.Set<vTotalofSalesByRegion>()
                .AsNoTracking()
                .Take(15)
                .ToListAsync();

        }
        public async Task<List<vTotalofSalesByRegion>> GetTheTopSalesProducts()
        {
            var productSalesReport = await _advWorksDbContext.Set<vTotalofSalesByRegion>()
                .AsNoTracking()
                .GroupBy(x => new { x.Product, x.Category })
                .Select(g => new vTotalofSalesByRegion
                {
                    Product = g.Key.Product,
                    Category = g.Key.Category,
                    TotalSales = g.Sum(x => x.TotalSales)
                })
                .OrderByDescending(x => x.TotalSales)
                .Take(15)
                .ToListAsync();

            return productSalesReport;
        }


    }
}
