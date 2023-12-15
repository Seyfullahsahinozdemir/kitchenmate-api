using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IFoodImageRepository : IGenericRepositoryAsync<FoodImageFile>
    {
    }
}
