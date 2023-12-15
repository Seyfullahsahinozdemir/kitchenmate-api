using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;

namespace CleanArchitecture.Core.Features.Foods.Queries.GetAllFoods
{
    public class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodsQueryRequest, IList<GetAllFoodQueryResponse>>
    {
        private readonly IFoodRepositoryAsync _foodRepository;
        private readonly IFoodImageRepository _foodImageRepository;

        public GetAllFoodQueryHandler(IFoodRepositoryAsync foodRepository, IFoodImageRepository foodImageRepository)
        {
            _foodRepository = foodRepository;
            _foodImageRepository = foodImageRepository;
        }

        public async Task<IList<GetAllFoodQueryResponse>> Handle(GetAllFoodsQueryRequest request, CancellationToken cancellationToken)
        {
            var foods = await _foodRepository.GetAllAsync();
            IList<GetAllFoodQueryResponse> response = new List<GetAllFoodQueryResponse>();
            foreach (var data in foods)
            {
                var image = await _foodImageRepository.GetByIdAsync(data.Id);
                if (image != null)
                {
                    response.Add(new GetAllFoodQueryResponse()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Price = data.Price,
                        Type = data.Type,
                        FoodImageFileId = data.FoodImageFileId,
                        ImagePath = image.Path,
                        ImageName = image.FileName
                    });
                }
                else
                {
                    response.Add(new GetAllFoodQueryResponse()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Price = data.Price,
                        Type = data.Type
                    });
                }
            }
            return response;
        }
    }
}
