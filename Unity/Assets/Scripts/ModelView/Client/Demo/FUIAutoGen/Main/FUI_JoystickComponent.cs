/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
    [EnableClass]
    public partial class FUI_JoystickComponent: GComponent
    {
        public GImage Img_JoystickBG;
        public ET.Client.Main.FUI_Joystick Btn_Joystick;
        public const string URL = "ui://ngzx0fqyrn9h4";

        public static FUI_JoystickComponent CreateInstance()
        {
            return (FUI_JoystickComponent)UIPackage.CreateObject("Main", "JoystickComponent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Img_JoystickBG = (GImage)GetChildAt(0);
            Btn_Joystick = (ET.Client.Main.FUI_Joystick)GetChildAt(1);
        }
    }
}
