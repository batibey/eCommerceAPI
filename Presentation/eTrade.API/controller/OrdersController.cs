using eTrade.Application.Consts;
using eTrade.Application.CustomAttributes;
using eTrade.Application.Enums;
using eTrade.Application.Features.Commands.Order.CompleteOrder;
using eTrade.Application.Features.Commands.Order.CreateOrder;
using eTrade.Application.Features.Queries.Order;
using eTrade.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTradeAPI.API.controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Orders, ActionType = ActionType.Reading, Defination = "Get Order By Id")]
        public async Task<ActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
        {
            GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Orders, ActionType = ActionType.Reading, Defination = "Get All Orders")]
        public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Orders, ActionType = ActionType.Writing, Defination = "Create Order")]
        public async Task<ActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }

        [HttpGet("complete-order/{Id}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Orders, ActionType = ActionType.Updating, Defination = "Update Order")]
        public async Task<ActionResult> CompletedOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
        {
            CompleteOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
            return Ok(response);
        }
    }
}
