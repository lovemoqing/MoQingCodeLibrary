using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoQing.Application;
using MoQing.Domain;
using MoQing.Infrastructure.Config;
using MoQing.WebApi.Config;
using Swashbuckle.AspNetCore.Swagger;
namespace MoQing.WebApi
{
    public class Startup
    {
        
        public static IContainer AutofacContainer;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) //默认
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //注册服务进 IServiceCollection
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            //配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy("any", build =>
                {
                    build.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            }); 
            //添加对AutoMapper的支持
            services.AddAutoMapper();
            ContainerBuilder builder = new ContainerBuilder();
            //新模块组件注册
            builder.RegisterModule<DefaultModuleRegister>();
            //属性注入控制器 
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //将services中的服务填充到Autofac中.
            builder.Populate(services);

            //创建容器.
            AutofacContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(AutofacContainer);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //var rewrite = new RewriteOptions();
            //RewriteOptionsHandler rewriteOptionsHandler = new RewriteOptionsHandler();
            //rewrite = rewriteOptionsHandler.GetRewriteOptions();
            //app.UseRewriter(rewrite);



            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //程序停止调用函数
            appLifetime.ApplicationStopped.Register(() => { AutofacContainer.Dispose(); });
        }
    }
}
