using AbpStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpStore.Permissions;

public class AbpStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var categoryGroup = context.AddGroup(AbpStorePermissions.GroupName, L("Permission:Category"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        var categoryPermission = categoryGroup.AddPermission(AbpStorePermissions.Category.Default, L("Permission:Category"));
        var categoryPermission1 = categoryGroup.AddPermission(AbpStorePermissions.Category.Create, L("Permission:CategoryCreate"));
        var categoryPermission2 = categoryGroup.AddPermission(AbpStorePermissions.Category.Delete, L("Permission:CategoryDelete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpStoreResource>(name);
    }
}
