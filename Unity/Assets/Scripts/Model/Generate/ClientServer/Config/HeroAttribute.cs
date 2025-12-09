using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class HeroAttributeCategory : Singleton<HeroAttributeCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, HeroAttribute> dict = new();
		
        public void Merge(object o)
        {
            HeroAttributeCategory s = o as HeroAttributeCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public HeroAttribute Get(int id)
        {
            this.dict.TryGetValue(id, out HeroAttribute item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (HeroAttribute)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, HeroAttribute> GetAll()
        {
            return this.dict;
        }

        public HeroAttribute GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            
            var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current; 
        }
    }

	public partial class HeroAttribute: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>属性名</summary>
		public string AttributeName { get; set; }

	}
}
