using MoQing.Domain;
using Qiniu.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.FileService
{
    /// <summary>
    /// 抽象文件策略，定义所有的文件上传、下载等行为
    /// </summary>
    public abstract class AbstractFileStrategy
    {
        public abstract ApiResult Upload(string bucket,string fileName, byte[] data);

        public abstract ApiResult DownLoad(string onlineUrl, string savaPath);
    }
}
