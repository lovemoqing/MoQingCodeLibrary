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
        public abstract void Upload();
    }
}
