namespace CinemaManagementSystem.Application.Cinemas.Commands.AddProjection
{
    using FluentValidation;
    using static Domain.CinemasManagement.Models.ModelConstants.Movie;
    using static Domain.CinemasManagement.Models.ModelConstants.Projection;

    public class AddProjectionCommandValidator : AbstractValidator<AddProjectionCommand>
    {
        public AddProjectionCommandValidator()
        {
            RuleFor(p => p.Name)
                .MinimumLength(MinMovieNameLength)
                .MaximumLength(MaxMovieNameLength)
                .NotEmpty();

            RuleFor(p => p.DurationMinutes)
                .ExclusiveBetween(MinMovieDuration, MaxMovieDuration);

            RuleFor(p => p.StartDate)
                .NotEmpty();

            RuleFor(p => p.AvailableSeatsCount)
                .ExclusiveBetween(MinAvailableSeatsCount, MaxAvailableSeatsCount);

            
        }
    }
}
