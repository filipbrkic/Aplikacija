using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DAL.Models
{
    public class UserIdentity : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
