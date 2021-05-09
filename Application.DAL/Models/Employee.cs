using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DAL.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
