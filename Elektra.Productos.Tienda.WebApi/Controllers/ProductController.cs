using Elektra.Productos.Tienda.ApplicationServices.UseCases.InsertSku;
using Elektra.Productos.Tienda.ApplicationServices.UseCases.SearchSku;
using Elektra.Productos.Tienda.DomainModel.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Elektra.Productos.Tienda.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly ISender Sender;
        public ProductController(ISender sender)
        {
            Sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SearchSkuCommand command)
        {
            IEnumerable<Product> result = await Sender.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<int> Post(InsertSkuCommand command)
        {
            Task.Run(() => Log.Information("dsfdsfdsfdsf"));
            var result = await Sender.Send(command);
            return result;
        }
    }
}
