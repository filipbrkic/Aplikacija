using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Zaposlenik
    {
        [Key]
        public int IdZaposlenik { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Password { get; set; }
    }
}
