using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class StartProcessConfigCategory 
        : Singleton<StartProcessConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<StartProcessConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, StartProcessConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (StartProcessConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public StartProcessConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out StartProcessConfig item))
            {
                throw new Exception(
                    "配置不存在: StartProcessConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, StartProcessConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class StartProcessConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>所属机器</summary>
		public int MachineId { get; set; }
		/// <summary>外网端口</summary>
		public int Port { get; set; }

    }
}
