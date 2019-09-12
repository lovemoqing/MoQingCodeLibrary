using MoQing.Infrastructure.Config;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure
{
    public class RedisHelper
    {
        private ConnectionMultiplexer redis { get; set; }
        private IDatabase db { get; set; }
        public RedisHelper()
        {

            var config = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                AllowAdmin = true,
                ConnectTimeout = 15000,
                SyncTimeout = 5000,
                //Password = "Pwd",//Redis数据库密码
                EndPoints = { ConfigExtensions.Configuration["Redis:config0"] }// connectionString 为IP:Port 如”192.168.2.110:6379”
            };
            redis = ConnectionMultiplexer.Connect(config);
            db = redis.GetDatabase();
        }

        /// <summary>
        /// 增加/修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string key, string value)
        {
            return db.StringSet(key, value);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return db.StringGet(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DeleteKey(string key)
        {
            return db.KeyDelete(key);
        }
    }
}
