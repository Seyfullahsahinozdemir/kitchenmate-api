using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.DTOs.Order
{
    public class CreateOrder
    {
        public int BasketId { get; set; }
        public int TableId { get; set; }
    }
}
