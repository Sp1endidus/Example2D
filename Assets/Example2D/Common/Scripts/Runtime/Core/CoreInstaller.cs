using Example2D.Common.Runtime.Core.Inventory;
using Zenject;

namespace Example2D.Common.Runtime {
    public class CoreInstaller : MonoInstaller {

        public override void InstallBindings() {
            Container.Bind<InventoryController>().AsSingle();
        }
    }
}