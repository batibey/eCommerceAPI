using eTrade.Application.Repositories;
using eTrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<eTrade.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(eTradeAPIDBContext context) : base(context)
        {
        }
    }
}