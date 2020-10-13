namespace CinemaManagementSystem.Application.Cinemas.Commands.Create
{
    public class CreateCinemaOutputModel
    {
        public CreateCinemaOutputModel(int cinemaId)
        {
            this.CinemaId = cinemaId;
        }

        public int CinemaId { get; }
    }
}
