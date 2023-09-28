using Volo.Abp.Modularity;

namespace AbpStore;

[DependsOn(
    typeof(AbpStoreApplicationModule),
    typeof(AbpStoreDomainTestModule)
    )]
public class AbpStoreApplicationTestModule : AbpModule
{

}
