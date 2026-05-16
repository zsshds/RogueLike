/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_NextRoleButton: GButton
    {
        public enum ArCPage
        {
            Next,
            Pre,
        }

        public Controller ArC;
        public const string URL = "ui://9q0q76hch3lum";

        public static FUI_NextRoleButton CreateInstance()
        {
            return (FUI_NextRoleButton)UIPackage.CreateObject("Login", "NextRoleButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            ArC = GetControllerAt(1);
        }
    }
}
