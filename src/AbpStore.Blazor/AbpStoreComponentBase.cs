using AbpStore.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpStore.Blazor;

public abstract class AbpStoreComponentBase : AbpComponentBase
{
    protected AbpStoreComponentBase()
    {
        LocalizationResource = typeof(AbpStoreResource);
    }
}
