/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleImgComponent: GComponent
    {
        public GLoader Img_Role;
        public const string URL = "ui://9q0q76hcbxuqu";

        public static FUI_RoleImgComponent CreateInstance()
        {
            return (FUI_RoleImgComponent)UIPackage.CreateObject("Login", "RoleImgComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Img_Role = (GLoader)GetChildAt(0);
        }
    }
}
