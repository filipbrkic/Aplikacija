using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }

        public DateTime Datum { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Adresa { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

        public int IdSeminar { get; set; }

        public bool Status { get; set; }

        public virtual Seminar Seminar { get; set; }
}
}
