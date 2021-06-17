using System;
using System.ComponentModel.DataAnnotations;

namespace Application.MVC.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string LastName { get; set; }
    }
}
