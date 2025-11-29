using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.RoomRoot)]
    public class C2Room_OperationHandler : MessageHandler<Scene, C2Room_Operation>
    {
        protected override async ETTask Run(Scene root, C2Room_Operation message)
        {
            if (message.OperateInfos == null || message.OperateInfos.Count == 0)
            {
                Log.Error($"reveice null operate info");
                return;
            }
            StateSyncRoom room = root.GetComponent<StateSyncRoom>();
            StateSyncRoomServerComponent roomServerComponent = room.GetComponent<StateSyncRoomServerComponent>();
            StateSyncRoomPlayer roomPlayer = roomServerComponent.GetChild<StateSyncRoomPlayer>(message.PlayerId);

            Log.Info($"rev C2Room_Operation");
            Room2C_Operation room2COperation = Room2C_Operation.Create();
            room2COperation.OperateInfos = new List<OperateReplyInfo>();
            
            Unit unit = roomPlayer.Unit;
            if (unit == null)
            {
                Log.Error($"cant not find unit, player id : {message.PlayerId}");
                return;
            }
            foreach (OperateInfo operateInfo in message.OperateInfos)
            {
                EOperateType operateType = (EOperateType)operateInfo.OperateType;
                switch (operateType)
                {
                    case EOperateType.Move:
                    {
                        if ((EInputType)operateInfo.InputType == EInputType.KeyUp)
                        {
                            unit.GetComponent<PlayerMoveComponent>().StopMove();
                        }
                        else
                        {
                            unit.Forward = operateInfo.Vec3;
                            unit.GetComponent<PlayerMoveComponent>().StartMove();
                        }
                        break;
                    }
                    default:
                    {
                        Log.Error($"unknow operate type: {operateType}");
                        break;
                    }
                }
            }
            if(room2COperation.OperateInfos?.Count > 0)
                MapMessageHelper.SendToClient(unit, room2COperation);

            await ETTask.CompletedTask;
        }
    }
    
}