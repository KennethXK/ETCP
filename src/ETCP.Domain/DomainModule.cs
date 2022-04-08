using ETCP.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ETCP.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule),
        typeof(DomainSharedModule))]
    public class DomainModule : AbpModule
    {
    }
}
