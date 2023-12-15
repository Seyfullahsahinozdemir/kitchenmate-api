using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BasketRepositoryAsync : GenericRepositoryAsync<Basket>, IBasketRepositoryAsync
    {
        public BasketRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
