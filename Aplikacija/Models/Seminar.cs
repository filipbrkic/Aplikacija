using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Data
{
    public class Seminar
    {
        [Key]
        public int IdSeminar { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public DateTime Datum { get; set; }

        public bool Popunjen { get; set; }

        public virtual ICollection<Predbiljezba> Predbiljezbas { get; set; }
    }
}