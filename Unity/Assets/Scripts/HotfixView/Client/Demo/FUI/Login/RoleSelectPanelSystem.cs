namespace ET.Client
{
    [EntitySystemOf(typeof(RoleSelectPanel))]
    [FriendOf(typeof(RoleSelectPanel))]
    public static partial class RoleSelectPanelSystem
    {
        [EntitySystem]
        private static void Awake(this RoleSelectPanel self)
        {
            HeroConfig.Get()
        }

        [EntitySystem]
        private static void Show(this RoleSelectPanel self)
        {
        }
    }
}