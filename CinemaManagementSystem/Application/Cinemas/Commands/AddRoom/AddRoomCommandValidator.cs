namespace CinemaManagementSystem.Application.Cinemas.Commands.AddRoom
{
    using FluentValidation;
    using static Domain.CinemasManagement.Models.ModelConstants.Room;

    public class AddRoomCommandValidator : AbstractValidator<AddRoomCommand>
    {
        public AddRoomCommandValidator()
        {
            this.RuleFor(r => r.Number)
                .ExclusiveBetween(MinRoomNumber, MaxRoomNumber);

            this.RuleFor(r => r.Rows)
                .ExclusiveBetween(MinRowsCount, MaxRowsCount);

            this.RuleFor(r => r.SeatsPerRow)
                .ExclusiveBetween(MinSeatsPerRow, MaxSeatsPerRow);
        }
    }
}
