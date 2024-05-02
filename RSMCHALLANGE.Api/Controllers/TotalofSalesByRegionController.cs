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
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            return Ok(await _totalofSalesByRegionService.RetrieveSalesByRegionReport());
        }
        [HttpGet("GetTopSalesProduct")]
        public async Task<IActionResult> GetTopSalesProduct()
        {
            return Ok(await _totalofSalesByRegionService.GetTopProduct());
        }

        // GET api/<TotalofSalesByRegionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TotalofSalesByRegionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TotalofSalesByRegionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TotalofSalesByRegionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
