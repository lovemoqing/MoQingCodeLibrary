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

        public void Upload()
        {
            fileStrategy.Upload();
        }
    }
}
