using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Table.Commands.CreateTable
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {

        public CreateTableCommandValidator()
        {
            RuleFor(t => t.Description)
                .NotEmpty().WithMessage("Table description cannot be empty")
                .NotNull()
                .MaximumLength(100).WithMessage("Table description must not exceed 100 characters.");
        }

    }
}
