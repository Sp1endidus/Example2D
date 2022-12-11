using Example2D.CreepyAlchemist.Runtime.Gameplay.Model;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Gameplay {
    public class GameplayInstaller : MonoInstaller {

        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<GameplayController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ItemsController>().AsSingle();

            Container.BindMemoryPool<ItemModel, ItemModel.Pool>()
                .WithInitialSize(15);
            Container.BindMemoryPool<InventoryCellModel, InventoryCellModel.Pool>()
                .WithInitialSize(15);
        }
    }
}