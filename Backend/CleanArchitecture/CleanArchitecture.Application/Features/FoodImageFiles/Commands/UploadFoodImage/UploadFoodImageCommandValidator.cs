using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Foods.Commands.CreateFood;
using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;

namespace CleanArchitecture.Core.Features.FoodImageFiles.Commands.UploadFoodImage
{
    public class UploadFoodImageCommandValidator: AbstractValidator<UploadFoodImageCommand>
    {

        public UploadFoodImageCommandValidator(IFoodRepositoryAsync foodRepositoryAsync)
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Food Id is required")
                .NotNull();


        }

        //private async Task<bool> IsFoodExist(int foodId, CancellationToken cancellationToken)
        //{
        //    Food food = await _foodRepositoryAsync.GetByIdAsync(foodId);
        //    if (food == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
