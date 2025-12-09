using ET.Client.Login;
using UnityEditor.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUI_RoleImgComponent))]
    [FriendOf(typeof(FUI_RoleImgComponent))]
    public static partial class RoleImgComponentSystem
    {
        public static void Init(this FUI_RoleImgComponent self, HeroConfig heroConfig, Scene scene)
        {
            self.Btn_NextRole.onClick.Add(() =>
            {
                EventSystem.Instance.Publish(scene, new OnClickNextRole());
            });
            self.Btn_PreRole.onClick.Add(() =>
            {
                EventSystem.Instance.Publish(scene, new OnClickPreRole());
            });
            self.RefreshWithHeroConfig(heroConfig);
        }
        
        private static void RefreshWithHeroConfig(this FUI_RoleImgComponent self, HeroConfig heroConfig)
        {
            self.Img_Role.url = heroConfig.Icon;
        }
        
    }
}