using CleanArchitecture.Core.Features.Orders.Commands.CompleteOrder;
using CleanArchitecture.Core.Features.Orders.Commands.CreateOrder;
using CleanArchitecture.Core.Features.Orders.Queries.GetAllOrders;
using CleanArchitecture.Core.Features.Orders.Queries.GetOrderById;
using CleanArchitecture.Core.Features.Products.Queries.GetAllProducts;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Core.Features.Orders.Commands.CancelOrder;
using CleanArchitecture.Core.Features.Orders.Commands.ChangeOrderStatus;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : BaseApiController
    {
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetOrderById([FromQuery] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
        {
            GetOrderByIdQueryResponse response = await Mediator.Send(getOrderByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await Mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await Mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }

        [HttpGet("complete-order/{Id}")]
        public async Task<ActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
        {
            CompleteOrderCommandResponse response = await Mediator.Send(completeOrderCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> CancelOrder([FromQuery] CancelOrderCommandRequest request)
        {
            CancelOrderCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> ChangeOrderStatus([FromQuery] ChangeOrderStatusCommandRequest request)
        {
            ChangeOrderStatusCommandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
