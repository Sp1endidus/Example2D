using Example2D.Common.Runtime.Configs;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Example2D.CreepyAlchemist.Runtime.Configs {
	public abstract class ConfigsBase {
        public abstract void Initialize();

        public const string ConfigsGroup = "Configs/";
        public const string FileFormat = ".json";

        private StringBuilder _path = new StringBuilder(30);

        protected string GetJsonString<T>() {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ConfigNameAttribute>();
            _path.Clear();
            _path.Append(ConfigsGroup).Append(attribute.Name).Append(FileFormat);
            var op = Addressables.LoadAssetAsync<TextAsset>(_path.ToString());
            var asset = op.WaitForCompletion();

            return asset.text;
        }

        protected T Deserialize<T>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<T>(GetJsonString<T>(), settings);
        }

        protected Dictionary<T1, T2> DeserializeDictionary<T1, T2>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<Dictionary<T1, T2>>(GetJsonString<T2>(), settings);
        }

        protected Dictionary<string, T> DeserializeStringKeyDictionary<T>(
            JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<Dictionary<string, T>>(GetJsonString<T>(), settings);
        }

        protected List<T> DeserializeList<T>(JsonSerializerSettings settings = null) {
            return JsonConvert.DeserializeObject<List<T>>(GetJsonString<T>(), settings);
        }
    }
}