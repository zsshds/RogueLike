using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class HeroAttributeCategory 
        : Singleton<HeroAttributeCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<HeroAttribute> list = new();

        [BsonIgnore]
        private Dictionary<int, HeroAttribute> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (HeroAttribute item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public HeroAttribute Get(int id)
        {
            if (!this.dict.TryGetValue(id, out HeroAttribute item))
            {
                throw new Exception(
                    "配置不存在: HeroAttribute id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, HeroAttribute> GetAll()
        {
            return this.dict;
        }
    }

    public partial class HeroAttribute
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>属性名</summary>
		public string AttributeName { get; set; }

    }
}
