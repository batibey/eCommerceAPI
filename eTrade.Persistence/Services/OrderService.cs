using eTrade.Application.Abstraction.Services;
using eTrade.Application.DTOs.Order;
using eTrade.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTrade.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Id = Guid.Parse(createOrder.BasketId),
                Description = createOrder.Description
            });
            await _orderWriteRepository.SaveAsync();
        }
    }
}
