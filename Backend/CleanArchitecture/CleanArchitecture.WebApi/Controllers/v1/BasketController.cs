using System.Threading.Tasks;
using CleanArchitecture.Core.Features.Basket.Commands.AddItemToBasket;
using CleanArchitecture.Core.Features.Basket.Commands.RemoveBasketItem;
using CleanArchitecture.Core.Features.Basket.Commands.UpdateQuantity;
using CleanArchitecture.Core.Features.Basket.Queries.GetBasketItems;
using CleanArchitecture.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BasketController : BaseApiController
    {
        IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            this._basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketsItems([FromQuery] GetBasketItemsQueryRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpDelete("{BasketItemId}")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
