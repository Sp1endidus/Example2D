using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Example2D.Common.Runtime.UI.Drag {
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

        private IDraggable _draggable;
        private DragController _dragController;

        private void Start () {
            _draggable = GetComponent<IDraggable>();
            _dragController = FindObjectOfType<DragController>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            _dragController.HandleBeginDrag(eventData, _draggable);
        }

        public void OnDrag(PointerEventData eventData) {
            _dragController.HandleDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData) {
            _dragController.HandleEndDrag(eventData);
        }
	}

    public interface IDraggable {
        bool IsScreenObj { get; }
        string ScreenPrefabPath { get; }
        Transform Transform { get; }
        GameObject GameObject { get; }
        bool CanBeginDrag { get; }
        void Hide();
        void Show();
        void HandleDrag();
        void HandleDrop();
        event Action OnDrag;
        event Action OnDrop;
    }
}