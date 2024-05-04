using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class ReportsController : Controller
    {
        // GET: ReportsController
        public ActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> SalesReports()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = "https://localhost:7185/api/SalesReportService/Get";
                    var httpResponse = await httpClient.GetAsync(url);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        var salesReportList = JsonConvert.DeserializeObject<List<vSalesReport>>(content);
                        return View(salesReportList);
                    }
                    else
                    {

                        var statusCode = httpResponse.StatusCode;

                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }

        }
        public async Task<IActionResult> TotalofSalesByRegion()
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var url = "https://localhost:44306/api/SalesReport";
                        var httpResponse = await httpClient.GetAsync(url);

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var content = await httpResponse.Content.ReadAsStringAsync();
                            var salesReportList = JsonConvert.DeserializeObject<List<vTotalofSalesByRegion>>(content);
                            return View(salesReportList);
                        }
                        else
                        {

                            var statusCode = httpResponse.StatusCode;

                            return View("Error");
                        }
                    }
                }
                catch (Exception ex)
                {

                    return View("Error");
                }
            }




    }
}
