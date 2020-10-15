namespace CinemaManagementSystem.Application.Cinemas.Queries.All
{
    using System.Collections.Generic;

    public class SearchCinemaOutputModel
    {
        internal SearchCinemaOutputModel(IEnumerable<CinemaListingModel> cinemas, int total)
        {
            this.cinemas = cinemas;
            this.Total = total;
        }

        public IEnumerable<CinemaListingModel> cinemas { get; } 

        public int Total { get; } 
    }
}
