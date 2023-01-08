using Example2D.Common.Runtime.Utils;
using Example2D.CreepyAlchemist.Runtime.Configs;
using Example2D.CreepyAlchemist.Runtime.Configs.Gameplay;
using Example2D.CreepyAlchemist.Runtime.Configs.Scriptable;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay.Model {
	public class ItemsController : IInitializable {
        private readonly string _itemsConfigsSOPath = "Configs/Scriptable/Items Settings.asset";

        private readonly ConfigsController _configsController;
        private readonly ItemModel.Pool _itemsPool;

        public ItemsSO ItemsConfigsSO { get; private set; }
        public bool Initialized { get; private set; }

        [Inject]
        public ItemsController(ConfigsController configsController,
            ItemModel.Pool itemsPool) {
            _configsController = configsController;
            _itemsPool = itemsPool;
        }

        public void Initialize() {
            ItemsConfigsSO = InstantiateController.LoadAsset<ItemsSO>(_itemsConfigsSOPath);
            Initialized = true;
        }

        public ItemModel CreateItemModel(string itemDataId) {
            return CreateItemModel(_configsController.Gameplay.Items[itemDataId]);
        }

        public ItemModel CreateItemModel(ItemData itemData) {
            var itemSO = ItemsConfigsSO.Items.Where((item) => item.Id == itemData.Id).FirstOrDefault();

            return _itemsPool.Spawn(itemData, itemSO);
        }
    }
}