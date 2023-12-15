using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Response<int>>
        {
            private readonly IFoodRepositoryAsync _foodRepository;
            public UpdateFoodCommandHandler(IFoodRepositoryAsync foodRepository)
            {
                _foodRepository = foodRepository;
            }
            public async Task<Response<int>> Handle(UpdateFoodCommand command, CancellationToken cancellationToken)
            {
                var food = await _foodRepository.GetByIdAsync(command.Id);

                if (food == null) throw new EntityNotFoundException("food", command.Id);

                food.Name = command.Name;
                food.Description = command.Description;
                food.Price = command.Price;
                food.Type = command.Type;

                await _foodRepository.UpdateAsync(food);
                return new Response<int>(food.Id);
            }
        }
    }
}
