using Example2D.CreepyAlchemist.Runtime.Signals.Common;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Signals {
    public class SignalsInstaller : MonoInstaller {

        public override void InstallBindings() {
            DeclareCommon();
        }

        private void DeclareCommon() {
            Container.DeclareSignal<SignalBootstrapLoadingProgressChanged>();
        }
    }
}