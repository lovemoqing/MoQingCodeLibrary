using Autofac;
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
            //程序集注入
            var IService = Assembly.Load("MoQing.Application");
            var Service = Assembly.Load("MoQing.Application");

            //根据名称约定（服务层的接口和实现均以AppService结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IService, Service)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
