using ET.Client.Main;
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

        #region 摇杆相关逻辑
        private static void AddJoystickLogic(this MainPanel self)
        {
            FUI_JoystickComponent joystickComponent = self.FUIMainPanel.JoystickComponent;
            Joystick joystickMono = joystickComponent.displayObject.gameObject.AddComponent<Joystick>();
            joystickMono.Init(joystickComponent.Btn_Joystick, joystickComponent.Img_JoystickBG);
        }

        private static void OnJoyStickDown(this MainPanel self)
        {
            
        }
        #endregion
        
    }
}