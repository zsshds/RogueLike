namespace ET.Client
{
    [EntitySystemOf(typeof(LoginPanel))]
    [FriendOf(typeof(LoginPanel))]
    public static partial class LoginPanelSystem
    {
        [EntitySystem]
        private static void Awake(this LoginPanel self)
        {
            self.FUILoginPanel.Btn_Login.onClick.Add(self.OnLoginClick);
            self.FUILoginPanel.TxtIn_Account.onFocusIn.Add(() =>
            {
                if (self.FUILoginPanel.TxtIn_Account.text.Equals("用户名："))
                {
                    self.FUILoginPanel.TxtIn_Account.text = "";
                }
                
            });
            self.FUILoginPanel.TxtIn_Pasword.onFocusIn.Add(() =>
            {
                //设置为密码
                self.FUILoginPanel.TxtIn_Pasword.displayAsPassword = true;
                if (self.FUILoginPanel.TxtIn_Pasword.text.Equals("密码："))
                {
                    self.FUILoginPanel.TxtIn_Pasword.text = "";
                }
            });
            self.FUILoginPanel.TxtIn_Account.onFocusOut.Add(() =>
            {
                if (self.FUILoginPanel.TxtIn_Account.text.Equals(""))
                {
                    self.FUILoginPanel.TxtIn_Account.text = "用户名：";
                }
            });
            self.FUILoginPanel.TxtIn_Pasword.onFocusOut.Add(() =>
            {
                if (self.FUILoginPanel.TxtIn_Pasword.text.Equals(""))
                {
                    //设置为明文
                    self.FUILoginPanel.TxtIn_Pasword.displayAsPassword = false;
                    self.FUILoginPanel.TxtIn_Pasword.text = "密码：";
                }
            });
        }

        [EntitySystem]
        private static void Show(this LoginPanel self)
        {
        }
        
        private static void OnLoginClick(this LoginPanel self)
        {
            LoginHelper.LoginAndGetServerInfo(self.Root(), 
                self.FUILoginPanel.TxtIn_Account.text, 
                self.FUILoginPanel.TxtIn_Pasword.text).Coroutine();
        }
    }
}