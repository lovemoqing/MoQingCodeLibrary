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
        private IRedirectRepository repository;
        public RedirectService(IRedirectRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Redirect>> Infos()
        {
            var res = await repository.GetAllListAsync(p => p.IsDelete == 0);
            return res;
        }
    }
}
