using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class StartZoneConfigCategory 
        : Singleton<StartZoneConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<StartZoneConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, StartZoneConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (StartZoneConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public StartZoneConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out StartZoneConfig item))
            {
                throw new Exception(
                    "配置不存在: StartZoneConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, StartZoneConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class StartZoneConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>数据库地址</summary>
		public string DBConnection { get; set; }
		/// <summary>数据库名</summary>
		public string DBName { get; set; }
		/// <summary>ZoneType</summary>
		public int ZoneType { get; set; }
		/// <summary>区服名称</summary>
		public string ZoneName { get; set; }

    }
}
