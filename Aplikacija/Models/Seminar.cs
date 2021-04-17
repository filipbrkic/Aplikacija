using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Opis { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public bool Popunjen { get; set; }

        public virtual ICollection<Predbiljezba> Predbiljezbas { get; set; }
    }
}