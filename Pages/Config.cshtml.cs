using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace ColoursWeb.Pages
{
    public class ConfigModel : PageModel
    {
        [BindProperty]
        public string APIUrl { get; set; }
        [BindProperty]
        public bool APIMode { get; set; }

        public void OnGet()
        {
            var vURL = Request.Cookies["APIUrl"];
            if (vURL != null) {
                APIUrl = vURL.ToString();
                APIMode = (Request.Cookies["APIMode"] == "Direct") ;
            }
            else
            {
                APIUrl = "https://coloursapi.azurewebsites.net/colours/random";
                APIMode = true;
            }
                
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
                Response.Cookies.Append("APIMode", (APIMode) ? "Direct" : "" ,
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