using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.FileService
{
    public class FileFactory
    {
        AbstractFileStrategy _abstractFileStrategy;
        public AbstractFileStrategy Create(string type)
        {
            switch (type)
            {
                default:
                    _abstractFileStrategy = new QiniuStrategy();
                    break;
            }
            return _abstractFileStrategy;
        }
    }
}
