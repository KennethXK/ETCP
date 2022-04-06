using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ETCP.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
            typeof(Volo.Abp.AutoMapper.AbpAutoMapperModule)
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
