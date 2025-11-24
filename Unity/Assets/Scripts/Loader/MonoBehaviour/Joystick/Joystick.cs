using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
namespace ET
{
    public class Joystick : EventDispatcher
    { 
        //事件的监听者
        public EventListener onMove { get; private set; }  //设置了一个安全权限
        public EventListener onEnd { get; private set; }

        //mainUI里的对象
        private GButton Btn_Joystick;
        private GObject joystick;
        private GObject JoystickArea;
        private GObject JoystickCenter;

        //摇杆的属性
        private float initX;
        private float initY;
        private float startStageX;
        private float startStageY;
        private float lastStageX;
        private float lastStageY;
        private int touchID;
        private int radius { get; set; }
        private GTweener tweener;
        
        public Joystick(GButton Btn_Joystick, GObject joystick, GObject JoystickArea, GObject JoystickCenter)
        {
            onMove = new EventListener(this,"onMove");
            onEnd = new EventListener(this, "onEnd");
            //rockingbarButton = mainUI.GetChild("RockingBar").asButton;
            //rockingbarButton.changeStateOnClick = false;
            this.Btn_Joystick = Btn_Joystick;
            this.Btn_Joystick.changeStateOnClick = false;
            //thumb = rockingbarButton.GetChild("thumb");
            this.joystick = joystick;
            //touchArea = mainUI.GetChild("RockingBarTouchArea");
            this.JoystickArea = JoystickArea;
            //center = mainUI.GetChild("RockingBarCenter");
            this.JoystickCenter = JoystickCenter;

            initX = this.JoystickCenter.x + this.JoystickCenter.width / 2;
            initY = this.JoystickCenter.y + this.JoystickCenter.height / 2;
            touchID = -1;
            radius = 150;

            this.JoystickArea.onTouchBegin.Add(OnTouchBegin);
            this.JoystickArea.onTouchMove.Add(OnTouchMove);
            this.JoystickArea.onTouchEnd.Add(OnTouchEnd);
        }

        //开始触摸
        private void OnTouchBegin(EventContext context)
        {
            if (touchID == -1)  //第一次触摸
            {
                InputEvent inputEvent = (InputEvent)context.data;
                touchID = inputEvent.touchId;

                if (tweener != null)
                {
                    tweener.Kill();  //杀死上一个动画
                    tweener = null;
                }

                Vector2 localPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
                float posX = localPos.x;
                float posY = localPos.y;
                Btn_Joystick.selected = true;

                lastStageX = posX;
                lastStageY = posY;
                startStageX = posX;
                startStageY = posY;

                JoystickCenter.visible = true;
                JoystickCenter.SetXY(posX - JoystickCenter.width / 2, posY - JoystickCenter.height / 2);
                Btn_Joystick.SetXY(posX - Btn_Joystick.width / 2, posY - Btn_Joystick.height / 2);

                float deltaX = posX - initX;
                float deltaY = posY - initY;
                float degrees = Mathf.Atan2(deltaY, deltaX) * 180 / Mathf.PI;  //弧度转角度
                joystick.rotation = degrees + 90;
                context.CaptureTouch();

            }
        }

        //移动触摸
        private void OnTouchMove(EventContext context)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            if (touchID != -1 && inputEvent.touchId == touchID)
            {
                Vector2 localPos = GRoot.inst.GlobalToLocal(new Vector2(inputEvent.x, inputEvent.y));
                float posX = localPos.x;
                float posY = localPos.y;
                float moveX = posX - lastStageX;
                float moveY = posY - lastStageY;
                lastStageX = posX;
                lastStageY = posY;
                float buttonX = Btn_Joystick.x + moveX;
                float buttonY = Btn_Joystick.y + moveY;

                float deltaX = buttonX + Btn_Joystick.width / 2 - startStageX;
                float deltaY = buttonY + Btn_Joystick.height / 2 - startStageY;

                float rad = Mathf.Atan2(deltaY, deltaX);
                float degree = rad * 180 / Mathf.PI;
                joystick.rotation = degree + 90;

                //设置范围
                float maxX = radius * Mathf.Cos(rad);
                float maxY = radius * Mathf.Sin(rad);
                if (Mathf.Abs(deltaX) > Mathf.Abs(maxX))
                {
                    deltaX = maxX;
                }
                if (Mathf.Abs(deltaY) > Mathf.Abs(maxY))
                {
                    deltaY = maxY;
                }

                buttonX = startStageX + deltaX;
                buttonY = startStageY + deltaY;

                Btn_Joystick.SetXY(buttonX - Btn_Joystick.width / 2, buttonY - Btn_Joystick.height / 2);

                onMove.Call(degree);
            }
        }

        //结束触摸
        private void OnTouchEnd(EventContext context)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            if (touchID != -1 && inputEvent.touchId == touchID)
            {
                touchID = -1;
                joystick.rotation = joystick.rotation + 180;
                JoystickCenter.visible = false;
                tweener = Btn_Joystick.TweenMove(new Vector2(initX - Btn_Joystick.width / 2, initY - Btn_Joystick.height / 2), 0.3f).OnComplete(() => {
                        tweener = null;
                        Btn_Joystick.selected = false;
                        joystick.rotation = 0;
                        JoystickCenter.visible = true;
                        JoystickCenter.SetXY(initX - JoystickCenter.width / 2, initY - JoystickCenter.height / 2);
                        
                });
            }
            onEnd.Call();
        }
    }
}
