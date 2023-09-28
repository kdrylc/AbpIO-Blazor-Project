using AbpStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpStore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpStoreController : AbpControllerBase
{
    protected AbpStoreController()
    {
        LocalizationResource = typeof(AbpStoreResource);
    }
}
