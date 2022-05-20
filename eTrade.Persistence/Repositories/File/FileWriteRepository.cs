using eTrade.Application.Repositories;
using eTrade.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<eTrade.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(eTradeAPIDBContext context) : base(context)
        {
        }
    }
}
