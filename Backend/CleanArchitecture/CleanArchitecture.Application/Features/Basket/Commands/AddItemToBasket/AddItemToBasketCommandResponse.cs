using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Basket.Commands.AddItemToBasket
{
    public class AddItemToBasketCommandResponse
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}
