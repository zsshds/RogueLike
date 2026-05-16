/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_ServerInfoButton: GButton
    {
        public enum HasRolePage
        {
            Yes,
            No,
        }

        public Controller HasRole;
        public GTextField Txt_Title;
        public GTextField Txt_RoleInfo;
        public const string URL = "ui://9q0q76hcnubc3";

        public static FUI_ServerInfoButton CreateInstance()
        {
            return (FUI_ServerInfoButton)UIPackage.CreateObject("Login", "ServerInfoButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            HasRole = GetControllerAt(0);
            Txt_Title = (GTextField)GetChildAt(1);
            Txt_RoleInfo = (GTextField)GetChildAt(2);
        }
    }
}
