using UnityEngine;
using FairyGUI;
namespace ET
{
    public class JoystickMono : MonoBehaviour
    {
        private Joystick Joystick;
        public void Init(GButton Btn_Joystick, GObject joystick, GObject JoystickArea, GObject JoystickCenter)
        {
            Joystick = new Joystick(Btn_Joystick,joystick,JoystickArea,JoystickCenter);
            Joystick.onMove.Add(OnJoystickMove);
            Joystick.onEnd.Add(OnJoystickEnd);
        }
        
        private void OnJoystickMove(EventContext context)
        {
            float degree = (float)context.data;
            Debug.Log("joystick degree:"+degree);
        }
    
        private void OnJoystickEnd()
        {
        }
    }
}
