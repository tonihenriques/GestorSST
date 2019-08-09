using Furiza.AspNetCore.WebApp.Configuration.RestClients.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Gestor.RazorPages.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IUsersClient usersClient;

        [BindProperty]
        [Required]
        public string Current { get; set; }

        [BindProperty]
        [Required]
        public string New { get; set; }

        [BindProperty]
        [Required]
        [Compare("New", ErrorMessage = "The new password and confirmation password do not match.")]
        public string Confirm { get; set; }

        public ChangePasswordModel(IUsersClient usersClient)
        {
            this.usersClient = usersClient ?? throw new ArgumentNullException(nameof(usersClient));
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            await usersClient.ChangePasswordPostAsync(new ChangePasswordPost()
            {
                CurrentPassword = Current,
                NewPassword = New
            });
        }
    }
}