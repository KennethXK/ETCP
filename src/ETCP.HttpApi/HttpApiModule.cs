using ETCP.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ETCP.HttpApi
{

    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(ApplicationModule)
        )]
    public class HttpApiModule : AbpModule
    {

    }
}
