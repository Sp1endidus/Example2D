using Example2D.Common.Runtime.Configs;
using Newtonsoft.Json;
using System;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Gameplay {
    [Serializable]
    [ConfigName("Gameplay/Items")]
    public class ItemData {
        [JsonProperty("id")] public readonly string Id;
        [JsonProperty("base_cost")] public float BaseCost;
    }
}