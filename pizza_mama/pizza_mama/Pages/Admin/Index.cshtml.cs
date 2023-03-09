using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool DisplayInvalidAccountMessage = false;
        public bool IsDevelopmentMode = false;
        IConfiguration configuration;
        public IndexModel(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            if (env.IsDevelopment())
            {
                IsDevelopmentMode = true;
            }
        }
        public IActionResult OnGet()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/admin/pizzas");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl) 
        {
            var authSection = configuration.GetSection("Auth");

            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];
            if (username == adminLogin && password == adminPassword)
            {
				DisplayInvalidAccountMessage = false;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,username),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login"); 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
				return Redirect(ReturnUrl == null ? "/Admin/pizzas" : ReturnUrl);
            }
			DisplayInvalidAccountMessage = true;
			return Page();
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin");
        }
    }
}
