namespace CinemaManagementSystem.Domain.CinemasManagement.Specifications.Cinemas
{
    using Models.Cinemas;
    using System;
    using System.Linq.Expressions;

    public class CinemaByIdSpecification : Specification<Cinema>
    {
        private readonly int? id;

        public CinemaByIdSpecification(int id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Cinema, bool>> ToExpression()
            => cinema => cinema.Id == this.id;
    }
}
