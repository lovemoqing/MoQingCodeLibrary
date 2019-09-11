using Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using MoQing.Application;
using MoQing.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoQing.WebApi.Config
{
    public class RewriteOptionsHandler
    {
        SqlSugarClient db = ConnectionFactory.CreateSqlSugarClient();
        public RewriteOptionsHandler() {
        }
        public RewriteOptions GetRewriteOptions()
        { 
            RewriteOptions rewrite = new RewriteOptions();
            List<Redirect> res = db.Queryable<Redirect>().ToList();
            if (res != null && res.Count > 0)
            {
                foreach (var item in res)
                {
                    rewrite.AddRedirect(item.ShortLinks, item.LongLinks);
                }
            }
            return rewrite;
        }
    }
}
