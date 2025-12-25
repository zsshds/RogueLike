namespace ET.Client
{
	[Event(SceneType.Demo)]
	public class LoginFinish_CreateLobbyUI: AEvent<Scene, LoginAndGetServerInfoFinish>
	{
		protected override async ETTask Run(Scene scene, LoginAndGetServerInfoFinish args)
		{
			await scene.Root().GetComponent<FUIComponent>().ShowPanelAsync<SelectServerPanel>();
		}
	}
}
