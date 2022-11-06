using eTrade.Application.Abstraction.Services.Configurations;
using eTrade.Application.CustomAttributes;
using eTrade.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTradeAPI.API.controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [AuthorizeDefination(ActionType = ActionType.Reading, Defination = "Get Authorize Definition Endpoints", Menu = "Application Services")]
        public IActionResult AuthorizeDefinationEndpoints()
        {
            var datas = _applicationService.GetAuthorizeDefinationEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
