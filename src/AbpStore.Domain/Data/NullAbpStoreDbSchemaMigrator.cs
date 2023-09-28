using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpStore.Data;

/* This is used if database provider does't define
 * IAbpStoreDbSchemaMigrator implementation.
 */
public class NullAbpStoreDbSchemaMigrator : IAbpStoreDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
