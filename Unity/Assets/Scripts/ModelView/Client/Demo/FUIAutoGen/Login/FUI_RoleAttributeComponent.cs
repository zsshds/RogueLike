/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Login
{
    [EnableClass]
    public partial class FUI_RoleAttributeComponent: GComponent
    {
        public GTextField Txt_AttributeName;
        public GTextField Txt_AttributeValue;
        public const string URL = "ui://9q0q76hcbxuqv";

        public static FUI_RoleAttributeComponent CreateInstance()
        {
            return (FUI_RoleAttributeComponent)UIPackage.CreateObject("Login", "RoleAttributeComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Txt_AttributeName = (GTextField)GetChildAt(0);
            Txt_AttributeValue = (GTextField)GetChildAt(1);
        }
    }
}
