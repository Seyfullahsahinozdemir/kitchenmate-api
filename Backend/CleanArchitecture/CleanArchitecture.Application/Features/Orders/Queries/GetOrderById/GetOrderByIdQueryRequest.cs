using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryRequest: IRequest<GetOrderByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
