using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    /// <summary>
    /// 分页返回Dto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResultDto<T>
    {
        public List<T> items { get; set; }
        public int total_count { get; set; }
        
    }
}
