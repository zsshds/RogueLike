using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class StartSceneConfigCategory 
        : Singleton<StartSceneConfigCategory>, ISingletonAwake
    {
        [BsonElement("list")]
        private List<StartSceneConfig> list = new();

        [BsonIgnore]
        private Dictionary<int, StartSceneConfig> dict = new();

        public void Awake()
        {
            this.dict.Clear();
            foreach (StartSceneConfig item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public StartSceneConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out StartSceneConfig item))
            {
                throw new Exception(
                    "配置不存在: StartSceneConfig id=" + id);
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public IReadOnlyDictionary<int, StartSceneConfig> GetAll()
        {
            return this.dict;
        }
    }

    public partial class StartSceneConfig
    {
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>所属进程</summary>
		public int Process { get; set; }
		/// <summary>所属区</summary>
		public int Zone { get; set; }
		/// <summary>类型</summary>
		public string SceneType { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>外网端口</summary>
		public int Port { get; set; }

    }
}
