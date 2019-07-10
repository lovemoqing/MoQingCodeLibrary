using MoQing.Infrastructure.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.Common
{
    /// <summary>
    /// 通用工具列表
    /// </summary>
    public class Tools
    {
        public static string GetDefaultFileMode()
        {
            return ConfigExtensions.Configuration["DefaultFileMode"];
        }
    }
}
