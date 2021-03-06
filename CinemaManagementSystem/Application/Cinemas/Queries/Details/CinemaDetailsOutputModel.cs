﻿namespace CinemaManagementSystem.Application.Cinemas.Queries.Details
{
    using Common.Mapping;
    using Domain.CinemasManagement.Models.Cinemas;
    public class CinemaDetailsOutputModel : IMapFrom<Cinema>
    {
        public string Name { get; private set; } = default!;

        public string Address { get; private set; } = default!;
    }
}
