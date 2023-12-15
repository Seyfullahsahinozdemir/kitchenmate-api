using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Basket.Commands.UpdateQuantity
{
    public class UpdateQuantityCommandRequest: IRequest<UpdateQuantityCommandResponse>
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
