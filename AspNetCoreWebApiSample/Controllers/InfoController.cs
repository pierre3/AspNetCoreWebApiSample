using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebApiSample.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        // GET: api/info
        [HttpGet]
        public string Get()
        {
            return $"Azure mokumoku: {RuntimeInformation.OSDescription}, {RuntimeInformation.FrameworkDescription}";
        }

        
    }
}
