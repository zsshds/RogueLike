namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class PlayerMoveComponent : Entity, IAwake, IFixedUpdate, IDestroy
    {
        public bool IsMoving { get; set; }
    }
}