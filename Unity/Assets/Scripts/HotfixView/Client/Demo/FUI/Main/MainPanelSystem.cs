using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MainPanel))]
    [FriendOf(typeof(MainPanel))]
    public static partial class MainPanelSystem
    {
        [EntitySystem]
        private static void Awake(this MainPanel self)
        {
            
        }

        [EntitySystem]
        private static void Show(this MainPanel self)
        {
            self.AddJoystickLogic();
        }
        
        private static void AddJoystickLogic(this MainPanel self)
        {
            //GameObject panel = self.FUIMainPanel.displayObject.gameObject;
            //GameObject panel = GameObject.Find(self.FUIMainPanel.gameObjectName);
            JoystickMono joystickMono = self.FUIMainPanel.displayObject.gameObject.AddComponent<JoystickMono>();
            joystickMono.Init(self.FUIMainPanel.Btn_Joystick, self.FUIMainPanel.Btn_Joystick.GetChild("Joystick"),self.FUIMainPanel.JoystickArea, self.FUIMainPanel.JoystickCenter);
        }
    }
}