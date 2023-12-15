using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Core.Features.Waiters.Commands.CreateWaiter
{
    public class CreateWaiterCommandValidator: AbstractValidator<CreateWaiterCommand>
    {
        public CreateWaiterCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Waiter name is required");

        }
    }
}
