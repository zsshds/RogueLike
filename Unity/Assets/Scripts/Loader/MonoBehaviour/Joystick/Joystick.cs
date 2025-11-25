using System;
using UnityEngine;
using FairyGUI;
using UnityEngine.Events;

namespace ET
{
    public enum Direction  // 方向枚举
    {
        Both,
        Horizontal,
        Vertical
    }
    
    
    public class Joystick : MonoBehaviour
    { 
        //定义一些事件
        public class JoystickEvent : UnityEvent<Vector2> { }
        public JoystickEvent OnJoystickTouchBegin = new JoystickEvent(); // 事件： 摇杆被按下时
        public JoystickEvent OnJoystickTouchEnd = new JoystickEvent(); //事件 ： 摇杆上抬起时
        public JoystickEvent OnJoystickTouchMove = new JoystickEvent(); //事件 ： 摇杆被 拖拽时
        public UnityEvent<Vector2> OnSwipeEvent = new UnityEvent<Vector2>(); //事件 ： 非触发摇杆滑动时
        private Vector3 originLocalPostion, pointerDownPosition;
        private int fingerId = int.MinValue; //当前触发摇杆的 pointerId ，预设一个永远无法企及的值
        
        //定义摇杆属性
        private const float DRAG_TIME = 0.15f;  // 判断拖拽和滑动的阈值时间
        public int offsetY = 0;  // Y轴偏移量
        public int offsetX = 0;
        public float maxRadius = 100;  // 摇杆移动的最大半径
        public Direction activatedAxis = Direction.Both;  // 激活的轴向
        public GButton joystick; //摇杆
        public Transform JoystickTransform;
        public Transform BackGroundTransform;
        public bool IsDraging { get { return fingerId != int.MinValue; } } //摇杆拖拽状态
        private float dragTime = 0;
        private float pointDownTime = 0;

        //初始化组组件，传递UIGO的Transforme
        public void Init(GButton Btn_joystick, GObject Img_Bg)
        {
            this.BackGroundTransform = Img_Bg.displayObject.gameObject.transform;
            //计算偏移量
            this.offsetY = -(int)Math.Round(Img_Bg.height / 2 - Btn_joystick.height / 2);
            this.offsetX = (int)Math.Round(Img_Bg.width / 2 - Btn_joystick.width / 2);
            //获取摇杆的 FGUI 对象
            this.joystick = Btn_joystick;
            this.JoystickTransform = this.joystick.displayObject.gameObject.transform;
            this.originLocalPostion = this.BackGroundTransform.localPosition + new Vector3(offsetX, offsetY, 0); 
            this.RestJoystick();
            //绑定FGUI触摸事件
            this.joystick.onTouchBegin.Add(OnTouchBegin);
            this.joystick.onTouchMove.Add(OnTouchMove);
            this.joystick.onTouchEnd.Add(OnTouchEnd);
        }
        
        private void Update()
        {
            if (this.IsDraging && this.dragTime > DRAG_TIME)
                OnJoystickTouchMove?.Invoke(JoystickTransform.localPosition / maxRadius); //fixedupdate 为物理更新，摇杆操作放在常规 update 就好
        }
        
        private void OnDisable()
        {
            RestJoystick(); //意外被 Disable 各单位需要被重置
        }

        //重置摇杆位置
        private void RestJoystick()
        {
            if (this.IsDraging && this.dragTime > DRAG_TIME)
                OnJoystickTouchMove?.Invoke(Vector2.zero);
            JoystickTransform.localPosition = originLocalPostion;
            fingerId = int.MinValue;
            this.dragTime = 0;
            this.pointDownTime = 0;
        }
        
        #region 摇杆触摸事件
        private void OnTouchBegin(EventContext context)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            if (inputEvent.touchId < -1 || IsDraging) return;  // 过滤无效输入
            fingerId = inputEvent.touchId;  // 记录手指ID
            pointerDownPosition = inputEvent.position;
            OnJoystickTouchBegin.Invoke(inputEvent.position);
            pointDownTime = Time.realtimeSinceStartup;  // 记录按下时间
        }
        
        private void OnTouchMove(EventContext context)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            if (fingerId != inputEvent.touchId) return;  // 检查手指ID匹配
            this.dragTime = Time.realtimeSinceStartup - this.pointDownTime;  // 计算拖拽时间
            // 计算拖拽方向和距离
            Vector2 direction = inputEvent.position - (Vector2)pointerDownPosition;
            float radius = Mathf.Clamp(Vector3.Magnitude(direction), 0, maxRadius);
    
            // 根据激活的轴向限制移动
            Vector2 localPosition = new Vector2()
            {
                x = (activatedAxis == Direction.Both || activatedAxis == Direction.Horizontal) ? (direction.normalized * radius).x : 0 ,
                y = (activatedAxis == Direction.Both || activatedAxis == Direction.Vertical) ? -(direction.normalized * radius).y : 0 //y这里需要取反FGUI默认的输入是从y轴向上的
            };
    
            this.JoystickTransform.localPosition = this.originLocalPostion + new Vector3(localPosition.x, localPosition.y, 0);  // 更新摇杆位置
        }
        
        private void OnTouchEnd(EventContext context)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            if (fingerId != inputEvent.touchId) return;
            // 处理快速滑动（短时间内的移动）
            if (this.dragTime < DRAG_TIME)
            {
                if ((inputEvent.position - (Vector2)pointerDownPosition).magnitude > 50)
                {
                    Debug.Log($"Swipe screen");
                    OnSwipeEvent.Invoke((inputEvent.position - (Vector2)pointerDownPosition).normalized);
                }
            }
            RestJoystick();  // 重置摇杆
            OnJoystickTouchEnd.Invoke(inputEvent.position);
        }
        #endregion
    }
}
