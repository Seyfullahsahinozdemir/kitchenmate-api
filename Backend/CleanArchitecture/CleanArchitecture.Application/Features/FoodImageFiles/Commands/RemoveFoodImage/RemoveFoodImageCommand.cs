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

namespace CleanArchitecture.Core.Features.FoodImageFiles.Commands.RemoveFoodImage
{
    public partial class RemoveFoodImageCommand: IRequest<Response<int>>
    {
        public int ImageId { get; set; }
    }

    public class RemoveFoodImageCommandHandler : IRequestHandler<RemoveFoodImageCommand, Response<int>>
    {
        private readonly IFoodImageRepository _foodImageRepository;

        public RemoveFoodImageCommandHandler(IFoodImageRepository foodImageRepository)
        {
            _foodImageRepository = foodImageRepository;
        }

        public async Task<Response<int>> Handle(RemoveFoodImageCommand request, CancellationToken cancellationToken)
        {
            var file = await _foodImageRepository.GetByIdAsync(request.ImageId);
            if (file == null) throw new ApiException($"Image File Not Found.");
            await _foodImageRepository.DeleteAsync(file);
            return new Response<int>(file.Id);
        }
    }


}
