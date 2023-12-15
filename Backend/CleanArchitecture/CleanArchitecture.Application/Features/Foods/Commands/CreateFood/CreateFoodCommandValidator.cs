using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Foods.Commands.CreateFood
{
    public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
    {
        private readonly IFoodRepositoryAsync _foodRepository;

        public CreateFoodCommandValidator(IFoodRepositoryAsync foodRepository)
        {
            this._foodRepository = foodRepository;
            

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Food Name is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Food Name must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Food Description is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("Food Description must not exceed 200 characters.");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("Food Type is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Food Type must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Food Price is required.")
                .GreaterThan(0).WithMessage("Food Price must be positive.")
                .NotNull();

        }

    }
}
