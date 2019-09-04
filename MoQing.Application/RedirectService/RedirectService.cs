using MoQing.Domain;
using MoQing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Application
{
    public class RedirectService : IRedirectService
    {
        private IRedirectRepository<Redirect> repository;
        public RedirectService(IRedirectRepository<Redirect> repository)
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
