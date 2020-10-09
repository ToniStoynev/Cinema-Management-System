namespace CinemaManagementSystem.Application.Cinemas.Queries.Search
{
    public class CinemaListingModel
    {
        public CinemaListingModel(int id, string name, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }
        public int Id { get; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
