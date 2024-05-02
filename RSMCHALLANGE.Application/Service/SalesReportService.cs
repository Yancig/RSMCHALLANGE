using RSMCHALLANGE.Application.DTOs;
using RSMCHALLANGE.Application.Interface;
using RSMCHALLANGE.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Application.Service
{
    public class SalesReportService : ISalesReportService
    {
        private readonly ISalesReportRepository _salesReportRepository;

        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }
        public async Task<IEnumerable<GetAllSalesReportDTOs>> GetAllSalesReport()
        {
            var salesReport = await _salesReportRepository.GetSalesReport();

            List<GetAllSalesReportDTOs> getAllSalesReportDTOs = [];
            foreach (var report in salesReport) 
            {
                GetAllSalesReportDTOs getAllSalesReportDT = new()
                {
                    OrderId = report.OrderId,
                    CustomerId= report.CustomerId,
                    ProductId= report.ProductId,
                    ProductName= report.ProductName,
                    ProductCategory= report.ProductCategory,
                    UnitPrice=  report.UnitPrice,
                    Quantity= report.Quantity,
                    TotalPrice= report.TotalPrice,
                    SalesPersonId= report.SalesPersonId,
                    SalesPersonName= report.SalesPersonName,
                    ShippingAddress= report.ShippingAddress,
                    BillingAddress= report.BillingAddress,
                };
                getAllSalesReportDTOs.Add(getAllSalesReportDT);
            }
            return getAllSalesReportDTOs;
        }
    }
}
