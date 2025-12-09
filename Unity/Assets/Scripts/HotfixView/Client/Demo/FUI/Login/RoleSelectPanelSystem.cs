namespace ET.Client
{

    [Event(SceneType.Demo)]
    public class RoleSelectPanel_OnClickNextRole : AEvent<Scene, OnClickNextRole>
    {
        protected override async ETTask Run(Scene scene, OnClickNextRole a)
        {
            RoleSelectPanel panel = scene.Root().GetComponent<FUIComponent>().GetPanelLogic<RoleSelectPanel>();
            panel.OnClickNextRole();
            await ETTask.CompletedTask;
        }
    }
    
    [Event(SceneType.Demo)]
    public class RoleSelectPanel_OnClickPreRole : AEvent<Scene, OnClickPreRole>
    {
        protected override async ETTask Run(Scene scene, OnClickPreRole a)
        {
            RoleSelectPanel panel = scene.Root().GetComponent<FUIComponent>().GetPanelLogic<RoleSelectPanel>();
            panel.OnClickPreRole();
            await ETTask.CompletedTask;
        }
    }
    
    [EntitySystemOf(typeof(RoleSelectPanel))]
    [FriendOf(typeof(RoleSelectPanel))]
    public static partial class RoleSelectPanelSystem
    {
        [EntitySystem]
        private static void Awake(this RoleSelectPanel self)
        {
            self.HeroConfigs = HeroConfigCategory.Instance.GetAllHeroConfig();
            self.SelectIndex = 0;
        }

        [EntitySystem]
        private static void Show(this RoleSelectPanel self)
        {
            self.FUIRoleSelectPanel.RoleImgComponent.Init(self.HeroConfigs[self.SelectIndex], self.Scene());
        }
        
        public static void OnClickNextRole(this RoleSelectPanel self)
        {
            self.SelectIndex++;
            if (self.SelectIndex >= self.HeroConfigs.Count)
            {
                self.SelectIndex = 0;
            }
            self.FUIRoleSelectPanel.RoleImgComponent.Init(self.HeroConfigs[self.SelectIndex], self.Scene());
        }
        public static void OnClickPreRole(this RoleSelectPanel self)
        {
            self.SelectIndex--;
            if (self.SelectIndex < 0)
            {
                self.SelectIndex = self.HeroConfigs.Count - 1;
            }
            self.FUIRoleSelectPanel.RoleImgComponent.Init(self.HeroConfigs[self.SelectIndex], self.Scene());
        }
    }
}