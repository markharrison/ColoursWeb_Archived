using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ColoursWeb.Pages
{
    public class AppConfigInfoModel : PageModel
    {
        IConfiguration _config;
        AppConfig _appconfig;
        public string strAppConfigInfoHtml;

        public AppConfigInfoModel(IConfiguration config, AppConfig appconfig)
        {
            _config = config;
            _appconfig = appconfig;
            strAppConfigInfoHtml = "";
        }
        public void OnGet()
        {
            strAppConfigInfoHtml += "OS Description: " + System.Runtime.InteropServices.RuntimeInformation.OSDescription + "<br/>";
            strAppConfigInfoHtml += "Framework Description: " + System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription + "<br/>";
            strAppConfigInfoHtml += "ASPNETCORE_ENVIRONMENT: " + _config.GetValue<string>("ASPNETCORE_ENVIRONMENT") + "<br/>";
            strAppConfigInfoHtml += "InstrumentationKey: " + _config.GetValue<string>("ApplicationInsights:InstrumentationKey") + "<br/>";
            strAppConfigInfoHtml += "BuildIdentifier: " + _config.GetValue<string>("BuildIdentifier") + "<br/>";
            strAppConfigInfoHtml += "APIUrl: " + Request.Cookies["APIUrl"] + "<br/>";
            strAppConfigInfoHtml += "APIMode: " + Request.Cookies["APIMode"] + "<br/>";
            strAppConfigInfoHtml += "Number of Lights: " + Request.Cookies["NumberLights"] + "<br/>";
        }
    }
}