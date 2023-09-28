using System;
using System.Collections.Generic;
using System.Text;
using AbpStore.Localization;
using Volo.Abp.Application.Services;

namespace AbpStore;

/* Inherit your application services from this class.
 */
public abstract class AbpStoreAppService : ApplicationService
{
    protected AbpStoreAppService()
    {
        LocalizationResource = typeof(AbpStoreResource);
    }
}
