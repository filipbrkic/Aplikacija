using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Predbiljezba
    {
        [Key]
        public int IdPredbiljezba { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Adress")]
        public string Email { get; set; }

        [Required]
        public string Telefon { get; set; }

        public int IdSeminar { get; set; }

        public bool Status { get; set; }

       public virtual Seminar Seminar { get; set; }
}
}
