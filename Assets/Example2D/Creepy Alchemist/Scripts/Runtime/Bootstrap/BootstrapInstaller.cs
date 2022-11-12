using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Bootstrap
{
	public class BootstrapInstaller : MonoInstaller {
        [SerializeField] private SceneController _sceneController;

        public override void InstallBindings() {
            Container.Bind<SceneController>().FromComponentInNewPrefab(_sceneController).AsSingle();
        }
    }
}