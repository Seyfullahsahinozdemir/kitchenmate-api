using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandRequest: IRequest<CreateOrderCommandResponse>
    {
        public int TableId { get; set; }
    }
}
