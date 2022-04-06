using System;
using System.Threading.Tasks;
using ETCP.HttpApi.Hosting;
using ETCP.ToolKits.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseLog4Net();
            await builder.AddApplicationAsync<HttpApiHostingModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            return 1;
        }
        finally
        {
        }
    }
}