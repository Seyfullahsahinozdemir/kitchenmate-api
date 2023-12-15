using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CleanArchitecture.Core.Enums;

namespace CleanArchitecture.Core.Entities
{
    public class Order: AuditableBaseEntity
    {
        public int TableId { get; set; }
        public string WaiterId { get; set; }
        public int? ChefId { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public Table Table { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus Statu { get; set; }
    }
}
