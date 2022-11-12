using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.States {
	public class StatesInstaller : MonoInstaller {

        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<StatesController>().AsSingle();
        }
    }
}