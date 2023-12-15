using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class FoodRepositoryAsync : GenericRepositoryAsync<Food>, IFoodRepositoryAsync
    {
        public FoodRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
