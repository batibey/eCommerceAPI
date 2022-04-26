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
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(eTradeAPIDBContext context) : base(context)
        {

        }
    }
}
