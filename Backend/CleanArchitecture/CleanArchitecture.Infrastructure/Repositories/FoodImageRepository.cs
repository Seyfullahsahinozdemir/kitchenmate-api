using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class FoodImageRepository : GenericRepositoryAsync<FoodImageFile>, IFoodImageRepository
    {
        public FoodImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
