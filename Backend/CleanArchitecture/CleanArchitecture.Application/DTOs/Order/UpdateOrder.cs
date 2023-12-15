using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.DTOs.Order
{
    public class UpdateOrder
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
