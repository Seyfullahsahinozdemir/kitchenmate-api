using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Features.Basket.Commands.AddItemToBasket

{
    public partial class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }

}
