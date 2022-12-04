using Cysharp.Threading.Tasks;
using Example2D.Common.Runtime.Utils;
using Example2D.CreepyAlchemist.Runtime.Configs;
using Example2D.CreepyAlchemist.Runtime.Signals.Common;
using Example2D.CreepyAlchemist.Runtime.States;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Bootstrap {
    public class BootstrapController : MonoBehaviour {

        private SignalBus _signalBus;
        private ConfigsController _configsController;
        private StatesController _statesController;
        private SceneController _sceneController;

        private float _loadingProgress;

        [Inject]
        private void Construct(SignalBus signalBus,
            ConfigsController configsController,
            StatesController statesController,
            SceneController sceneController) {
            _signalBus = signalBus;
            _configsController = configsController;
            _statesController = statesController;
            _sceneController = sceneController;
        }

        private void Start() {
            Load();
        }

        private async void Load() {
            Logs.Log($"Your unique id: {SystemInfo.deviceUniqueIdentifier}");
            _loadingProgress = 0f;

            Logs.Log($"Loading configs...");
            await UniTask.WaitUntil(() => _configsController.IsLoaded);
            Logs.Log($"Configs have been loaded.");
            AddProgress(0.1f);

            Logs.Log($"Loading states...");
            await UniTask.WaitUntil(() => _statesController.IsLoaded);
            Logs.Log($"States have been loaded.");
            AddProgress(0.1f);

            Logs.Log($"Loading scenes...");
            bool scenesLoaded = false;
            _sceneController.LoadCore(() => {
                _sceneController.LoadGameplay(() => {
                    scenesLoaded = true;
                });
            });
            await UniTask.WaitUntil(() => scenesLoaded);
            Logs.Log($"Scenes have been loaded");
            AddProgress(0.1f);

            Logs.Log($"Loading is complete!");
            AddProgress(1f);
        }

        private void AddProgress(float amount) {
            _loadingProgress = Mathf.Clamp01(_loadingProgress + amount);
            _signalBus.Fire(new SignalBootstrapLoadingProgressChanged(_loadingProgress));
        }
	}
}