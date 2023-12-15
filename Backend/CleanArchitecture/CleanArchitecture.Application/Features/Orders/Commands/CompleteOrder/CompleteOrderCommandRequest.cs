using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.CompleteOrder
{
    public class CompleteOrderCommandRequest: IRequest<CompleteOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}
