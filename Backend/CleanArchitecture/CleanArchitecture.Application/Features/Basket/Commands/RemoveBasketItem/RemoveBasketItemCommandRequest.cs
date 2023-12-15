using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Basket.Commands.RemoveBasketItem
{
    public class RemoveBasketItemCommandRequest: IRequest<RemoveBasketItemCommandResponse>
    {
        public int BasketItemId { get; set; }
    }
}
