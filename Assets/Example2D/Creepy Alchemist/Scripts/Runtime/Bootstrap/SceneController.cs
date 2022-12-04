using System;
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

        public void LoadCore(Action callback) {
            LoadScene(core, () => {
                LoadScene(coreUi, callback);
            });
        }

        public void LoadGameplay(Action callback) {
            LoadScene(gameplay, () => {
                LoadScene(gameplayUi, callback);
            });
        }

        private void LoadScene(AssetReference asset, Action callback = null,
            LoadSceneMode mode = LoadSceneMode.Additive) {
            var handler = asset.LoadSceneAsync(mode);
            if (callback != null) {
                handler.Completed += result => {
                    callback();
                };
            }
        }
	}
}