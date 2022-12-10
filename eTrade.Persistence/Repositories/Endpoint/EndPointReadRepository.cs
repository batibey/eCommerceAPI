using eTrade.Application.Repositories;
using eTrade.Domain.Entities;
using eTrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Persistence.Repositories
{
    public class EndPointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
    {
        public EndPointReadRepository(eTradeAPIDBContext context) : base(context)
        {
        }
    }
}
