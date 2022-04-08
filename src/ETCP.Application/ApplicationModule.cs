using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ETCP.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
            typeof(AbpAutoMapperModule)
        )]
    public class ApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ApplicationModule>(validate: true);
                options.AddProfile<ApplicationAutoMapperProfile>(validate: true);
            });

        }
    }
}
