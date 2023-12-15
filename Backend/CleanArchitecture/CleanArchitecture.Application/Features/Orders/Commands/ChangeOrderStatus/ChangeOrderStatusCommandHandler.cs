using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandHandler: IRequestHandler<ChangeOrderStatusCommandRequest, ChangeOrderStatusCommandResponse>
    {
        private IOrderService _orderService;

        public ChangeOrderStatusCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ChangeOrderStatusCommandResponse> Handle(ChangeOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.ChangeOrderStatus(request.OrderId, request.Status);
            return new ChangeOrderStatusCommandResponse();
        }
    }
}
