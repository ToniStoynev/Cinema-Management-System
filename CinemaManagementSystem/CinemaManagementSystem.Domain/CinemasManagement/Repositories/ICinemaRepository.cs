﻿namespace CinemaManagementSystem.Domain.CinemasManagement.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    public interface ICinemaRepository
    {
        Task<int> Find(int id, CancellationToken cancellationToken = default);
    }
}
