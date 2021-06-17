using Application.MVC.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.MVC.Models
{
    public class SignupViewModel : PageModel
    {
        public LoginModel loginModel { get; set; }
        public RegisterModel registerModel { get; set; }
    }
}
