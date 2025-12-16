using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class HeroConfigCategory 
        : Singleton<HeroConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<HeroConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, HeroConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (HeroConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public HeroConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out HeroConfig item))
            {
                throw new Exception(
                    "配置不存在: HeroConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, HeroConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class HeroConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Type</summary>
		public int Type { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>描述</summary>
		public string Desc { get; set; }
		/// <summary>Icon</summary>
		public string Icon { get; set; }
		/// <summary>AttributeDict</summary>
		public Dictionary<int, long> AttributeDict { get; set; }

    }
}
