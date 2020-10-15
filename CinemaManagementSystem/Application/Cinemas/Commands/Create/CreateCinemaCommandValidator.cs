namespace CinemaManagementSystem.Application.Cinemas.Commands.Create
{
    using FluentValidation;
    using static Domain.CinemasManagement.Models.ModelConstants.Cinema;

    public class CreateCinemaCommandValidator : AbstractValidator<CreateCinemaCommand>
    {
        public CreateCinemaCommandValidator()
        {
            this.RuleFor(c => c.Name)
                .MinimumLength(MinCinemaName)
                .MaximumLength(MaxCinemaName)
                .NotEmpty();

            this.RuleFor(c => c.Address)
                .MinimumLength(MinAddressName)
                .MaximumLength(MaxAddressName)
                .NotEmpty();
        }
    }
}
