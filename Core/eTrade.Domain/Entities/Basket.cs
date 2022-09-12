using eTrade.Domain.Entities.Common;
using eTrade.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
