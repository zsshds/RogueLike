using ET.Client.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.RoleAttributeComponent, "Login", "RoleAttributeComponent")]
    public class RoleAttributeComponent: Entity
    {
        private FUI_RoleAttributeComponent _fuiRoleAttributeComponent;

        public FUI_RoleAttributeComponent FUIRoleAttributeComponent
        {
            get => _fuiRoleAttributeComponent ??= (FUI_RoleAttributeComponent)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
