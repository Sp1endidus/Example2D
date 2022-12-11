using Example2D.Common.Runtime.Configs;
using Newtonsoft.Json;
using System;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Gameplay {
    [Serializable]
    [ConfigName("Gameplay/InventoryConfig")]
    public class InventoryConfigData {
        [JsonProperty("id")] public readonly string Id;
        [JsonProperty("cells")] public int Cells;
    }
}