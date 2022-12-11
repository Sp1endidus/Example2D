using Example2D.Common.Runtime.Core.Inventory;
using Example2D.CreepyAlchemist.Runtime.Configs.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay.Model {
	public class ItemModel : IInventoryItem {
		public class Pool : MemoryPool<ItemData, ItemModel> {
            protected override void Reinitialize(ItemData itemData, ItemModel item) {
                item.Initialize(itemData);
            }
        }

        public ItemData ItemData { get; private set; }

        [Inject]
        public ItemModel() {
        }

        public void Initialize(ItemData itemData) {
            ItemData = itemData;
        }
	}
}