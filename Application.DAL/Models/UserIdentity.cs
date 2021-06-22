using Microsoft.AspNetCore.Identity;
using System;

namespace Application.DAL.Models
{
    public class UserIdentity : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
