using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpStore.Blazor;

[Dependency(ReplaceServices = true)]
public class AbpStoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpStore";
}
