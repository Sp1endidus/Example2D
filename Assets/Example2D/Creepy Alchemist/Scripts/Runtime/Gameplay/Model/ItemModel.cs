using Example2D.Common.Runtime.Core.Inventory;
using Example2D.CreepyAlchemist.Runtime.Configs.Gameplay;
using Example2D.CreepyAlchemist.Runtime.Configs.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay.Model {
	public class ItemModel : IInventoryItem {
		public class Pool : MemoryPool<ItemData, ItemSO, ItemModel> {
            protected override void Reinitialize(ItemData itemData, ItemSO itemSO, ItemModel item) {
                item.Initialize(itemData, itemSO);
            }
        }

        public ItemData ItemData { get; private set; }
        public ItemSO ItemSO { get; private set; }

        [Inject]
        public ItemModel() {
        }

        public void Initialize(ItemData itemData, ItemSO itemSO) {
            ItemData = itemData;
            ItemSO = itemSO;
        }
	}
}