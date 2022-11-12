using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Bootstrap {
	public class SceneController : MonoBehaviour {
        [Header("Core")]
        [SerializeField] private AssetReference preloader;
        [SerializeField] private AssetReference core;
        [SerializeField] private AssetReference coreUi;
        [Header("Gameplay")]
        [SerializeField] private AssetReference gameplay;
        [SerializeField] private AssetReference gameplayUi;
        [Header("Audio")]
        [SerializeField] private new AssetReference audio;


        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus) {
            _signalBus = signalBus;
        }

        public void LoadPreloader() {

        }

        private void LoadScene(AssetReference asset, LoadSceneMode mode = LoadSceneMode.Additive) {
            var hanlder = asset.LoadSceneAsync(mode);
        }
	}
}