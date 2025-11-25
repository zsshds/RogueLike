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
        //摇杆组件初始化
        private static void AddJoystickLogic(this MainPanel self)
        {
            FUI_JoystickComponent joystickComponent = self.FUIMainPanel.JoystickComponent;
            Joystick joystickMono = joystickComponent.displayObject.gameObject.AddComponent<Joystick>();
            joystickMono.Init(joystickComponent.Btn_Joystick, joystickComponent.Img_JoystickBG);
        }
        
        //摇杆事件
        private static void JoystickTouchEnd(this MainPanel self, Vector2 v)
        {
            self.Scene().GetComponent<OperaComponent>().StopMove();
        }
        #endregion
        
    }
}