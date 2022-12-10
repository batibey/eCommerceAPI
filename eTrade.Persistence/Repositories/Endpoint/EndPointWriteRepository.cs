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
    public class EndPointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndPointWriteRepository(eTradeAPIDBContext context) : base(context)
        {
        }
    }
}
