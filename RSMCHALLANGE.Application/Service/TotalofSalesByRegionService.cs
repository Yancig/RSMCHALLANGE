using RSMCHALLANGE.Application.DTOs;
using RSMCHALLANGE.Application.Interface;
using RSMCHALLANGE.Infrastructure.Interface;
using RSMCHALLANGE.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Application.Service
{
    public class TotalofSalesByRegionService : ITotalofSalesByRegionService
    {
        private readonly ITotalofSalesByRegionRepository _totalofSalesByRegionRepository;

        public TotalofSalesByRegionService(ITotalofSalesByRegionRepository totalofSalesByRegionRepository)

        {
            _totalofSalesByRegionRepository = totalofSalesByRegionRepository;
        }
        public async Task<IEnumerable<GetAllTotalofSalesByRegionDTOs>> RetrieveSalesByRegionReport()
        {
            var salesReportByRegion = await _totalofSalesByRegionRepository.GetSalesByRegionReport();

            List<GetAllTotalofSalesByRegionDTOs> getAllTotalofSalesByRegionDTOs = [];

            foreach (var report in salesReportByRegion)
            {
                GetAllTotalofSalesByRegionDTOs getAllTotalofSalesByRegionDT = new GetAllTotalofSalesByRegionDTOs()
                {


                    Product = report.Product,
                    Category = report.Category,
                    TotalSales = report.TotalSales,
                    PercentageOfTotalSalesInRegion = report.PercentageOfTotalSalesInRegion,
                    PercentajeOfTotalCategorySalesInRegion = report.PercentajeOfTotalCategorySalesInRegion,
                };
                getAllTotalofSalesByRegionDTOs.Add(getAllTotalofSalesByRegionDT);
            }
            return getAllTotalofSalesByRegionDTOs;
        }

        public async Task<IEnumerable<TheTopSalesProductDTOs>> GetTopProduct()
        {
            var salesReportByRegion = await _totalofSalesByRegionRepository.GetTheTopSalesProducts();

            List<TheTopSalesProductDTOs> theTopSalesProductDTs = [];

            foreach (var report in salesReportByRegion)
            {
                TheTopSalesProductDTOs getAllTotalofSalesByRegionDT = new TheTopSalesProductDTOs()
                {
                    Product = report.Product,
                    Category = report.Category,
                    TotalSales = report.TotalSales,
                };

                theTopSalesProductDTs.Add(getAllTotalofSalesByRegionDT);
            }
            return theTopSalesProductDTs;
        
        }
    }
}
