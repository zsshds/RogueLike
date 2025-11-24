/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
    [EnableClass]
    public partial class FUI_MainPanel: GComponent
    {
        public GGraph JoystickArea;
        public GImage JoystickCenter;
        public ET.Client.Main.FUI_Joystick Btn_Joystick;
        public const string URL = "ui://ngzx0fqyjfdx0";

        public static FUI_MainPanel CreateInstance()
        {
            return (FUI_MainPanel)UIPackage.CreateObject("Main", "MainPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            JoystickArea = (GGraph)GetChildAt(0);
            JoystickCenter = (GImage)GetChildAt(1);
            Btn_Joystick = (ET.Client.Main.FUI_Joystick)GetChildAt(2);
        }
    }
}
