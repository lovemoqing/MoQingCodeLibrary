using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoQing.Domain;

namespace MoQing.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("/{id}")]
        public ActionResult<ApiResult> Restart(string id)
        {
            return new ApiResult() { Code = 200, Msg = id, Data = null };
        }
    }
}