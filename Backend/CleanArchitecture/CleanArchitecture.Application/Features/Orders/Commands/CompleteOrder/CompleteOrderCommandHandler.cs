using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.DTOs.Order;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.CompleteOrder
{
    public class CompleteOrderCommandHandler: IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
    {
        private IOrderService _orderService;

        public CompleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            (bool succeeded, CompletedOrderDTO dto) = await _orderService.CompleteOrderAsync(request.Id);
            return new CompleteOrderCommandResponse();
        }
    }
}
