using eTrade.Application.Abstraction.Services.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTradeAPI.API.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult AuthorizeDefinationEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinationEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
