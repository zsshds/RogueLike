using MongoDB.Driver.Core.Events;

namespace ET
{
    public enum RoleIndoState
    {
        Normal = 0,
        Freeze = 100,
        Delete = 999,
    }
    
    [FriendOfAttribute(typeof(ET.RoleInfo))]
    public static partial class RoleInfoSystem
    {
        public static void SetAttu(this RoleInfo self, RoleInfoProto roleInfoProto)
        {
            self.Name = roleInfoProto.Name;
            self.ServerId = roleInfoProto.ServerId;
            self.State = roleInfoProto.State;
            self.Account = roleInfoProto.Account;
            self.lastLoginTime = roleInfoProto.LastLoginTime;
            self.CreateTime = roleInfoProto.CreateTime;
            self.HeroId = roleInfoProto.HeroId;
        }
    }

    [ChildOf]
    public class RoleInfo : Entity, IAwake
    {
        public string Name;
        public int ServerId;
        public int State;
        public string Account;
        public long lastLoginTime;
        public long CreateTime;
        public int HeroId;
    }
}
