using System;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// Collider的事件回调的脚本 挂载在角色身上
    /// </summary>
    public class ColliderCallBack : MonoBehaviour
    {
        public Action<Collider> OnTriggerEnterAction;
        public Action<Collider> OnTriggerExitAction;
        
        public Action<Collider> OnCollisionEnterAction;
        public Action<Collider> OnCollisionExitAction;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterAction?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExitAction?.Invoke(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            OnCollisionEnterAction?.Invoke(other.collider);
        }
        
        private void OnCollisionExit(Collision other)
        {
            OnCollisionExitAction?.Invoke(other.collider);
        }
    }

}
