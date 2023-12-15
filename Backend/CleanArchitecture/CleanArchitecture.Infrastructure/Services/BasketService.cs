using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Enums;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services
{
    public class BasketService: IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderRepositoryAsync _orderRepositoryAsync;
        private readonly IBasketItemRepositoryAsync _itemRepositoryAsync;
        private readonly IBasketRepositoryAsync _basketRepositoryAsync;
        IAuthenticatedUserService _authenticatedUserService;
        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IOrderRepositoryAsync orderRepositoryAsync, IBasketItemRepositoryAsync itemRepositoryAsync, IBasketRepositoryAsync basketRepositoryAsync, IAuthenticatedUserService authenticatedUserService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderRepositoryAsync = orderRepositoryAsync;
            _itemRepositoryAsync = itemRepositoryAsync;
            _basketRepositoryAsync = basketRepositoryAsync;
            _authenticatedUserService = authenticatedUserService;
        }

        private async Task<Basket> GetBasket()
        {
            string id = _authenticatedUserService.UserId;
            ApplicationUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new ApiException("User Not Found");
            }

            Basket basket = await _basketRepositoryAsync.GetSingleAsync(t => t.UserId == user.Id && t.Statu == BasketStatus.Active);
            if (basket == null)
            {
                basket = await _basketRepositoryAsync.AddAsync(new Basket
                {
                    UserId = user.Id,
                    Statu = BasketStatus.Active
                });
                return basket;
            }

            return basket;

        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket basket = await GetBasket();
            Basket? result = await _basketRepositoryAsync.Table
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Food)
                .FirstOrDefaultAsync(b => b.Id == basket.Id);
            return result.BasketItems.ToList();
        }

        public async Task AddItemToBasketAsync(VM_Create_BasketItem basketItemVM)
        {
            var basket = await GetBasket();

            BasketItem basketItem =
                await _itemRepositoryAsync.GetSingleAsync(bi =>
                    bi.BasketId == basket.Id && bi.FoodId == basketItemVM.FoodId);
            if (basketItem != null)
            {
                basketItem.Quantity += basketItemVM.Quantity;
                await _itemRepositoryAsync.UpdateAsync(basketItem);
            }
            else
            {
                await _itemRepositoryAsync.AddAsync(new BasketItem
                {
                    BasketId = basket.Id,
                    FoodId = basketItemVM.FoodId,
                    Quantity = basketItemVM.Quantity
                });
            }
        }

        public async Task UpdateQuantityAsync(VM_Update_BasketItem basketItemVM)
        {
            BasketItem? basketItem = await _itemRepositoryAsync.GetByIdAsync(basketItemVM.BasketItemId);
            if (basketItem != null)
            {
                basketItem.Quantity = basketItemVM.Quantity;
                await _itemRepositoryAsync.UpdateAsync(basketItem);
            }
        }

        public async Task RemoveBasketItemAsync(int basketItemId)
        {
            BasketItem? basketItem = await _itemRepositoryAsync.GetByIdAsync(basketItemId);
            if (basketItem != null)
            {
                await _itemRepositoryAsync.DeleteAsync(basketItem);
            }
        }

        public Basket GetUserActiveBasket
        {
            get
            {
                Basket basket = GetBasket().Result;
                return basket;
            }
        }
    }
}
