using ET.Client.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.RoleListPanel, "Login", "RoleListPanel")]
    public class RoleListPanel: Entity, IAwake, IShow
    {
        private FUI_RoleListPanel _fuiRoleListPanel;

        public FUI_RoleListPanel FUIRoleListPanel
        {
            get => _fuiRoleListPanel ??= (FUI_RoleListPanel)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
