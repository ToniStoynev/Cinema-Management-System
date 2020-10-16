namespace CinemaManagementSystem.Application.Cinemas.Commands.UpdateCinema
{
    using FluentValidation;
    using static Domain.CinemasManagement.Models.ModelConstants.Cinema;

    public class UpdateCinemaCommandValidator : AbstractValidator<UpdateCinemaCommand>
    {
        public UpdateCinemaCommandValidator()
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
