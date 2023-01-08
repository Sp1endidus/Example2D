using Example2D.Common.Runtime.UI.Drag;
using Example2D.Common.Runtime.Utils;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class CellUiView : MonoBehaviour {
        [SerializeField] private DropReceiver dropReceiver;

        private IDraggable _currentDraggable;
        private bool _draggedOut;

        private void Start() {
            dropReceiver.Initialize(CanReceive, Receive);
        }

        private bool CanReceive(IDraggable draggable) {
            return _currentDraggable == null;
        }

        public void Receive(IDraggable draggable, Vector2 position) {
            _currentDraggable = draggable;
            _currentDraggable.Transform.SetParent(transform);
            ((RectTransform)_currentDraggable.Transform).anchoredPosition = Vector3.zero;
            _currentDraggable.OnDrag += ItemDrag;
            _currentDraggable.OnDrop += ItemDrop;
        }

        private void ItemDrag() {
            _draggedOut = true;
        }

        private void ItemDrop(bool result) {
            if (!_draggedOut || !result) {
                return;
            }

            _currentDraggable.OnDrag -= ItemDrag;
            _currentDraggable.OnDrop -= ItemDrop;
            _currentDraggable = null;
            _draggedOut = false;
        }
    }
}