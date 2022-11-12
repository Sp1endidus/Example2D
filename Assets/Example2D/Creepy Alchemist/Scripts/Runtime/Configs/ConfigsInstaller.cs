using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Configs {
	public class ConfigsInstaller : MonoInstaller {

        public override void InstallBindings() {
            Container.BindInitializableExecutionOrder<ConfigsController>(-100);
            Container.BindInterfacesAndSelfTo<ConfigsController>().AsSingle();
        }
    }
}