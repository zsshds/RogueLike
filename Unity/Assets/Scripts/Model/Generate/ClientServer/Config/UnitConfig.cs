using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class UnitConfigCategory 
        : Singleton<UnitConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<UnitConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, UnitConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (UnitConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public UnitConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out UnitConfig item))
            {
                throw new Exception(
                    "配置不存在: UnitConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, UnitConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class UnitConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Type</summary>
		public int Type { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>位置</summary>
		public int Position { get; set; }
		/// <summary>身高</summary>
		public int Height { get; set; }
		/// <summary>体重</summary>
		public int Weight { get; set; }

    }
}
