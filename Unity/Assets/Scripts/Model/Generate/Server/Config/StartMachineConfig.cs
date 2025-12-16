using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class StartMachineConfigCategory 
        : Singleton<StartMachineConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<StartMachineConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, StartMachineConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (StartMachineConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public StartMachineConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out StartMachineConfig item))
            {
                throw new Exception(
                    "配置不存在: StartMachineConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, StartMachineConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class StartMachineConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>内网地址</summary>
		public string InnerIP { get; set; }
		/// <summary>外网地址</summary>
		public string OuterIP { get; set; }
		/// <summary>守护进程端口</summary>
		public string WatcherPort { get; set; }

    }
}
