using System;
using System.Net;
using System.Net.Sockets;
using CommandLine;

namespace ET.Client
{
    //命名规范--消息名 + Handler 表示对这样一条网络消息进行处理，继承自MessageHandler基类，需要注意泛型
    [MessageHandler(SceneType.NetClient)] //使用MessageHandler特性，传入scene实体的类型
    public class Main2NetClient_LoginHandler: MessageHandler<Scene, Main2NetClient_Login, NetClient2Main_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_Login request, NetClient2Main_Login response)
        {
            string account = request.Account;
            string password = request.Password;
            // 创建一个ETModel层的Session
            root.RemoveComponent<RouterAddressComponent>();
            // 获取路由跟realmDispatcher地址
            RouterAddressComponent routerAddressComponent =
                    root.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
            await routerAddressComponent.Init();
            root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
            root.GetComponent<FiberParentComponent>().ParentFiberId = request.OwnerFiberId;

            NetComponent netComponent = root.GetComponent<NetComponent>();
            
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            C2R_LoginAccount c2RLoginAccount = C2R_LoginAccount.Create();
            //R2C_Login r2CLogin;
            R2C_LoginAccount r2CLoginAccount;
            Session session = await netComponent.CreateRouterSession(realmAddress, account, password);
            session.AddComponent<ClientSessionErrorComponent>();
            c2RLoginAccount.Account = account;
            c2RLoginAccount.Password = password;
            r2CLoginAccount = (R2C_LoginAccount)await session.Call(c2RLoginAccount);
            if (r2CLoginAccount.Error == ErrorCode.ERR_Success)
            {
                root.AddComponent<SessionComponent>().Session = session;
            }
            else
            {
                session?.Dispose();
            }
            response.ToKen = r2CLoginAccount.Token;
            response.Message = r2CLoginAccount.Message;
            response.Error = r2CLoginAccount.Error; ;
        }
    }
}