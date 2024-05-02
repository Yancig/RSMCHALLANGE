using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Interface
{
    public interface ITotalofSalesByRegionRepository
    {
        Task<IEnumerable<vTotalofSalesByRegion>> GetSalesByRegionReport();
        Task<List<vTotalofSalesByRegion>> GetTheTopSalesProducts();

    }
}
