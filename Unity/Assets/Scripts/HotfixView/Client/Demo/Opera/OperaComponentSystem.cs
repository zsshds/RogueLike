using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
            Log.Error($"OperaComponent 所属 Scene为{self.Scene().Name}");
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
                {
                    C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
                    c2MPathfindingResult.Position = hit.point;
                    self.Root().GetComponent<ClientSenderComponent>().Send(c2MPathfindingResult);
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                self.Test1().Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                self.Test2().Coroutine();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CodeLoader.Instance.Reload();
                return;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                C2M_TransferMap c2MTransferMap = C2M_TransferMap.Create();
                self.Root().GetComponent<ClientSenderComponent>().Call(c2MTransferMap).Coroutine();
            }
        }
        
        [EntitySystem]
        private static void LateUpdate(this ET.Client.OperaComponent self)
        {
            //每帧把当前帧收集的操作发送给服务端，随后清除
            // if (self.OperateInfos.Count == 0)
            //     return;
            // self.OperateInfosTemp.Clear();
            // self.OperateInfosTemp.AddRange(self.OperateInfos);
            // C2Room_Operation c2RoomOperation = C2Room_Operation.Create();
            // c2RoomOperation.OperateInfos = self.OperateInfosTemp;
            // self.Root().GetComponent<ClientSenderComponent>().Send(c2RoomOperation);
            // self.OperateInfos.Clear();  
        }

        private static async ETTask Test1(this OperaComponent self)
        {
            Log.Debug($"Croutine 1 start1 ");
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(1, 20000, 3000))
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(6000);
            }

            Log.Debug($"Croutine 1 end1");
        }

        private static async ETTask Test2(this OperaComponent self)
        {
            Log.Debug($"Croutine 2 start2");
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(1, 20000, 3000))
            {
                await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            }
            Log.Debug($"Croutine 2 end2");
        }

        
        public static void OnMove(this OperaComponent self, Vector2 v2)
        {
            Log.Info($"press joystick: {v2}");
            // C2M_JoystickMove c2mJoystickMove = new C2M_JoystickMove() { MoveForward = new float3(v2.x, 0, v2.y) };
            // self.ClientScene().GetComponent<PlayerSessionComponent>().Session.Send(c2mJoystickMove);
            OperateInfo operateInfo = OperateInfo.Create();
            operateInfo.OperateType = (int)EOperateType.Move;
            operateInfo.InputType = (int)EInputType.KeyDown;
            operateInfo.Vec3 = new float3(v2.x, 0, v2.y);
            if (self.OperateInfos != null)
            {
                self.OperateInfos.Add(operateInfo);
            }
            else
            {
                Log.Error($"OperateInfos is null");
            }
            
        }
        
        public static void StopMove(this OperaComponent self)
        {
            //这里由于使用到了摇杆的原因，需要帧同步，定义一个OP消息给后端
            OperateInfo operateInfo = OperateInfo.Create();
            operateInfo.OperateType = (int)EOperateType.Move;
            operateInfo.InputType = (int)EInputType.KeyUp;
            self.OperateInfos.Add(operateInfo);
            if (self.OperateInfos != null)
            {
                self.OperateInfos.Add(operateInfo);
            }
            else
            {
                Log.Error($"OperateInfos is null");
            }
        }
        
    }
}