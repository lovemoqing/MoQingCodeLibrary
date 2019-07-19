using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoQing.Application.FileService;
using MoQing.Domain;
using MoQing.Infrastructure.Common;
using MoQing.Infrastructure.Config;
using MoQing.Infrastructure.FileService;
using Qiniu.Http;
using Qiniu.IO.Model;
using Qiniu.Util;

namespace MoQing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IFileService _fileService;
        private readonly IMapper _mapper;
        public ValuesController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<string> Post(FileInfoDto model)
        {
            var AK = ConfigExtensions.Configuration["Qiniu:AK"];
            var user = _mapper.Map<FileInfo>(model); //映射
            return _fileService.GetName() + "|" + user.Name + "|" + AK;
        }

        /// <summary>
        /// 下载文件到本地
        /// </summary>
        /// <param name="onlineUrl">浏览器访问地址 http://qiniu.lovemoqing.com/微信图片_20190409172929.jpg </param>
        /// <param name="savaPath">本地路径+文件名+文件后缀名 D:\penglong\test\saved-snow.jpg</param>
        /// <returns></returns>
        [HttpGet, Route("DownLoad")]
        public ActionResult<ApiResult> DownLoad(string onlineUrl, string savaPath)
        {
            FileStrategyContext context = new FileStrategyContext(new FileFactory().Create(Tools.GetDefaultFileMode()));
            return context.DownLoad(onlineUrl, savaPath);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="savaKey"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet, Route("UpLoad")]
        public ActionResult<ApiResult> UpLoad(string bucket, string savaKey, byte[] data)
        {
            FileStrategyContext context = new FileStrategyContext(new FileFactory().Create(Tools.GetDefaultFileMode()));
            return context.Upload(bucket, savaKey, data);
        }
         
        [HttpGet, Route("Auth")]
        public ActionResult<ApiResult> Auth()
        {
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.Scope = ConfigExtensions.Configuration["Qiniu:Backet"];
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 生成上传凭证，参见
            // https://developer.qiniu.com/kodo/manual/upload-token            
            string jstr = putPolicy.ToJsonString();
            Mac mac = new Mac(ConfigExtensions.Configuration["Qiniu:AK"], ConfigExtensions.Configuration["Qiniu:SK"]);
            string token = QiniuAuthSDK.CreateUploadToken(mac, jstr);
            return new ApiResult() { Code = 200, Msg = string.Empty, Data = token };
        }
    }
}
