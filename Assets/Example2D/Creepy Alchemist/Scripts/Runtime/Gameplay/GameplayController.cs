using Cysharp.Threading.Tasks;
using Example2D.Common.Runtime.Core.Inventory;
using Example2D.CreepyAlchemist.Runtime.Configs;
using Example2D.CreepyAlchemist.Runtime.Gameplay.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay {
	public class GameplayController : IInitializable {

        private readonly ConfigsController _configsController;
        private readonly InventoryController _inventoryController;
        private readonly ItemsController _itemsController;
        private readonly InventoryCellModel.Pool _inventoryCellsPool;

        public bool Initialized { get; private set; }

        [Inject]
        public GameplayController(ConfigsController configsController,
            InventoryController inventoryController,
            ItemsController itemsController,
            InventoryCellModel.Pool inventoryCellsPool) {
            _configsController = configsController;
            _inventoryController = inventoryController;
            _itemsController = itemsController;
            _inventoryCellsPool = inventoryCellsPool;
        }

        public async void Initialize() {
            await UniTask.WaitUntil(() => _itemsController.Initialized);

            _inventoryController.Initialize(_configsController.Gameplay.InventoryConfig.Cells,
                () => _inventoryCellsPool.Spawn());

            foreach (var item in _configsController.Gameplay.InventoryPreset) {
                _inventoryController.AddItem(item.CellIndex, _itemsController.CreateItemModel(item.ItemId));
            }

            Initialized = true;
        }
    }
}