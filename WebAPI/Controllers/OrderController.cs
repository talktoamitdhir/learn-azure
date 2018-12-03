using Core.Interfaces.CloudServices;
using Newtonsoft.Json;
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
        private readonly IServiceBusHelper _queueHelper;
        public OrderController(IOrderService orderService, IServiceBusHelper queueHelper)
        {
            _orderService = orderService;
            _queueHelper = queueHelper;
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get all orders", type: typeof(Order))]
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get order id", type: typeof(Order))]
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IHttpActionResult> GetOrder([FromUri]string id)
        {
            return Ok(await _orderService.GetOrderAsync(id));
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Insert Order", type: typeof(Order))]
        [HttpPost]
        [Route("InsertOrder")]
        public async Task InsertOrder([FromBody]Order order)
        {
            await _queueHelper.SendMessageAsync(JsonConvert.SerializeObject(order), "orders");       
        }
    }
}
