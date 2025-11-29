/** This is an automatically generated class by FUICodeSpawner. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace ET.Client.Main
{
    [EnableClass]
    public partial class FUI_Joystick: GButton
    {
        public GImage Joystick;
        public const string URL = "ui://ngzx0fqyv5yn3";

        public static FUI_Joystick CreateInstance()
        {
            return (FUI_Joystick)UIPackage.CreateObject("Main", "Joystick");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);
            Joystick = (GImage)GetChildAt(0);
        }
    }
}
