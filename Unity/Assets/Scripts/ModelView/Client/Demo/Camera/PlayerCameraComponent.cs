using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class PlayerCameraComponent : Entity, IAwake, ILateUpdate
    {
        private Camera camera;
        public Transform Transform;
        public Camera Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
                this.Transform = this.camera.transform;
            }
        }
        public GameObject TargetObject { get; set; }
    }

}