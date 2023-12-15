using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryRequest: IRequest<GetAllOrdersQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
