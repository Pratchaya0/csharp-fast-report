using Microsoft.AspNetCore.Mvc;
using SimpleFastReport.API.Helpers;
using SimpleFastReport.API.Services;

namespace SimpleFastReport.API.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _services;
        private readonly FastReportHelper _fastReportHelper;

        public ReportController(IReportServices services, FastReportHelper fastReportHelper)
        {
            _services = services;
            _fastReportHelper = fastReportHelper;
        }

        [HttpGet("data-json")]
        public async Task<IActionResult> GetListProduct()
        {
            var products = await _services.ListProductAsync();

            return Ok(products);
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> PDFReport()
        {
            var products = await _services.ListProductAsync();

            return await _fastReportHelper.ExportReport(products, "ExampleReportII.frx", "fileName", ExportType.PDF);
        }

        [HttpGet("{productID}")]
        public async Task<IActionResult> GetFulldetailProductByID([FromRoute] int productID)
        {
            try
            {

                var product = await _services.FulldetailProductByIDAsync(productID);

                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
