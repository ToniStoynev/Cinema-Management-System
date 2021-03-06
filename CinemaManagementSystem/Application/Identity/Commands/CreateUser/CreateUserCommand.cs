﻿namespace CinemaManagementSystem.Application.Identity.Commands.CreateUser
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public CreateUserCommand(string email, string password)
            : base(email, password)
        {
            
        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity)
                => this.identity = identity;

            public Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
                => this.identity.Register(request);
        }
    }
}
