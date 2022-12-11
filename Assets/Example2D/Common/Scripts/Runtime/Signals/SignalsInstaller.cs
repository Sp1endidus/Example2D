using Example2D.Common.Runtime.Signals;
using Zenject;

namespace Example2D.Common.Runtime {
    public class SignalsInstaller : MonoInstaller {

        public override void InstallBindings() {
            SignalBusInstaller.Install(Container);

            DeclareUI();
        }

        private void DeclareUI() {
            Container.DeclareSignal<SignalCanvasStateChanged>();
        }
    }
}