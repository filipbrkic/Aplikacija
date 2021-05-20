using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MVC.Models
{
    public class RegistrationViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateTime { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Adress")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid SeminarId { get; set; }
        public bool Status { get; set; }
    }
}
