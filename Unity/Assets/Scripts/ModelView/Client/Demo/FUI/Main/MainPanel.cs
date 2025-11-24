using ET.Client.Main;

namespace ET.Client
{
    [ComponentOf(typeof(FUIEntity))]
    [FUIPanel(PanelId.MainPanel, "Main", "MainPanel")]
    public class MainPanel: Entity, IAwake, IShow
    {
        private FUI_MainPanel _fuiMainPanel;

        public FUI_MainPanel FUIMainPanel
        {
            get => _fuiMainPanel ??= (FUI_MainPanel)this.GetParent<FUIEntity>().GComponent;
        }
    }
}
