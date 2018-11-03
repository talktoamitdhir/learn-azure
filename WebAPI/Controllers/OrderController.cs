using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [SwaggerResponse(HttpStatusCode.BadRequest, description: "Bad request", type: null)]
    [AllowAnonymous]
    [RoutePrefix("Orders")]
    public class OrderController : ApiController
    {
        public OrderController()
        {

        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get all orders", type: typeof(Order))]
        [HttpGet]
        [Route("GetAllOrders")]
        public IHttpActionResult GetAllOrders()
        {
            return Ok();
        }
    }
}
