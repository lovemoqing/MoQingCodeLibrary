using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Domain
{
    public class BaseKey : ModelContext, IEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; }
    }
}
