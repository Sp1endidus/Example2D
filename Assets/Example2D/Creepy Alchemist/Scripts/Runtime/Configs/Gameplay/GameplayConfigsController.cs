using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Gameplay {
    public class GameplayConfigsController : ConfigsBase {
        public Dictionary<string, ItemData> Items { get; private set; }

        public override void Initialize() {
            Items = DeserializeStringKeyDictionary<ItemData>();
        }
    }
}