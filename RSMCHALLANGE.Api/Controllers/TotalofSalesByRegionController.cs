using Microsoft.AspNetCore.Mvc;
using RSMCHALLANGE.Application.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSMCHALLANGE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalofSalesByRegionController : ControllerBase
    {
        private readonly ITotalofSalesByRegionService _totalofSalesByRegionService;
        public TotalofSalesByRegionController(ITotalofSalesByRegionService totalofSalesByRegionService)
        {
            _totalofSalesByRegionService = totalofSalesByRegionService;
        }
        // GET: api/<TotalofSalesByRegionController>
        [HttpGet("SalesByRegion")]
        public async Task <IActionResult> SalesByRegion()
        {
            return Ok(await _totalofSalesByRegionService.RetrieveSalesByRegionReport());
        }
        [HttpGet("GetTopSalesProduct")]
        public async Task<IActionResult> GetTopSalesProduct()
        {
            return Ok(await _totalofSalesByRegionService.GetTopProduct());
        }

      
    }
}
