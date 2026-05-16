namespace ET.Client
{
	[Event(SceneType.Demo)]
	public class LoginAndGetServerInfoFinish_RemoveLoginUI: AEvent<Scene, LoginAndGetServerInfoFinish>
	{
		protected override async ETTask Run(Scene scene, LoginAndGetServerInfoFinish args)
		{
			scene.GetComponent<FUIComponent>().HidePanel<LoginPanel>();
			await ETTask.CompletedTask;
		}
	}
}
