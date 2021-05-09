using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MVC.Models
{
    public class RegistrationViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Adress")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid SeminarId { get; set; }
        public bool Status { get; set; }
    }
}
