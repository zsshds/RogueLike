namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class M2C_CreateUnitsHandler: MessageHandler<Scene, M2C_CreateUnits>
	{
		protected override async ETTask Run(Scene root, M2C_CreateUnits message)
		{
			Scene currentScene = root.CurrentScene();
			UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
			//这里我只想显示一个玩家所以，遍历所有Unit只有PlayerID相等才走创建
			//也就是说，实际上一个服的所有玩家都在一个Scene内，没有必要对工厂做限制，在外部限制即可
			long myID = root.GetComponent<PlayerComponent>().MyId;
			foreach (UnitInfo unitInfo in message.Units)
			{
				if (unitComponent.Get(unitInfo.UnitId) != null)
				{
					continue;
				}

				if (unitInfo.UnitId == myID)
				{
					Unit unit = UnitFactory.Create(currentScene, unitInfo);
				}
			}
			await ETTask.CompletedTask;
		}
	}
}
