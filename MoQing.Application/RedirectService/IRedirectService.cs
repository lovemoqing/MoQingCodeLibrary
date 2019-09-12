using MoQing.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Application
{
    public interface IRedirectService
    {
        //Task<List<Redi1rectInfo>> Info();
        Task<List<RedirectInfo>> InfosAsync();
        List<RedirectInfo> Infos();

        Task<RedirectInfo> AddInfosAsync(RedirectCreate req);
        Task<int> Del(int id);
    }
}
