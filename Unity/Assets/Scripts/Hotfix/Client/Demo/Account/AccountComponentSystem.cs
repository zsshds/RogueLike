namespace ET.Client
{
    [EntitySystemOf(typeof(AccountComponent))]
    [FriendOfAttribute(typeof(ET.Client.AccountComponent))]
    public static partial class AccountComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.AccountComponent self)
        {

        }

        public static void SetLoginMapInfo(this AccountComponent self, string Token, string Account)
        {
            self.Token = Token;
            self.Account = Account;
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.AccountComponent self)
        {
            
        }
    }
}

