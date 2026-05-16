namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class PlayerComponent: Entity, IAwake
    {
        public long MyId { get; set; }
        public long RealmKey { get; set;}
        public long GateId { get; set; }
    }
}