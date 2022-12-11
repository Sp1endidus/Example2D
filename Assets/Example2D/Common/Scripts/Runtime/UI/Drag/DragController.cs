using Example2D.Common.Runtime.Signals;
using Example2D.Common.Runtime.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Example2D.Common.Runtime.UI.Drag {
    public class DragController : MonoBehaviour {
        [SerializeField] private Transform draggableParent;

        private List<GraphicRaycaster> _graphicRaycasters = new List<GraphicRaycaster>(2);
        private List<Physics2DRaycaster> _physics2DRaycasters = new List<Physics2DRaycaster>(2);
        List<RaycastResult> _raycastResults = new List<RaycastResult>(10);


        private IDraggable _sourceDraggable;
        private IDraggable _screenDraggable;

        private Transform _originalParent;
        private Vector2 _originalPosition;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus) {
            _signalBus = signalBus;

            _signalBus.Subscribe<SignalCanvasStateChanged>(OnCanvasStateChanged);
        }

        private void OnCanvasStateChanged(SignalCanvasStateChanged signal) {
            var gr = signal.Canvas.GetComponent<GraphicRaycaster>();
            if (signal.Enabled) {
                _graphicRaycasters.Add(gr);
            } else if (_graphicRaycasters.Contains(gr)) {
                _graphicRaycasters.Remove(gr);
            }
        }

        public void HandleBeginDrag(PointerEventData eventData, IDraggable draggable) {
            if (!draggable.CanBeginDrag) {
                return;
            }
            _sourceDraggable = draggable;

            if (!draggable.IsScreenObj) {
                _screenDraggable = InstantiateController
                    .InstantiateGameObject(_sourceDraggable.ScreenPrefabPath, draggableParent)
                    .GetComponent<IDraggable>();
                _screenDraggable.Transform.position = _sourceDraggable.Transform.position;
                _sourceDraggable.Hide();
            } else {
                _screenDraggable = _sourceDraggable;
                _originalParent = _screenDraggable.Transform.parent;
                _originalPosition = _screenDraggable.Transform.position;
                _screenDraggable.Transform.SetParent(draggableParent);
            }
            _sourceDraggable.HandleDrag();
        }

        public void HandleDrag(PointerEventData eventData) {
            if (_screenDraggable is null) {
                return;
            }

            _screenDraggable.Transform.position = eventData.pointerCurrentRaycast.screenPosition;
        }

        public void HandleEndDrag(PointerEventData eventData) {
            bool receiveResult = false;
            for (int i = 0; i < _graphicRaycasters.Count; i++) {
                if (_graphicRaycasters[i] == null) {
                    continue;
                }

                _raycastResults.Clear();
                _graphicRaycasters[i].Raycast(eventData, _raycastResults);
                receiveResult = TryReceive();
                if (receiveResult) {
                    break;
                }
            }

            if (!receiveResult) {
                for (int i = 0; i < _physics2DRaycasters.Count; i++) {
                    if (_physics2DRaycasters[i] == null) {
                        continue;
                    }

                    _raycastResults.Clear();
                    _physics2DRaycasters[i].Raycast(eventData, _raycastResults);
                    receiveResult = TryReceive();
                    if (receiveResult) {
                        break;
                    }
                }
            }

            if (!receiveResult) {
                _sourceDraggable.Transform.position = _originalPosition;
                _sourceDraggable.Transform.SetParent(_originalParent);
            }

            if (!_sourceDraggable.IsScreenObj) {
                Destroy(_screenDraggable.Transform.gameObject);
                _sourceDraggable.Show();
            } else {
            }

            _sourceDraggable.HandleDrop();
            _sourceDraggable = null;
            _screenDraggable = null;
        }

        private bool TryReceive() {
            foreach (var raycastResult in _raycastResults) {
                var dropReceiver = raycastResult.gameObject.GetComponent<DropReceiver>();
                if (dropReceiver != null) {
                    var dropResult = dropReceiver.ReceiveDrop(_sourceDraggable, _screenDraggable.Transform.position);
                    if (dropResult) {
                        return dropResult;
                    }
                }
            }
            return false;
        }
    }
}