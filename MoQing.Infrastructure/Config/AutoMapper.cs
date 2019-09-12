
using AutoMapper;
using MoQing.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.Config
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<FileInfoDto, FileInfo>();
            CreateMap<RedirectInfo, Redirect>();
            CreateMap<Redirect,RedirectInfo>();

            CreateMap<RedirectCreate, Redirect>();
            CreateMap<Redirect, RedirectCreate>();
        }
    }
}
