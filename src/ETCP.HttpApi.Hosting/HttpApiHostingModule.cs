using Abp.AspNetCore.Mvc.ExceptionHandling;
using ETCP.EntityFrameworkCore;
using ETCP.HttpApi.Hosting.Filters;
using ETCP.HttpApi.Hosting.Middleware;
using ETCP.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ETCP.HttpApi.Hosting
{
    [DependsOn(
     typeof(AbpAspNetCoreMvcModule),
     typeof(AbpAutofacModule),
     typeof(HttpApiModule),
     typeof(SwaggerModule),
     typeof(EntityFrameworkCoreModule)
  )]
    public class HttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自己实现的 ExceptionFilter
                options.Filters.Add(typeof(ExceptionFilter));
            });

            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });

            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();

            base.ConfigureServices(context);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            // 路由
            app.UseRouting();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
