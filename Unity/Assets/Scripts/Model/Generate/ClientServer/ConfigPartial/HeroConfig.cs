using System;
using System.Collections.Generic;

namespace ET
{
    public partial class HeroConfigCategory
    {
        
        public List<HeroConfig> HeroConfigs = new();
        
        public HeroConfig GetByHeroId(int heroId)
        {
            this.dict.TryGetValue(heroId, out HeroConfig heroConfig);
            if (heroConfig == null)
            {
                throw new Exception($"找不到英雄配置: {heroId}");
            }
            return heroConfig;
        }

        public List<HeroConfig> GetAllHeroConfig()
        {
            return this.HeroConfigs;
        }

        public override void EndInit()
        {
            foreach (HeroConfig heroConfig in this.GetAll().Values)
            {
                this.HeroConfigs.Add(heroConfig);
            }
        }
    }
}
