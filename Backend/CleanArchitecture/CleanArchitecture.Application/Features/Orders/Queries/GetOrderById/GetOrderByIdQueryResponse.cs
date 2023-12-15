using CleanArchitecture.Core.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryResponse
    {
        public SingleOrder Order { get; set; }
    }
}
