/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleListPanel: GComponent
    {
        public ET.Client.Common.FUI_CommonButton Btn_EnterGame;
        public GTextField Txt_ServeTitle;
        public ET.Client.Common.FUI_CommonButton Btn_CreateNewRole;
        public const string URL = "ui://9q0q76hczijbf";

        public static FUI_RoleListPanel CreateInstance()
        {
            return (FUI_RoleListPanel)UIPackage.CreateObject("Login", "RoleListPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Btn_EnterGame = (ET.Client.Common.FUI_CommonButton)GetChildAt(1);
            Txt_ServeTitle = (GTextField)GetChildAt(3);
            Btn_CreateNewRole = (ET.Client.Common.FUI_CommonButton)GetChildAt(6);
        }
    }
}
