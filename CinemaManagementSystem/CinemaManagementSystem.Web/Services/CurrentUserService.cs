﻿namespace CinemaManagementSystem.Web.Services
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Application.Identity;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUser
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException(
                    "This request does not have an authenticated user.");
            }

            this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            
        }
        public string UserId { get; }
    }
}
