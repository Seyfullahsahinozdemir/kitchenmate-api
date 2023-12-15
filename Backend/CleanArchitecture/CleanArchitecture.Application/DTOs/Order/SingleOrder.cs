using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Enums;

namespace CleanArchitecture.Core.DTOs.Order
{
    public class SingleOrder
    {
        public List<string> Foods { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; }
        public string WaiterId { get; set; }
    }
}
