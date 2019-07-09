using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.FileService
{
    /// <summary>
    /// 七牛云OSS文件操作策略基类，具体的实现
    /// </summary>
    public class QiniuStrategy : AbstractFileStrategy
    {
        public override void Upload()
        {
            throw new NotImplementedException();
        }
    }
}
