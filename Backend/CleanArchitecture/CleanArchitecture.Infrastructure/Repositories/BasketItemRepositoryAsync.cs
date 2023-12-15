using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BasketItemRepositoryAsync: GenericRepositoryAsync<BasketItem>, IBasketItemRepositoryAsync
    {
        public BasketItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
