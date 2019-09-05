using Autofac;
using Autofac.Extensions.DependencyInjection;
using MoQing.Domain;
using MoQing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace MoQing.WebApi.Config
{
    public class DefaultModuleRegister: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //程序集注入数据仓储
            var IRepository = Assembly.Load("MoQing.Infrastructure");
            var Repository = Assembly.Load("MoQing.Infrastructure");

            //根据名称约定（仓储层的接口和实现均以Repository结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();

            //程序集注入业务服务
            var IAppServices = Assembly.Load("MoQing.Application");
            var AppServices = Assembly.Load("MoQing.Application");
            
            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IAppServices, AppServices)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();
        }

        //public static Assembly GetAssembly(string assemblyName)
        //{
        //    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
        //    return assembly;
        //}
    }
}
