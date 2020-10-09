namespace CinemaManagementSystem.Application.Cinemas.Queries.Search
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
