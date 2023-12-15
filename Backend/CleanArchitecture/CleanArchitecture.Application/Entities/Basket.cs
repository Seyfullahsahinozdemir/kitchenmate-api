using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Enums;
using Newtonsoft.Json;

namespace CleanArchitecture.Core.Entities
{
    public class Basket: AuditableBaseEntity
    {
        public string UserId { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public BasketStatus Statu { get; set; }
    }
}
