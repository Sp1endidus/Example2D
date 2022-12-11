using Example2D.Common.Runtime.Signals;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class CanvasController : MonoBehaviour {
        [SerializeField] private Canvas canvas;

        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus) {
            _signalBus = signalBus;
        }

        private void OnEnable() {
            _signalBus.Fire(new SignalCanvasStateChanged(canvas, true));
        }

        private void OnDisable() {
            _signalBus.Fire(new SignalCanvasStateChanged(canvas, false));
        }
    }
}