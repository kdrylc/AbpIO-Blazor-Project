using AbpStore.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpStore;

[DependsOn(
    typeof(AbpStoreEntityFrameworkCoreTestModule)
    )]
public class AbpStoreDomainTestModule : AbpModule
{

}
