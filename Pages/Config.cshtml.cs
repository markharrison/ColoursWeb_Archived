using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace ColourWeb.Pages
{
    public class ConfigModel : PageModel
    {
        [BindProperty]
        public string APIUrl { get; set; }

        public void OnGet()
        {
            var vURL = Request.Cookies["APIUrl"];
            if (vURL != null)
                APIUrl = vURL.ToString();
            else
                APIUrl = "https://markcolourapi.azurewebsites.net/colour/random";
        }

        public IActionResult OnPost()
        {
            if (APIUrl != null)
            {
                Response.Cookies.Append("APIUrl", APIUrl,
                    new CookieOptions
                    {
                        HttpOnly = false,
                        Secure = false,
                        Expires = DateTime.Now.AddMonths(12)
                    }
                );
                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Config");
        }

    }
}