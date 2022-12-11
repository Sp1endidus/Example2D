using Example2D.Common.Runtime.Configs;
using Newtonsoft.Json;
using System;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Gameplay {
    [Serializable]
    [ConfigName("Gameplay/InventoryPreset")]
    public class InventoryPresetData {
        [JsonProperty("cell_index")] public int CellIndex;
        [JsonProperty("item_id")] public string ItemId;
    }
}