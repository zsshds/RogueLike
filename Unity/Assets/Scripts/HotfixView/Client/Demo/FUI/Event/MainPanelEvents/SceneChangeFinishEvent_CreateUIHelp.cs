namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            FUIComponent FUIComponent = scene.Root().GetComponent<FUIComponent>();
            if (FUIComponent.IsPanelVisible(PanelId.RoleSelectPanel))
            {
                scene.Root().GetComponent<FUIComponent>().HidePanel<RoleSelectPanel>();
            }

            if(FUIComponent.IsPanelVisible(PanelId.RoleListPanel))
            {
                scene.Root().GetComponent<FUIComponent>().HidePanel<RoleListPanel>();
            }
            await scene.Root().GetComponent<FUIComponent>().ShowPanelAsync<MainPanel>();
            await ETTask.CompletedTask;
        }
    }
}
