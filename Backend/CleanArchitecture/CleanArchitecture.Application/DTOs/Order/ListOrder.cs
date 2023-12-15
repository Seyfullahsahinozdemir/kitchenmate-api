using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs.Order
{
    public class ListOrder
    {
        public int OrderId { get; set; }
        public int TotalOrderCount { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
