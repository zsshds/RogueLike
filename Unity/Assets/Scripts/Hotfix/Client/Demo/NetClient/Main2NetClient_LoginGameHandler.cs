using System;

namespace ET.Client
{
    [MessageHandler(SceneType.NetClient)]
    public class Main2NetClient_LoginGameHandler : MessageHandler<Scene, Main2NetClient_LoginGame, NetClient2Main_LoginGame>
    {
        protected override async ETTask Run(Scene scene, Main2NetClient_LoginGame request, NetClient2Main_LoginGame response)
        {
            string account = request.Account;
            //销毁原先用于连接realm的session
            if (scene.GetComponent<SessionComponent>().Session != null)
            {
                scene.GetComponent<SessionComponent>().Session.Dispose();
            }
            //创建一个gate session 并保存到sessionComponent中
            NetComponent netComponent = scene.GetComponent<NetComponent>();
            Session gateSession = await netComponent.CreateRouterSession(NetworkHelper.ToIPEndPoint(request.GateAddress), account, account);
            gateSession.AddComponent<ClientSessionErrorComponent>();
            scene.GetComponent<SessionComponent>().Session = gateSession;
            C2G_LoginGameGate c2GLoginGameGate = C2G_LoginGameGate.Create();
            c2GLoginGameGate.Key = request.RealmKey;
            c2GLoginGameGate.Account = account;
            c2GLoginGameGate.RoleId = request.RoleId;
            G2C_LoginGameGate g2CLoginGameGate = await gateSession.Call(c2GLoginGameGate) as G2C_LoginGameGate;
            if (g2CLoginGameGate.Error != ErrorCode.ERR_Success)
            {
                response.Error = g2CLoginGameGate.Error;
                Log.Error($"{request.RoleId}登录Gate失败");
                return;
            }
            Log.Info($"{request.RoleId} 登录Gate成功");
            
            //这里由于帧同步需要去room的原因，做一些更改
            // G2C_EnterGame g2CEnterGame = await gateSession.Call(C2G_EnterGame.Create()) as G2C_EnterGame;
            // if (g2CLoginGameGate.Error != ErrorCode.ERR_Success)
            // { 
            //     response.Error = g2CEnterGame.Error;
            //     Log.Error($"{request.RoleId} 登录Map失败");
            //     return;
            // }
            // Log.Info($"{request.RoleId} 登录Map成功");
            try
            {
                G2C_StateSyncMatch g2CEnterMap = await gateSession.Call(C2G_StateSyncMatch.Create()) as G2C_StateSyncMatch;
                response.PlayerId = g2CEnterMap.UnitId;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}

