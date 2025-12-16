using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class AIConfigCategory 
        : Singleton<AIConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<AIConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, AIConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (AIConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public AIConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out AIConfig item))
            {
                throw new Exception(
                    "配置不存在: AIConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, AIConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class AIConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>所属ai</summary>
		public int AIConfigId { get; set; }
		/// <summary>此ai中的顺序</summary>
		public int Order { get; set; }
		/// <summary>节点名字</summary>
		public string Name { get; set; }
		/// <summary>节点参数</summary>
		public int[] NodeParams { get; set; }

    }
}
