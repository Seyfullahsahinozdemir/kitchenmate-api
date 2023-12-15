using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.DTOs.Order;
using CleanArchitecture.Core.Interfaces;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler: IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
    {
        readonly IOrderService _orderService;

        public GetAllOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            List<SingleOrder> data = await _orderService.GetAllOrdersAsync(request.Page, request.Size);

            return new GetAllOrdersQueryResponse()
            {
                TotalOrderCount = data.Count,
                Orders = data
            };
        }
    }
}
