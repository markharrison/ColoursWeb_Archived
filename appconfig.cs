using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ColoursWeb
{
    public class AppConfig
    {
        private string _AdminPWVal;
        public AppConfig(IConfiguration _config)
        {
            _AdminPWVal = _config.GetValue<string>("AdminPW");
        }
 
        public string AdminPW
        {
            get => this._AdminPWVal;
            set => this._AdminPWVal = value;
        }
    }
}
