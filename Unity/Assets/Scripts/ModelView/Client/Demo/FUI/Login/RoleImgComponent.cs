using ET.Client.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.RoleImgComponent, "Login", "RoleImgComponent")]
    public class RoleImgComponent: Entity
    {
        private FUI_RoleImgComponent _fuiRoleImgComponent;

        public FUI_RoleImgComponent FUIRoleImgComponent
        {
            get => _fuiRoleImgComponent ??= (FUI_RoleImgComponent)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
