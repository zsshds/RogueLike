using System.Collections.Generic;
using ET.Client.Login;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.RoleSelectPanel, "Login", "RoleSelectPanel")]
    public class RoleSelectPanel: Entity, IAwake, IShow
    {
        private FUI_RoleSelectPanel _fuiRoleSelectPanel;
        
        //public List<EntityRef<RoleInfo>> RoleList = new List<EntityRef<RoleInfo>>();

        public FUI_RoleSelectPanel FUIRoleSelectPanel
        {
            get => _fuiRoleSelectPanel ??= (FUI_RoleSelectPanel)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
