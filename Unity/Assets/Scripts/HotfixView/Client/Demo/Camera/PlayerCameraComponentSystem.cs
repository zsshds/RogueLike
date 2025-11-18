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
            self.Camera.transform.rotation = Quaternion.Euler(new Vector3(65, 0, 0));
        }
        [EntitySystem]
        private static void LateUpdate(this ET.Client.PlayerCameraComponent self)
        {
            if (self.TargetObject != null)
            {
                Vector3 pos = self.TargetObject.transform.position;
                self.Transform.position = new Vector3(pos.x, 15, pos.z - 3f);
            }
        }
    }
}
