using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(PlayerCameraComponent))]
    [FriendOfAttribute(typeof(ET.Client.PlayerCameraComponent))]
    public static partial class PlayerCameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.PlayerCameraComponent self)
        {
            self.Camera = Camera.main;
            self.Camera.transform.rotation = Quaternion.Euler(new Vector3(50, 0, 0));
        }
        [EntitySystem]
        private static void LateUpdate(this ET.Client.PlayerCameraComponent self)
        {
            if (self.TargetObject != null)
            {
                self.Transform.position = math.lerp(self.Camera.transform.position, self.TargetObject.transform.position + new Vector3(0, 7, -6), Time.deltaTime * 2.5f);
                //self.Transform.position = self.TargetObject.transform.position + new Vector3(0, 5, -4);
            }
        }
    }
}
