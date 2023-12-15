using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.ViewModels;
using MediatR;

namespace CleanArchitecture.Core.Features.Basket.Commands.UpdateQuantity
{
    public class UpdateQuantityCommandHandler: IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        private readonly IBasketService _basketService;

        public UpdateQuantityCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateQuantityAsync(new VM_Update_BasketItem
            {
                BasketItemId = request.BasketItemId,
                Quantity = request.Quantity
            });
            return new UpdateQuantityCommandResponse();
        }
    }
}
