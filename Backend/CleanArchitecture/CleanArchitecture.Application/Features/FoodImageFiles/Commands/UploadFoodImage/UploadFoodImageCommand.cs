using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Storage;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;

namespace CleanArchitecture.Core.Features.FoodImageFiles.Commands.UploadFoodImage
{
    public partial class UploadFoodImageCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        //public IFormFileCollection? Files { get; set; }
        public IFormFile File { get; set; }
    }

    public class UploadFoodImageCommandHandler : IRequestHandler<UploadFoodImageCommand, Response<int>>
    {
        private readonly IStorageService _storageService;
        private readonly IFoodRepositoryAsync _foodRepository;
        private readonly IFoodImageRepository _foodImageRepository;

        public UploadFoodImageCommandHandler(IFoodImageRepository foodImageRepository, IFoodRepositoryAsync foodRepository, IStorageService storageService)
        {
            _foodImageRepository = foodImageRepository;
            _foodRepository = foodRepository;
            _storageService = storageService;
        }

        public async Task<Response<int>> Handle(UploadFoodImageCommand request, CancellationToken cancellationToken)
        {
            (string fileName, string pathOrContainerName) result = await _storageService.UploadAsync("food-images", request.File);


            Food food = await _foodRepository.GetByIdAsync(request.Id);

            if (food == null)
            {
                throw new EntityNotFoundException("Food not found, check food id");
            }

            if (food.FoodImageFileId != null)
                throw new ImageAlreadyExistException();

            FoodImageFile imageFile = await _foodImageRepository.AddAsync(new FoodImageFile
            {
                FileName = result.fileName,
                Path = result.pathOrContainerName,
                Storage = _storageService.StorageName
            });

            imageFile.Food = food;
            food.ImageFile = imageFile;
            food.FoodImageFileId = imageFile.Id;
            await _foodRepository.UpdateAsync(food);
            return new Response<int>(food.Id, "Image added successful");
        }
    }
}
