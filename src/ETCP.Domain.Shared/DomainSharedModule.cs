using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ETCP.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class DomainSharedModule : AbpModule
    {

    }
}
