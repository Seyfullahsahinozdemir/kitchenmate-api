using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Food: AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public int? FoodImageFileId { get; set; }
        public FoodImageFile? ImageFile { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
