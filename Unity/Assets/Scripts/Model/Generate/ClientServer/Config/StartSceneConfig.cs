using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class StartSceneConfigCategory 
        : Singleton<StartSceneConfigCategory>, IMerge
    {
        /// <summary>
        /// 配置列表，仅用于反序列化
        /// </summary>
        [BsonElement("list")]
        private List<StartSceneConfig> list = new();

        /// <summary>
        /// 字典索引，运行期使用
        /// </summary>
        [BsonIgnore]
        private Dictionary<int, StartSceneConfig> dict = new();

        public void Merge(object o)
        {
            StartSceneConfigCategory s = o as StartSceneConfigCategory;
            if (s == null)
            {
                return;
            }
        
            // 1合并持久化数据（这是会被写入 bytes 的）
            if (s.list != null && s.list.Count > 0)
            {
                this.list.AddRange(s.list);
            }
        
            // 2构建运行期索引（不会被序列化）
            this.dict.Clear();
            foreach (var item in this.list)
            {
                this.dict[item.Id] = item;
            }
        }

        public StartSceneConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out var item))
            {
                throw new Exception(
                    $"配置找不到，配置表名: {nameof(StartSceneConfig)}，配置id: {id}");
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, StartSceneConfig> GetAll()
        {
            return this.dict;
        }

        public StartSceneConfig GetOne()
        {
            if (this.dict.Count == 0)
            {
                return null;
            }

            using var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }
    }

    public partial class StartSceneConfig : ProtoObject, IConfig
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
