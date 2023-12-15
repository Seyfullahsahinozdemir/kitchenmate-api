using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Basket.Queries.GetBasketItems
{
    public class GetBasketItemsQueryResponse
    {
        public int BasketItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
