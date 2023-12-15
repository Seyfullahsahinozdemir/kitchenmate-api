using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandRequest: IRequest<CancelOrderCommandResponse>
    {
        public int Id { get; set; }
    }
}
