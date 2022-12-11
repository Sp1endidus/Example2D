using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.UI {
	public class UIInstaller : MonoInstaller {
        [SerializeField] private GameObject itemUiViewPrefab;

        public override void InstallBindings() {

            Container.BindMemoryPool<ItemUiView, ItemUiView.Pool>()
                .WithInitialSize(5).FromComponentInNewPrefab(itemUiViewPrefab);
        }
    }
}