using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MVC.Models
{
    public class SeminarViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Number of participants")]
        public int ParticipantsCount { get; set; }
    }
}
