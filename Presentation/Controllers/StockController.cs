using Application.Interface.StockInterface;
using Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ICreateStock createStock;
        public StockController(ICreateStock createStock)
        {
            this.createStock = createStock;

        }

        [HttpPost("CreateStock")]
        public async Task<ActionResult> CreateStock(List<PolygonApiResultViewModel> model)
        {
            var result = await createStock.Execute(model);
            return Ok(result);
        }
    }
}
