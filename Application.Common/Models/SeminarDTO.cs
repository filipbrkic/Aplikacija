using System;

namespace Application.Common.Models
{
    public class SeminarDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int ParticipantsCount { get; set; }
    }
}
