using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandRequest: IRequest<UpdateOrderCommandResponse>
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
