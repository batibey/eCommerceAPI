using MediatR;

namespace eTrade.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemQueryRequest : IRequest<List<GetBasketItemQueryResponse>>
    {
    }
}