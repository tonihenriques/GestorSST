using Furiza.AspNetCore.WebApp.Configuration;
using Furiza.AspNetCore.WebApp.Configuration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Gestor.RazorPages.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly WebApplicationLoginManager webApplicationLoginManager;
        private readonly ApplicationProfile applicationProfile;

        [BindProperty]
        [Required]
        public string Username { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        [BindProperty]
        public string reCaptchaToken { get; set; }

        public LoginModel(WebApplicationLoginManager webApplicationLoginManager,
            ApplicationProfile applicationProfile)
        {
            this.webApplicationLoginManager = webApplicationLoginManager ?? throw new ArgumentNullException(nameof(webApplicationLoginManager));
            this.applicationProfile = applicationProfile ?? throw new ArgumentNullException(nameof(applicationProfile));
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToPage("/Index");
            else
                return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (!ModelState.IsValid)
                return Page();

            await webApplicationLoginManager.reCaptcha(reCaptchaToken);
            await webApplicationLoginManager.LoginAsync(applicationProfile.ClientId.Value, Username, Password);

            return new JsonResult(
                new
                {
                    returnUrl = !string.IsNullOrWhiteSpace(returnUrl)
                    ? returnUrl
                    : Url.Page("/Index")
                });
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await webApplicationLoginManager.LogoutAsync();

            return new JsonResult(
                new
                {
                    returnUrl = Url.Page("/Account/Login")
                });
        }
    }
}