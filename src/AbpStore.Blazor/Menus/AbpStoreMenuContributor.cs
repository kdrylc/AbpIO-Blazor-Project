using System.Threading.Tasks;
using AbpStore.Localization;
using AbpStore.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace AbpStore.Blazor.Menus;

public class AbpStoreMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AbpStoreResource>();

        context.Menu.Items.Insert(
             0,
             new ApplicationMenuItem(
                 AbpStoreMenus.Home,
                 l["Menu:Home"],
                 "/",
                 icon: "fas fa-home",
                 order: 0
             )

         );
        
        context.Menu.AddItem(new ApplicationMenuItem(
                          name: "Category",
                          displayName: l["Category"],
                          url: "/category")
                     );

        context.Menu.AddItem(new ApplicationMenuItem(
                       name: "Product",
                       displayName: l["Product"],
                       url: "/product")
                  );


        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
