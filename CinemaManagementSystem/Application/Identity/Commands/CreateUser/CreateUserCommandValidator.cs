﻿namespace CinemaManagementSystem.Application.Identity.Commands.CreateUser
{
    using FluentValidation;

    using static Domain.CinemasManagement.Models.ModelConstants.Common;
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(MaxPassLength)
                .NotEmpty();

        }
    }
}
