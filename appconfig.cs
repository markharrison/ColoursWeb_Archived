using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ColoursWeb
{
    public class AppConfig
    {
        //private string _ThingsAPIUrl;
        private string _AdminPWVal;
        public AppConfig(IConfiguration _config)
        {
            //_ThingsAPIUrl = _config.GetValue<string>("ThingsAPIUrl");
            //if (!_ThingsAPIUrl.EndsWith("/"))
            //{
            //    _ThingsAPIUrl += "/";
            //}

            _AdminPWVal = _config.GetValue<string>("AdminPW");
        }

        //public string ThingsAPIUrl
        //{
        //    get => this._ThingsAPIUrl;
        //    set
        //    {
        //        this._ThingsAPIUrl = value;
        //        if (!_ThingsAPIUrl.EndsWith("/"))
        //        {
        //            _ThingsAPIUrl += "/";
        //        }
        //    }
        //}

    
        public string AdminPW
        {
            get => this._AdminPWVal;
            set => this._AdminPWVal = value;
        }
    }
}
