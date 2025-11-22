using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(PlayerColliderComponent))]
    [FriendOfAttribute(typeof(ET.Client.PlayerColliderComponent))]
    public static partial class PlayerColliderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.PlayerColliderComponent self, UnityEngine.GameObject gameObject)
        {
            self.PlayerGo = gameObject;
            ColliderCallBack callback  = self.PlayerGo.GetComponent<ColliderCallBack>();
            //callback.OnTriggerEnterAction = self.OnTriggerEnter;
            //callback.OnTriggerExitAction = self.OnTriggerExit;
            callback.OnCollisionEnterAction = self.OnCollisionEnter;
            callback.OnCollisionExitAction = self.OnCollisionExit;
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.PlayerColliderComponent self)
        {
            self.PlayerGo = null;
            self.Other = null;
        }

        /// <summary>
        /// 进入碰撞
        /// </summary>
        public static void OnTriggerEnter(this PlayerColliderComponent self, Collider collider)
        {
            Log.Debug("进入了触发碰撞");
            Log.Debug("碰撞的物体是" + collider.gameObject.name);
        }

        /// <summary>
        /// 退出碰撞
        /// </summary>
        /// <param name="self"></param>
        /// <param name="collider"></param>
        public static void OnTriggerExit(this PlayerColliderComponent self, Collider collider)
        {
            Log.Debug("退出了触发碰撞");
            Log.Debug("碰撞的物体是" + collider.gameObject.name);
        }
        
        public static void OnCollisionEnter(this PlayerColliderComponent self, Collider collider)
        {
            Log.Debug("碰撞了");
            Log.Debug("碰撞的物体是" + collider.gameObject.name);
        }
        public static void OnCollisionExit(this PlayerColliderComponent self, Collider collider)
        {
            Log.Debug("退出了碰撞");
            Log.Debug("碰撞的物体是" + collider.gameObject.name);
        }
    }

}
