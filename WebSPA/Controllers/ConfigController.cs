using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSPA.Controllers
{
    public class ConfigController :ControllerBase
    {

        private readonly IConfiguration _configuration;
        private static readonly string AppVersion = "CommerceApp" + DateTime.UtcNow.ToString("yyyyMMddHHmmss");

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(
                new
                {
                    ApiUrl = _configuration.GetValue<string>("ApiUrl")
                }

                );
        }


    }
}
