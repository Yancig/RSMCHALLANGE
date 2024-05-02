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
    public class SalesReportRepository : ISalesReportRepository 
    {
        private readonly AdvWorksDbContext _advWorksDbContext;

        public SalesReportRepository(AdvWorksDbContext advWorksDbContext)
        {

            _advWorksDbContext = advWorksDbContext;
        }

        public async Task<IEnumerable<vSalesReport>> GetSalesReport()
        {
            return await _advWorksDbContext.Set<vSalesReport>()
                .AsNoTracking()
                .Take(15)
                .ToListAsync();
        }
    }
}
