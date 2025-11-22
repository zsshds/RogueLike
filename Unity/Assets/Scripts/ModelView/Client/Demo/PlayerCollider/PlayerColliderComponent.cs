using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class PlayerColliderComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public Collider Other;
        public GameObject PlayerGo;
    }
}
