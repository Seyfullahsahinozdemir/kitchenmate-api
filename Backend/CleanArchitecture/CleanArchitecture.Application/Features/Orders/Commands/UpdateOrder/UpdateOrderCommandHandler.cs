using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Enums;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler: IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        IOrderService _orderService;

        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(request.Id);
            if (order.Status == OrderStatus.Taken.ToString())
            {
                DTOs.Order.UpdateOrder updateOrder = new DTOs.Order.UpdateOrder
                {
                    Food = request.Food,
                    Id = request.Id,
                    Quantity = request.Quantity
                };
                return new UpdateOrderCommandResponse { Succeed = await _orderService.UpdateOrderAsync(updateOrder) };
            }

            throw new ApiException("Order statu not taken");
        }
    }
}
