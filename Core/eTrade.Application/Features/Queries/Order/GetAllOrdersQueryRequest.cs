﻿using MediatR;

namespace eTrade.Application.Features.Queries.Order
{
    public class GetAllOrdersQueryRequest: IRequest<GetAllOrdersQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}