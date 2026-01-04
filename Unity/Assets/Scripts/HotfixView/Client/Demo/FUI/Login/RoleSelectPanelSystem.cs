using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(RoleSelectPanel))]
    [FriendOf(typeof(RoleSelectPanel))]
    [FriendOfAttribute(typeof(ET.Client.AccountComponent))]
    public static partial class RoleSelectPanelSystem
    {
        [EntitySystem]
        private static void Awake(this RoleSelectPanel self)
        {
            self.FUIRoleSelectPanel.Btn_NextRole.onClick.Add(() =>
            {
                self.OnClickNextRole();
            });
            self.FUIRoleSelectPanel.Btn_PreRole.onClick.Add(() =>
            {
                self.OnClickPreRole();
            });
            self.FUIRoleSelectPanel.Btn_CreateNewRole.onClick.Add(() =>
            {
                self.OnClickCreateRole().Coroutine();
            });
            self.HeroConfigs = new List<HeroConfig>(HeroConfigCategory.Instance.GetAll().Values);
            self.SelectIndex = 0;
        }

        [EntitySystem]
        private static void Show(this RoleSelectPanel self)
        {
            self.Refresh();
        }

        private static void Refresh(this RoleSelectPanel self)
        {
            self.FUIRoleSelectPanel.RoleImgComponent.Init(self.HeroConfigs[self.SelectIndex], self.Scene());
            self.FUIRoleSelectPanel.RoleInfoComponent.Init(self.HeroConfigs[self.SelectIndex]);
            self.FUIRoleSelectPanel.Txt_RoleNumber.text = $"当前{self.SelectIndex + 1}/{self.HeroConfigs.Count}";

        }

        //点击切换到下一个英雄
        public static void OnClickNextRole(this RoleSelectPanel self)
        {
            self.SelectIndex++;
            if (self.SelectIndex >= self.HeroConfigs.Count)
            {
                self.SelectIndex = 0;
            }
            self.Refresh();
        }

        //点击切换到上一个英雄
        public static void OnClickPreRole(this RoleSelectPanel self)
        {
            self.SelectIndex--;
            if (self.SelectIndex < 0)
            {
                self.SelectIndex = self.HeroConfigs.Count - 1;
            }
            self.Refresh();
        }

        //点击创建角色
        public static async ETTask OnClickCreateRole(this RoleSelectPanel self)
        {
           await LoginHelper.EnterGameAndCreatRole(self.Scene(), self.Scene().GetComponent<AccountComponent>().Account,
                self.HeroConfigs[self.SelectIndex].Id);
        }
    }
}