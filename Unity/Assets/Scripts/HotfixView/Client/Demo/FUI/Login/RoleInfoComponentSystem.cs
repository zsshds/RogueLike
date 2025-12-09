using ET.Client.Login;

namespace ET.Client
{
    [EntitySystemOf(typeof(FUI_RoleInfoComponent))]
    public static partial class RoleInfoComponentSystem
    {
        public static void Init(this FUI_RoleInfoComponent self, HeroConfig heroConfig)
        {
            self.Txt_RoleName.text = heroConfig.Name;
            self.Txt_RoleDIcx.text = heroConfig.Desc;
            
        }
    }

}
