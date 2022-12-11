using Cysharp.Threading.Tasks;
using Example2D.Common.Runtime.Core.Inventory;
using Example2D.CreepyAlchemist.Runtime.Gameplay;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class InventoryUIView : MonoBehaviour {
        [SerializeField] private CellUiView[] cells;

        private GameplayController _gameplayController;
        private InventoryController _inventoryController;
        private ItemUiView.Pool _itemViewsPool;


        [Inject]
        public void Construct(GameplayController gameplayController,
            InventoryController inventoryController,
            ItemUiView.Pool itemViewsPool) {
            _gameplayController = gameplayController;
            _inventoryController = inventoryController;
            _itemViewsPool = itemViewsPool;
        }


        private async void Start () {
            await UniTask.WaitUntil(() => _gameplayController.Initialized);

            for (int i = 0; i < _inventoryController.Cells.Count; i++) {
                if (_inventoryController.Cells[i].HasItem) {
                    _itemViewsPool.Spawn(_inventoryController.Cells[i].Item, cells[i].transform);
                }
            }
        }
	}
}