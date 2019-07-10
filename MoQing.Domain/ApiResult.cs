using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Domain
{
    /// <summary>
    /// API统一返回模型
    /// </summary>
    public class ApiResult
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
