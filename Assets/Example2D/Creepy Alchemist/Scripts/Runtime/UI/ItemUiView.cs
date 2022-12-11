using Example2D.Common.Runtime.Core.Inventory;
using Example2D.Common.Runtime.UI.Drag;
using Example2D.CreepyAlchemist.Runtime.Gameplay.Model;
using System;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class ItemUiView : MonoBehaviour, IDraggable {
        public class Pool : MonoMemoryPool<IInventoryItem, Transform, ItemUiView> {
            protected override void Reinitialize(IInventoryItem itemModel, Transform parent, ItemUiView item) {
                item.Reset(itemModel, parent);
            }
        }

        public bool IsScreenObj => true;
        public string ScreenPrefabPath => "";
        public Transform Transform => transform;
        public GameObject GameObject => gameObject;

        [SerializeField] private GameObject visualRoot;

        private ItemModel _itemModel;

        public event Action OnDrag;
        public event Action OnDrop;

        public bool CanBeginDrag {
            get {
                return true;
            }
        }

        [Inject]
        public void Construct() {

        }

        public void Hide() {
            visualRoot.SetActive(false);
        }

        public void Show() {
            visualRoot.SetActive(true);
        }

        public void Reset(IInventoryItem itemModel, Transform parent) {
            _itemModel = itemModel as ItemModel;
            transform.SetParent(parent);
        }

        public void HandleDrag() {
            OnDrag?.Invoke();
        }

        public void HandleDrop() {
            OnDrop?.Invoke();
        }
    }
}