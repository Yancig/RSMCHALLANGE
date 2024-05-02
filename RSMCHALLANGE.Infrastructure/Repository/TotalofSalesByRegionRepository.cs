using Microsoft.EntityFrameworkCore;
using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Repository
{
    public class TotalofSalesByRegionRepository
    {
        private readonly AdvWorksDbContext _advWorksDbContext;

        public TotalofSalesByRegionRepository(AdvWorksDbContext advWorksDbContext)
        { 

            _advWorksDbContext =  advWorksDbContext;
        }

        public async Task<IEnumerable<vTotalofSalesByRegion>> GetTotalofSalesByRegion()
        {
            return await _advWorksDbContext.Set<vTotalofSalesByRegion>()
                .AsNoTracking()
                .Take(15)
                .ToListAsync();
        }

    }
}
