using Example2D.Common.Runtime.Core.Inventory;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay.Model {
    public class InventoryCellModel : IInventoryCell {
        public class Pool : MemoryPool<InventoryCellModel> {
            protected override void Reinitialize(InventoryCellModel cell) {
                cell.Initialize();
            }
        }

        public IInventoryItem Item { get; private set; }
        public bool HasItem => Item != null;

        public InventoryCellModel() {

        }

        public void Initialize() {
            RemoveItem();
        }

        public void AddItem(IInventoryItem inventoryItem) {
            Item = inventoryItem;
        }

        public void RemoveItem() {
            Item = null;
        }
    }
}