using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Foods.Commands.CreateFood
{
    public partial class CreateFoodCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
    }
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Response<int>>
    {
        private readonly IFoodRepositoryAsync _foodRepository;
        private readonly IMapper _mapper;
        public CreateFoodCommandHandler(IFoodRepositoryAsync productRepository, IMapper mapper)
        {
            _foodRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Food>(request);
            await _foodRepository.AddAsync(product);
            return new Response<int>(product.Id, "Food adding successful");
        }
    }
}
