using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SM.Training.Api.Controllers;
using SM.Training.Utils;
using System;
using static SM.Training.Api.Controllers.BaseController;

namespace SM.CollateralMng.Api.Controllers
{
    [Route("api/Global")]
    public class GlobalController : BaseController
    {
        // GET: api/Global
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "Api is running: " + DateTime.Now.ToString();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetAppInfomation")]
        public GlobalDto GetAppInfomation(GlobalDto request)
        {
            GlobalDto response = new GlobalDto();
            response.AppName = "Training app";
            response.Version = "*";
            response.Copyright = "Softmart";

            response.AndroidAppLink = "";
            response.IosAppLink = "";

            response.BuildVersion = "*";

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LogError")]
        public GlobalDto LogError(GlobalDto request)
        {
            string msg = string.Join(Environment.NewLine, request.DeviceInfo, request.ExceptionInfo);
            LogManager.Mobile.LogError(msg, null);

            return new GlobalDto();
        }
    }

    public class GlobalDto : BaseDTO
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public string Copyright { get; set; }
        public string AndroidAppLink { get; set; }
        public string IosAppLink { get; set; }
        public string AndroidGoogleMapKey { get; set; }
        public string IosGoogleMapKey { get; set; }

        public string DeviceInfo { get; set; }
        public string ExceptionInfo { get; set; }
        public string BuildVersion { get; set; }
        public string WebURL { get; set; }
        public string ExceptionMessage { get; set; }

        public GlobalFilter Filter { get; set; }
    }

    public class GlobalFilter
    {
        public int? SystemParameterID { get; set; }
        public int? FeatureID { get; set; }
        public int? Ext1i { get; set; }
    }
}
