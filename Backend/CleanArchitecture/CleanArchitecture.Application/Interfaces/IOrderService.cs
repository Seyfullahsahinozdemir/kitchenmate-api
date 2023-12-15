using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.DTOs.Order;
using CleanArchitecture.Core.Enums;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task<List<SingleOrder>> GetAllOrdersAsync(int page, int size);
        Task<SingleOrder> GetOrderByIdAsync(int id);
        Task<(bool, CompletedOrderDTO)> CompleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(UpdateOrder updateOrder);
        Task ChangeOrderStatus(int id, OrderStatus status);
    }
}
