using CleanArchitecture.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ChefRepositoryAsync : GenericRepositoryAsync<Chef>, IChefRepositoryAsync
    {
        public ChefRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
