using AbpStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpStoreEntityFrameworkCoreModule),
    typeof(AbpStoreApplicationContractsModule)
    )]
public class AbpStoreDbMigratorModule : AbpModule
{
}
