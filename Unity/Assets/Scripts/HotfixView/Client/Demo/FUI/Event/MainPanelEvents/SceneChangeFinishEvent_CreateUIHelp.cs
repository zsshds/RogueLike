namespace ET.Client
{
    [Event(SceneType.Current)]
    public class SceneChangeFinishEvent_CreateUIHelp : AEvent<Scene, SceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, SceneChangeFinish args)
        {
            scene.Root().GetComponent<FUIComponent>().HidePanel<SelectServerPanel>();
            await scene.Root().GetComponent<FUIComponent>().ShowPanelAsync<MainPanel>();
            await ETTask.CompletedTask;
        }
    }
}
