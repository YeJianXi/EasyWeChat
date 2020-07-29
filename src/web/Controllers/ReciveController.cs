using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{

    //[ApiController]
    //[Route("[controller]/[action]")]
    public class ReciveController : Controller
    {

        [HttpGet]
        [Route("[controller]")]
        public IActionResult Recive()
        {
            return Content("");
        }
    }
}