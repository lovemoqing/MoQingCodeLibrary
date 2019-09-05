using MoQing.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Application
{
    public interface IRedirectService
    {
        //Task<List<RedirectInfo>> Info();
        Task<List<RedirectInfo>> Infos();
    }
}
