using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace MoQing.Infrastructure
{
    /// <summary>
    /// AutoMapper扩展方法
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 集合对集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TResult> MapTo<TResult>(this IEnumerable self)
        {
            if (self == null)
                return default(List<TResult>);
            return (List<TResult>)Mapper.Map(self, self.GetType(), typeof(List<TResult>));
        }

        /// <summary>
        /// 对象对对象
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                return default(TResult);
            return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
        }
    }
}
