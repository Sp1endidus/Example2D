using Example2D.CreepyAlchemist.Runtime.UI.Common;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class InventoryCellUiView : MonoBehaviour {
        [SerializeField] private DropReceiver dropReceiver;

        private IDraggable _currentDraggable;

        private void Start() {
            dropReceiver.Initialize(CanReceive, Receive);
        }

        private bool CanReceive(IDraggable draggable) {
            return _currentDraggable == null;
        }

        private void Receive(IDraggable draggable, Vector2 position) {
            _currentDraggable = draggable;
            _currentDraggable.Transform.SetParent(transform);
            ((RectTransform)_currentDraggable.Transform).anchoredPosition = Vector3.zero;
        }
    }
}