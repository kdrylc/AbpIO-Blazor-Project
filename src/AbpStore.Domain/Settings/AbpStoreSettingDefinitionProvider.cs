using Volo.Abp.Settings;

namespace AbpStore.Settings;

public class AbpStoreSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpStoreSettings.MySetting1));
    }
}
