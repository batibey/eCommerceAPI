using eTrade.Application.Consts;
using eTrade.Application.CustomAttributes;
using eTrade.Application.Enums;
using eTrade.Application.Features.Commands.Basket.AddItemToBasket;
using eTrade.Application.Features.Commands.Basket.RemoveBasketItem;
using eTrade.Application.Features.Commands.Basket.UpdateQuantity;
using eTrade.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTradeAPI.API.controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Baskets, ActionType = ActionType.Reading, Defination = "Get Basket Items")]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemQueryRequest getBasketItemsQueryRequest)
        {
            List<GetBasketItemQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Baskets, ActionType = ActionType.Writing, Defination = "Add Item to Basket")]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        {
            AddItemToBasketCommandResponse response = await _mediator.Send(addItemToBasketCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Baskets, ActionType = ActionType.Updating, Defination = "Update Quantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{BasketItemId}")]
        [AuthorizeDefination(Menu = AuthorizeDefinationConstants.Baskets, ActionType = ActionType.Deleting, Defination = "Remove Basket Item")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        {
            RemoveBasketItemCommandResponse response = await _mediator.Send(removeBasketItemCommandRequest);
            return Ok(response);
        }
    }
}
