using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Application.DTOs
{
    public class GetAllTotalofSalesByRegionDTOs
    {
        public string? Product { get; set; }
        public string? Category { get; set; }
        public decimal?  TotalSales { get; set; }
        public decimal?  PercentageOfTotalSalesInRegion { get; set; }
        public decimal? PercentajeOfTotalCategorySalesInRegion { get; set; }
    }
}
