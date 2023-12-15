using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Enums;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommandRequest: IRequest<ChangeOrderStatusCommandResponse>
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
