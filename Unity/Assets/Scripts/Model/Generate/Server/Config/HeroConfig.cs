using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    [Config]
    public partial class HeroConfigCategory 
        : Singleton<HeroConfigCategory>, IMerge
    {
        /// <summary>
        /// 配置列表，仅用于反序列化
        /// </summary>
        [BsonElement("list")]
        private List<HeroConfig> list = new();

        /// <summary>
        /// 字典索引，运行期使用
        /// </summary>
        [BsonIgnore]
        private Dictionary<int, HeroConfig> dict = new();

        public void Merge(object o)
        {
            HeroConfigCategory s = o as HeroConfigCategory;
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

        public HeroConfig Get(int id)
        {
            if (!this.dict.TryGetValue(id, out var item))
            {
                throw new Exception(
                    $"配置找不到，配置表名: {nameof(HeroConfig)}，配置id: {id}");
            }
            return item;
        }

        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, HeroConfig> GetAll()
        {
            return this.dict;
        }

        public HeroConfig GetOne()
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

    public partial class HeroConfig : ProtoObject, IConfig
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
		public Dictionary<string, long> AttributeDict { get; set; }

    }
}
