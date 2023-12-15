using CleanArchitecture.Core.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public int TotalOrderCount { get; set; }
        public List<SingleOrder> Orders { get; set; }
    }
}
