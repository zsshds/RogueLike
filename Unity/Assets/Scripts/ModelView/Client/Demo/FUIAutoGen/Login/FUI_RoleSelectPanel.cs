/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleSelectPanel: GComponent
    {
        public ET.Client.Login.FUI_RoleInfoComponent RoleInfoComponent;
        public ET.Client.Common.FUI_BreakButton Btn_Back;
        public ET.Client.Common.FUI_CommonButton Btn_CreateNewRole;
        public GTextField Txt_RoleNumber;
        public ET.Client.Login.FUI_RoleImgComponent RoleImgComponent;
        public const string URL = "ui://9q0q76hcbxuqp";

        public static FUI_RoleSelectPanel CreateInstance()
        {
            return (FUI_RoleSelectPanel)UIPackage.CreateObject("Login", "RoleSelectPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            RoleInfoComponent = (ET.Client.Login.FUI_RoleInfoComponent)GetChildAt(1);
            Btn_Back = (ET.Client.Common.FUI_BreakButton)GetChildAt(2);
            Btn_CreateNewRole = (ET.Client.Common.FUI_CommonButton)GetChildAt(3);
            Txt_RoleNumber = (GTextField)GetChildAt(4);
            RoleImgComponent = (ET.Client.Login.FUI_RoleImgComponent)GetChildAt(5);
        }
    }
}
