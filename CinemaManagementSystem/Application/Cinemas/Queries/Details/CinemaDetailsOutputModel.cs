namespace CinemaManagementSystem.Application.Cinemas.Queries.Details
{
    public class CinemaDetailsOutputModel
    {
        public CinemaDetailsOutputModel(string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
        public string Name { get; private set; }

        public string Address { get; private set; }
    }
}
