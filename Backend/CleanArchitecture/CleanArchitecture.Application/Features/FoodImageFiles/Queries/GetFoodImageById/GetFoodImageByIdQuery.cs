using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;

namespace CleanArchitecture.Core.Features.FoodImageFiles.Queries.GetFoodImageById
{
    public class GetFoodImageByIdQuery: IRequest<Response<FoodImageFile>>
    {
        public int ImageId { get; set; }

        public class GetFoodImageByIdQueryHandler: IRequestHandler<GetFoodImageByIdQuery, Response<FoodImageFile>>
        {
            private readonly IFoodImageRepository _foodImageRepository;

            public GetFoodImageByIdQueryHandler(IFoodImageRepository foodImageRepository)
            {
                _foodImageRepository = foodImageRepository;
            }

            public async Task<Response<FoodImageFile>> Handle(GetFoodImageByIdQuery request, CancellationToken cancellationToken)
            {
                var image = await _foodImageRepository.GetByIdAsync(request.ImageId);
                if (image == null) throw new EntityNotFoundException("Food image not exist");
                return new Response<FoodImageFile>(image);
            }
        }
    }
}
