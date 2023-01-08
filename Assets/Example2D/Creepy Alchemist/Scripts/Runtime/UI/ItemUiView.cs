using Example2D.Common.Runtime.Core.Inventory;
using Example2D.Common.Runtime.UI.Drag;
using Example2D.CreepyAlchemist.Runtime.Gameplay.Model;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class ItemUiView : MonoBehaviour, IDraggable {
        public class Pool : MonoMemoryPool<IInventoryItem, Transform, ItemUiView> {
            protected override void Reinitialize(IInventoryItem itemModel, Transform parent, ItemUiView item) {
                item.Reset(itemModel, parent);
            }
        }

        public bool IsScreenObj => true;
        public Transform Transform => transform;
        public GameObject GameObject => gameObject;

        [SerializeField] private GameObject visualRoot;
        [SerializeField] private Image icon;

        private ItemModel _itemModel;

        public event Action OnDrag;
        public event Action<bool> OnDrop;

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
            icon.sprite = _itemModel.ItemSO.UiIcon;
            transform.SetParent(parent);
        }

        public void HandleDrag() {
            OnDrag?.Invoke();
        }

        public void HandleDrop(bool result) {
            OnDrop?.Invoke(result);
        }

        public IDraggable InstantiateScreenDraggable(Transform parent) {
            return this;
        }
    }
}