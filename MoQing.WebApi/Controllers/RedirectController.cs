using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoQing.Application;
using MoQing.Application.FileService;
using MoQing.Domain;

namespace MoQing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class RedirectController : ControllerBase
    {
        private IRedirectService redirectService;
        private IFileService fileService;
        public RedirectController(IRedirectService redirectService,IFileService fileService)
        {
            this.redirectService = redirectService;
            this.fileService = fileService;
        }
        [HttpGet, Route("Infos")]
        public async Task<ActionResult<ApiResult>> Auth()
        {
            var res = await redirectService.Infos();
            return new ApiResult() { Code = 200, Msg = string.Empty, Data = res };
        }

        [HttpGet, Route("FileName")]
        public ActionResult<ApiResult> FileName()
        { 
            return new ApiResult() { Code = 200, Msg = string.Empty, Data = fileService.GetName() };
        }
    }
}