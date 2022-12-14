﻿using MediatR;

namespace eTrade.Application.Features.Queries.AppUser.GetRolesToUser
{
    public class GetRolesToUserQueryRequest : IRequest<GetRolesToUserQueryResponse>
    {
        public string UserId { get; set; }
    }
}