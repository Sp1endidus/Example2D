using Example2D.CreepyAlchemist.Runtime.Configs;
using Example2D.CreepyAlchemist.Runtime.Configs.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay.Model {
	public class ItemsController : IInitializable {
        private readonly ConfigsController _configsController;
        private readonly ItemModel.Pool _itemsPool;

        [Inject]
        public ItemsController(ConfigsController configsController,
            ItemModel.Pool itemsPool) {
            _configsController = configsController;
            _itemsPool = itemsPool;
        }

        public void Initialize() {

        }

        public ItemModel CreateItemModel(string itemDataId) {
            return CreateItemModel(_configsController.Gameplay.Items[itemDataId]);
        }

        public ItemModel CreateItemModel(ItemData itemData) {
            return _itemsPool.Spawn(itemData);
        }
    }
}