using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DAL.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Adress")]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public int SeminarId { get; set; }

        public bool Status { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
