using UnityEngine;

namespace ET.Client
{
    /**
     * 我认为对对于场景实体中的碰撞检测，似乎没有必要说使用高精度的
     * 因为只有Player会碰撞，但是我目前不知道怎么创建一个实体，实体在服务器端又该如何表现
     * 按照道理来说，家园的事件是应该由客户端处理，但是看到论坛上说，需要实体去实现
     * 还在逐步摸索中
     */

    [EntitySystemOf(typeof(SceneEvent))]
    [FriendOf(typeof(SceneEvent))]
    public static partial class SceneEventSystem
    {
        [EntitySystem]
        private static void Awake(this SceneEvent self, string name, GameObject gameObject)
        {
            self.CharacterController = null;
            gameObject.layer = LayerMask.NameToLayer(LayerNames.DEFAULT);
            self.Name = name;
            self.GameObject = gameObject;
            self.CharacterController = gameObject.GetComponent<CharacterController>();

        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.SceneEvent self)
        {
            self.CharacterController = null;
            UnityEngine.Object.Destroy(self.GameObject);
        }
        
        [EntitySystem]
        private static void Update(this ET.Client.SceneEvent self)
        {
            
        }
    }

    public class SceneEvent : Entity, IAwake<string, GameObject>, IDestroy, IUpdate
    {
        public GameObject GameObject {get; set; }
        public string Name {get; set;}
        public CharacterController CharacterController {get; set;}
    }
}
