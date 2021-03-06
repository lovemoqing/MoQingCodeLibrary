﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public RedirectService(IRedirectRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }
        public async Task<List<RedirectInfo>> InfosAsync()
        {
            var res = await repository.GetAllListAsync(p => p.IsDelete == 0);
            return _mapper.Map<List<RedirectInfo>>(res);
        }
        public List<RedirectInfo> Infos()
        {
            var res = repository.GetAllList(p => p.IsDelete == 0);
            return _mapper.Map<List<RedirectInfo>>(res);
        }
        public async Task<RedirectInfo> AddInfosAsync(RedirectCreate req)
        {
            var info = _mapper.Map<Redirect>(req);
            var res = await repository.InsertAsync(info);
            return _mapper.Map<RedirectInfo>(res);
        }
        public async Task<int> Del(int id)
        {
            return await repository.DeleteAsync(id.ToString());
        }
    }
}
