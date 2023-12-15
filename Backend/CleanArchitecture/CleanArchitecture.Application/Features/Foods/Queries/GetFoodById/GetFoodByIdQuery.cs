using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Foods.Queries.GetFoodById
{
    public class GetFoodByIdQuery : IRequest<Response<Food>>
    {
        public int Id { get; set; }
        public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, Response<Food>>
        {
            private readonly IFoodRepositoryAsync _foodRepository;
            public GetFoodByIdQueryHandler(IFoodRepositoryAsync foodRepository)
            {
                _foodRepository = foodRepository;
            }
            public async Task<Response<Food>> Handle(GetFoodByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _foodRepository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Food Not Found.");
                return new Response<Food>(product);
            }
        }
    }
}
