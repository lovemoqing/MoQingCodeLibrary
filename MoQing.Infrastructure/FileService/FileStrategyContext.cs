using MoQing.Domain;
using Qiniu.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.FileService
{
    /// <summary>
    /// 文件策略上下文
    /// </summary>
    public class FileStrategyContext
    {
        AbstractFileStrategy fileStrategy = null;
        public FileStrategyContext(AbstractFileStrategy fileStrategy)
        {
            this.fileStrategy = fileStrategy;
        }

        public ApiResult Upload(string bucket, string saveKey, byte[] data)
        {
            return fileStrategy.Upload(bucket, saveKey,data);
        }
        public ApiResult DownLoad(string onlineUrl, string savaPath)
        {
            return fileStrategy.DownLoad(onlineUrl, savaPath);
        }
    }
}
