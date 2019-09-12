using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoQing.Application;
using MoQing.Domain;

namespace MoQing.WebApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IRedirectService redirectService;
        public HomeController(IRedirectService _redirectService)
        {
            redirectService = _redirectService;
        }
        public string Index()
        {
            return "欢迎访问默卿的API服务！";
        }
        [HttpGet, Route("/{shortLinks}")]
        public ActionResult Restart(string shortLinks)
        {
            string url = "https://www.cnblogs.com/sunshine-wy/";
            List<RedirectInfo> res = redirectService.Infos();
            if (res != null && res.Count > 0)
            {
                var info = res.SingleOrDefault(p => p.ShortLinks == shortLinks);
                if (info != null)
                {
                    url = info.LongLinks;
                }
            }
            return Redirect(url);
        }
    }
}