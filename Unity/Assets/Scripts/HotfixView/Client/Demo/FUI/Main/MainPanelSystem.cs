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
            //向mono中添加事件监听，其实也可以使用Action委托实现
            joystickMono.OnJoystickTouchEnd.AddListener(self.JoystickTouchEnd);
            joystickMono.OnJoystickTouchMove.AddListener(self.JoystickTouchMove);
        }
        
        //摇杆事件
        private static void JoystickTouchEnd(this MainPanel self, Vector2 v)
        {
            OperaComponent operaComponent = self.Root().Scene().GetComponent<OperaComponent>();
            if (operaComponent != null)
            {
                operaComponent.StopMove();
            }
            else
            {
                Log.Error($"OperateInfos is null");
            }
            
            //self.Scene().GetComponent<OperaComponent>().StopMove();
        }
        
        private static void JoystickTouchMove(this MainPanel self, Vector2 v)
        { 
            if (v == Vector2.zero)
                return;
            OperaComponent operaComponent = self.Root().Scene().GetComponent<OperaComponent>();
            if (operaComponent != null)
            {
                operaComponent.OnMove(v);
            }
            else
            {
                Log.Warning($"当前Scene 为 {self.Scene().Name}， root为 {self.Root().Name}");
                Log.Error($"OperateInfos is null");
            }
            //self.Scene().GetComponent<OperaComponent>().OnMove(v);
        }
        #endregion
        
    }
}