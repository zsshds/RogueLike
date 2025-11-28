namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class Match2G_StateSyncNotifyMatchSuccessHandler : MessageHandler<Scene, Match2G_StateSyncNotifyMatchSuccess>
    {
        protected override async ETTask Run(Scene root, Match2G_StateSyncNotifyMatchSuccess message)
        {
            await SceneChangerStageSyncHelper.SceneChangeTo(root, "HomeScene", message.ActorId.InstanceId);
        }
    }
}
