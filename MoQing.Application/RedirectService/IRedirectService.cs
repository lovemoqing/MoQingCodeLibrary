﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoQing.Application
{
    public interface IRedirectService
    {
        Task<List<RedirectInfo>> Infos();
    }
}