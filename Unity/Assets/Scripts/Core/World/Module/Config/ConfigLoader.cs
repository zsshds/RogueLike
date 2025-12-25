using System;
using System.Collections.Generic;
#if DOTNET || UNITY_STANDALONE
using System.Threading.Tasks;
#endif

namespace ET
{
    /// <summary>
    /// ConfigLoader会扫描所有的有ConfigAttribute标签的配置,加载进来
    /// </summary>
    public class ConfigLoader : Singleton<ConfigLoader>, ISingletonAwake
    {
        public struct GetAllConfigBytes
        {
        }

        public struct GetOneConfigBytes
        {
            public string ConfigName;
        }

        public void Awake()
        {
        }

        public async ETTask Reload(Type configType)
        {
            GetOneConfigBytes getOneConfigBytes = new() { ConfigName = configType.Name };
            byte[] oneConfigBytes = await EventSystem.Instance.Invoke<GetOneConfigBytes, ETTask<byte[]>>(getOneConfigBytes);
            LoadOneConfig(configType, oneConfigBytes);
        }

        public async ETTask LoadAsync()
        {
            Dictionary<Type, byte[]> configBytes = await EventSystem.Instance.Invoke<GetAllConfigBytes, ETTask<Dictionary<Type, byte[]>>>(new GetAllConfigBytes());

#if DOTNET || UNITY_STANDALONE
            using ListComponent<Task> listTasks = ListComponent<Task>.Create();

            foreach (Type type in configBytes.Keys)
            {
                byte[] oneConfigBytes = configBytes[type];
                Task task = Task.Run(() => LoadOneConfig(type, oneConfigBytes));
                listTasks.Add(task);
            }

            await Task.WhenAll(listTasks.ToArray());
#else
            foreach (Type type in configBytes.Keys)
            {
                LoadOneConfig(type, configBytes[type]);
            }
#endif
        }

        private static void LoadOneConfig(Type configType, byte[] oneConfigBytes)
        {
            object category = MongoHelper.Deserialize(configType, oneConfigBytes, 0, oneConfigBytes.Length);
            // <-- 新增：如果对象实现了 IMerge，就调用 Merge(category) 以构建运行时 dict
            if (category is IMerge merge)
            {
                // 把自身作为参数传入，Merge 会读取自身的 list 并填充 dict
                merge.Merge(category);
            }
            ASingleton singleton = category as ASingleton;
            World.Instance.AddSingleton(singleton);
        }
    }
}