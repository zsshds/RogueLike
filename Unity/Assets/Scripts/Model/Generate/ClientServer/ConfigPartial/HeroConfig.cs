namespace ET
{
    public partial class HeroConfig
    {
        public HeroConfig HeroConfigs;
        
        
        public override void EndInit()
        {
            this.HeroConfigs = this;
        }
    }
}
