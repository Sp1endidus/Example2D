using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Gameplay {
    public class GameplayConfigsController : ConfigsBase {
        public Dictionary<string, ItemData> Items { get; private set; }
        public InventoryConfigData InventoryConfig { get; private set; }
        public List<InventoryPresetData> InventoryPreset { get; private set; }

        public override void Initialize() {
            Items = DeserializeStringKeyDictionary<ItemData>();
            InventoryConfig = DeserializeStringKeyDictionary<InventoryConfigData>()
                .Values.FirstOrDefault();
            InventoryPreset = DeserializeList<InventoryPresetData>();
        }
    }
}