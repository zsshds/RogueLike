/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
    [EnableClass]
    public partial class FUI_MainPanel: GComponent
    {
        public ET.Client.Main.FUI_JoystickComponent JoystickComponent;
        public const string URL = "ui://ngzx0fqyjfdx0";

        public static FUI_MainPanel CreateInstance()
        {
            return (FUI_MainPanel)UIPackage.CreateObject("Main", "MainPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            JoystickComponent = (ET.Client.Main.FUI_JoystickComponent)GetChildAt(0);
        }
    }
}
