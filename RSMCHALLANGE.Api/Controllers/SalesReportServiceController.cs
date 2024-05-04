using Microsoft.AspNetCore.Mvc;
using RSMCHALLANGE.Application.DTOs;
using RSMCHALLANGE.Application.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSMCHALLANGE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportServiceController : ControllerBase
    {
        private readonly ISalesReportService _salesReportService;

        public SalesReportServiceController(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
        }


        // GET: api/<SalesReportServiceController>
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _salesReportService.GetAllSalesReport());
        }

       

    }
}
