using ET.Client.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.RoleInfoComponent, "Login", "RoleInfoComponent")]
    public class RoleInfoComponent: Entity
    {
        private FUI_RoleInfoComponent _fuiRoleInfoComponent;

        public FUI_RoleInfoComponent FUIRoleInfoComponent
        {
            get => _fuiRoleInfoComponent ??= (FUI_RoleInfoComponent)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
