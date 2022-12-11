using UnityEngine;

namespace Example2D.Common.Runtime.Signals {
    public readonly struct SignalCanvasStateChanged {
        public readonly Canvas Canvas;
        public readonly bool Enabled;

        public SignalCanvasStateChanged(Canvas canvas, bool enabled) {
            Canvas = canvas;
            Enabled = enabled;
        }
    }
}