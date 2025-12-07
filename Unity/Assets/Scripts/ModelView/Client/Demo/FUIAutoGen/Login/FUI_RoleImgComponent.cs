/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleImgComponent: GComponent
    {
        public GLoader Img_Role;
        public ET.Client.Login.FUI_NextRoleButton Btn_NextRole;
        public ET.Client.Login.FUI_NextRoleButton Btn_PreRole;
        public GTextField Txt_RoleNumber;
        public const string URL = "ui://9q0q76hcbxuqu";

        public static FUI_RoleImgComponent CreateInstance()
        {
            return (FUI_RoleImgComponent)UIPackage.CreateObject("Login", "RoleImgComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Img_Role = (GLoader)GetChildAt(1);
            Btn_NextRole = (ET.Client.Login.FUI_NextRoleButton)GetChildAt(2);
            Btn_PreRole = (ET.Client.Login.FUI_NextRoleButton)GetChildAt(3);
            Txt_RoleNumber = (GTextField)GetChildAt(4);
        }
    }
}
