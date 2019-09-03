using MoQing.Domain;
using MoQing.Domain.IRepositories;
using MoQing.Infrastructure;
using MoQing.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Application
{
    public class RedirectService : IRedirectService
    {
        private ISqlBaseRepository<Redirect> repository;
        public RedirectService(ISqlBaseRepository<Redirect> repository)
        {
            this.repository = repository;
        }
        public async Task<List<RedirectInfo>> Infos()
        {
            var res = await repository.GetAllListAsync(p => p.IsDelete == 0);
            return res.MapTo<RedirectInfo>();
        }
    }
}
