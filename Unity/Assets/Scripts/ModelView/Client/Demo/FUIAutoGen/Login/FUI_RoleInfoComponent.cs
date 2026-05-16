/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleInfoComponent: GComponent
    {
        public GTextField Txt_RoleName;
        public GTextField Txt_RoleDIcx;
        public GList RoleAttributeList;
        public const string URL = "ui://9q0q76hczijbk";

        public static FUI_RoleInfoComponent CreateInstance()
        {
            return (FUI_RoleInfoComponent)UIPackage.CreateObject("Login", "RoleInfoComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Txt_RoleName = (GTextField)GetChildAt(4);
            Txt_RoleDIcx = (GTextField)GetChildAt(5);
            RoleAttributeList = (GList)GetChildAt(6);
        }
    }
}
