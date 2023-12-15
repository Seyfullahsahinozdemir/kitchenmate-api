using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class BasketItem: AuditableBaseEntity
    {
        public int BasketId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public Basket Basket { get; set; }
        public Food Food { get; set; }
    }
}
