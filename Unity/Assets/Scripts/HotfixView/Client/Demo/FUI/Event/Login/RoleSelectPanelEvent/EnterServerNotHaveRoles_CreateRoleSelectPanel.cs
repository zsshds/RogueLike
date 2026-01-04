namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class EnterServerNotHaveRoles_CreateRoleSelectPanel : AEvent<Scene, EnterServerNotHaveRoles>
    {
        protected override async ETTask Run(Scene scene, EnterServerNotHaveRoles a)
        {
            scene.Root().GetComponent<FUIComponent>().HidePanel<SelectServerPanel>();
            await scene.Root().GetComponent<FUIComponent>().ShowPanelAsync<RoleSelectPanel>();
        }
    }

}
