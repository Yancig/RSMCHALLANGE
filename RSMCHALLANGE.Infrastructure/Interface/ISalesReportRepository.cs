using RSMCHALLANGE.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Infrastructure.Interface
{
    public interface ISalesReportRepository
    {
        Task<IEnumerable<vSalesReport>> GetSalesReport();

    }
}
