using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MVC.Models
{
    public class RegistrationViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Adress")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public Guid SeminarId { get; set; }
        public bool Status { get; set; }
    }
}
