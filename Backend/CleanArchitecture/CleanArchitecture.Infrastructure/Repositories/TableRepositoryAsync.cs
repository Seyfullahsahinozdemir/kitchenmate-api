using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Contexts;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class TableRepositoryAsync : GenericRepositoryAsync<Table>, ITableRepositoryAsync
    {
        public TableRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
