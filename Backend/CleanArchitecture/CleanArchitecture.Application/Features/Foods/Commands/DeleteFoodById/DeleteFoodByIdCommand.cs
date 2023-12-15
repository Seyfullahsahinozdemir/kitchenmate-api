using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Foods.Commands.DeleteFoodById
{
    public class DeleteFoodByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFoodByIdCommandHandler : IRequestHandler<DeleteFoodByIdCommand, Response<int>>
        {
            private readonly IFoodRepositoryAsync _foodRepository;
            public DeleteFoodByIdCommandHandler(IFoodRepositoryAsync foodRepository)
            {
                _foodRepository = foodRepository;
            }
            public async Task<Response<int>> Handle(DeleteFoodByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _foodRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Food Not Found.");
                await _foodRepository.DeleteAsync(product);
                return new Response<int>(product.Id);
            }
        }
    }
}
