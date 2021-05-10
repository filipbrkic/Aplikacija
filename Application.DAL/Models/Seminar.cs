using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DAL.Models
{
    public class Seminar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public int ParticipantsCount { get; set; }

        public UserIdentity User { get; set; }
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
