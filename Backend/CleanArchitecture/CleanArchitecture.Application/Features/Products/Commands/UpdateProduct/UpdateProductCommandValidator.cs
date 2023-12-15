using CleanArchitecture.Core.Features.Foods.Commands.CreateFood;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepositoryAsync _productRepository;

        public UpdateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this._productRepository = productRepository;

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await _productRepository.IsUniqueBarcodeAsync(barcode);
        }
    }
}
