using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.Interfaces.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [SwaggerResponse(HttpStatusCode.BadRequest, description: "Bad request", type: null)]
    [AllowAnonymous]
    [RoutePrefix("Orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get all orders", type: typeof(Order))]
        [HttpGet]
        [Route("GetAllOrders")]
        public IHttpActionResult GetAllOrders()
        {
            return Ok();
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get order id", type: typeof(Order))]
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IHttpActionResult> GetOrder([FromUri]string id)
        {
            return Ok(await _orderService.GetOrderAsync(id));
        }
    }
}
