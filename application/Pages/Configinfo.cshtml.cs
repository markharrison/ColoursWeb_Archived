using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ColourWeb.Pages
{
    public class ConfiginfoModel : PageModel
    {
        IConfiguration _config;
        public string strConfigHtml;

        public ConfiginfoModel(IConfiguration config)
        {
            _config = config;
            strConfigHtml = "";
        }
        public void OnGet()
        {
            strConfigHtml += "OS Description: " + System.Runtime.InteropServices.RuntimeInformation.OSDescription + "<br/>";
            strConfigHtml += "ASPNETCORE_ENVIRONMENT: " + _config.GetValue<string>("ASPNETCORE_ENVIRONMENT") + "<br/>";
            strConfigHtml += "InstrumentationKey: " + _config.GetValue<string>("ApplicationInsights:InstrumentationKey") + "<br/>";
            strConfigHtml += "BuildIdentifier: " + _config.GetValue<string>("BuildIdentifier") + "<br/>";
        }
    }
}