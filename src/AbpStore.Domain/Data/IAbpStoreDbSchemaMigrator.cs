using System.Threading.Tasks;

namespace AbpStore.Data;

public interface IAbpStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
