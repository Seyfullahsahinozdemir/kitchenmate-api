using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.DTOs.Order;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Enums;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services
{
    public class OrderService: IOrderService
    {
        private IOrderRepositoryAsync _orderRepositoryAsync;
        private ITableRepositoryAsync _tableRepositoryAsync;
        private IBasketService _basketService;
        IBasketRepositoryAsync _basketRepositoryAsync;
        private UserManager<ApplicationUser> _userManager;
        IAuthenticatedUserService _authenticatedUserService;
        public OrderService(IOrderRepositoryAsync orderRepositoryAsync, ITableRepositoryAsync tableRepositoryAsync, UserManager<ApplicationUser> userManager, IBasketRepositoryAsync basketRepositoryAsync, IBasketService basketService, IAuthenticatedUserService authenticatedUserService)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _tableRepositoryAsync = tableRepositoryAsync;
            _userManager = userManager;
            _basketRepositoryAsync = basketRepositoryAsync;
            _basketService = basketService;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(".") + 1, orderCode.Length - orderCode.IndexOf(".") - 1);
            string id = _authenticatedUserService.UserId;
            Order order = await _orderRepositoryAsync.AddAsync(new()
            {
                BasketId = createOrder.BasketId,
                OrderCode = orderCode,
                TableId = createOrder.TableId,
                WaiterId = id,
                Statu = OrderStatus.Taken
            });

            Table table = await _tableRepositoryAsync.GetByIdAsync(createOrder.TableId);
            table.Active = true.ToString();
            await _tableRepositoryAsync.UpdateAsync(table);

            Basket basket = _basketService.GetUserActiveBasket;
            if (basket != null)
            {
                basket.Statu = BasketStatus.Inactive;
            }
            await _basketRepositoryAsync.UpdateAsync(basket);
            
        }

        public async Task<List<SingleOrder>> GetAllOrdersAsync(int page, int size)
        {
            if (page <= 0)
            {
                page = 1; 
            }

            var query = _orderRepositoryAsync.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(bi => bi.Food)
                .Skip((page - 1) * size)
                .Take(size);

            var data = await query.Select(order => new SingleOrder
            {
                Foods = order.Basket.BasketItems.Select(item => item.Food.Name).ToList(),
                TotalPrice = order.Basket.BasketItems.Sum(item => item.Food.Price * item.Quantity),
                Status = order.Statu.ToString(),
                WaiterId = order.WaiterId
            }).ToListAsync();

            return data;
        }

        public async Task<SingleOrder> GetOrderByIdAsync(int id)
        {
            var query = _orderRepositoryAsync.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(bi => bi.Food).Where(w => w.Id == id);

            var data = await query.Select(order => new SingleOrder
            {
                Foods = order.Basket.BasketItems.Select(item => item.Food.Name).ToList(),
                TotalPrice = order.Basket.BasketItems.Sum(item => item.Food.Price * item.Quantity),
                Status = order.Statu.ToString()
            }).FirstOrDefaultAsync();

            return data;
        }

        public async Task<(bool, CompletedOrderDTO)> CompleteOrderAsync(int id)
        {
            //Order? order = await _orderRepositoryAsync.Table
            //    .Include(o => o.Basket)
            //    .Include(t => t.Table)
            //    .FirstOrDefaultAsync(o => o.Id == id);

            //if (order != null)
            //{
            //    await _completedOrderRepositoryAsync.AddAsync(new() { OrderId = id });
            //    var waiter = await _userManager.FindByIdAsync(order.Basket.UserId);
            //    return (true, new CompletedOrderDTO
            //    {
            //        OrderCode = order.OrderCode,
            //        OrderDate = order.Created,
            //        WaiterName = waiter.UserName,
            //        TableName = order.Table.Description
            //    });
            //}

            return (false, null);
        }

        public async Task ChangeOrderStatus(int id, OrderStatus status)
        {
            var order = await _orderRepositoryAsync.GetByIdAsync(id);
            if (order == null)
            {
                throw new ApiException("Check Order Id");
            }
            order.Statu = status;
            await _orderRepositoryAsync.UpdateAsync(order);
        }

        public async Task<bool> UpdateOrderAsync(UpdateOrder updateOrder)
        {
            var order = await _orderRepositoryAsync.Table
                .Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .FirstOrDefaultAsync(o => o.Id == updateOrder.Id);

            if (order == null)
                return false;

            var existingBasketItem = order.Basket.BasketItems
                .FirstOrDefault(bi => bi.FoodId == updateOrder.Food.Id);

            if (existingBasketItem != null)
            {
                existingBasketItem.Quantity = updateOrder.Quantity;
            }
            else
            {
                order.Basket.BasketItems.Add(new BasketItem
                {
                    Food = updateOrder.Food,
                    Quantity = updateOrder.Quantity
                });
            }

            await _orderRepositoryAsync.UpdateAsync(order);

            return true;
        }
    }
}
