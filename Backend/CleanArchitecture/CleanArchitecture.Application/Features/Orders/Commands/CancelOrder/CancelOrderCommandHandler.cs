using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Enums;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;

namespace CleanArchitecture.Core.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandHandler: IRequestHandler<CancelOrderCommandRequest, CancelOrderCommandResponse>
    {
        private IOrderRepositoryAsync _orderRepositoryAsync;
        private ITableRepositoryAsync _tableRepositoryAsync;
        public CancelOrderCommandHandler(IOrderRepositoryAsync orderRepositoryAsync, ITableRepositoryAsync tableRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _tableRepositoryAsync = tableRepositoryAsync;
        }

        public async Task<CancelOrderCommandResponse> Handle(CancelOrderCommandRequest request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepositoryAsync.GetByIdAsync(request.Id);
            if (order.Statu == OrderStatus.Taken)
            {
                Entities.Table table = await _tableRepositoryAsync.GetByIdAsync(order.TableId);
                await _orderRepositoryAsync.DeleteAsync(order);
                table.Active = false.ToString();

                return new CancelOrderCommandResponse
                {
                    Success = true
                };
            }

            throw new ApiException("Order not in taken mode.");
        }
    }
}
