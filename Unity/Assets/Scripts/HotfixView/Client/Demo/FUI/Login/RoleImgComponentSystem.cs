namespace ET.Client
{
    [EntitySystemOf(typeof(RoleImgComponent))]
    [FriendOf(typeof(RoleImgComponent))]
    public static partial class RoleImgComponentSystem
    {
        private static void InitWithNoRole(this RoleImgComponent self)
        {
            
        }
    }
}