using System;
using UnityEngine;

namespace Example2D.Common.Runtime.UI.Drag {
    public class DropReceiver : MonoBehaviour {
        public bool Enabled { get; private set; }

        private Func<IDraggable, bool> _canReceiveFunc;
        private Action<IDraggable, Vector2> _receiveAction;

        public void Initialize(Func<IDraggable, bool> canReceiveFunc,
            Action<IDraggable, Vector2> receiveAction) {
            _canReceiveFunc = canReceiveFunc;
            _receiveAction = receiveAction;
            Enabled = true;
        }

        public bool ReceiveDrop(IDraggable draggable, Vector2 position) {
            if (!Enabled) {
                return false;
            }

            if (!_canReceiveFunc(draggable)) {
                return false;
            }

            _receiveAction(draggable, position);
            return true;
        }
    }
}