namespace AbpStore.Permissions;

public static class AbpStorePermissions
{
    public const string GroupName = "AbpStore";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Category
    {
        public const string Default = GroupName + ".Category";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
