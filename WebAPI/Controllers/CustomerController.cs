using Swashbuckle.Swagger.Annotations;
using System.Web.Http;
using System.Net;
using WebAPI.Interfaces.Services;
using Core.Interfaces.CloudServices;
using System.Threading.Tasks;
using Core.Models;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [SwaggerResponse(HttpStatusCode.BadRequest, description: "Bad Request", type:null)]
    [AllowAnonymous]
    [RoutePrefix("Customers")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IServiceBusHelper _queueHelper;

        public CustomerController(ICustomerService customerService, IServiceBusHelper queueHelper)
        {
            _customerService = customerService;
            _queueHelper = queueHelper;
        }

        [SwaggerResponse(HttpStatusCode.OK,description: "Get all Customers", type: typeof(Customer)]
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            return Ok(await _customerService.GetCustomersAsync());
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Get Customer id", type: typeof(Customer)]
        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IHttpActionResult> GetCustomer([FromUri]string id)
        {
            return Ok(await _customerService.GetCustomerAsync(id));
        }

        [SwaggerResponse(HttpStatusCode.OK, description: "Insert Customer", type: typeof(Customer))]
        [HttpPost]
        [Route("InsertOrder")]
        public async Task InsertOrder([FromBody]Customer customer)
        {
            await _queueHelper.SendMessageAsync(JsonConvert.SerializeObject(customer), "customers");
        }
    }
}
