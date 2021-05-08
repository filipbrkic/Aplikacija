using System;

namespace Application.Common.Models
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SeminarId { get; set; }
        public bool Status { get; set; }
    }
}
