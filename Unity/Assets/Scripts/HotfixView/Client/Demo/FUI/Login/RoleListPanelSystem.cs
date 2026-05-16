namespace ET.Client
{
    [EntitySystemOf(typeof(RoleListPanel))]
    [FriendOf(typeof(RoleListPanel))]
    public static partial class RoleListPanelSystem
    {
        [EntitySystem]
        private static void Awake(this RoleListPanel self)
        {
        }

        [EntitySystem]
        private static void Show(this RoleListPanel self)
        {
        }
    }
}