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

        private float _loadingProgress;

        [Inject]
        private void Construct(SignalBus signalBus,
            ConfigsController configsController,
            StatesController statesController) {
            _signalBus = signalBus;
            _configsController = configsController;
            _statesController = statesController;
        }

        private void Start() {
            Load();
        }

        private async void Load() {
            Logs.Log($"Your unique id: {SystemInfo.deviceUniqueIdentifier}");
            _loadingProgress = 0f;

            Logs.Log($"Loading configs...");
            await UniTask.WaitUntil(() => _configsController.IsLoaded);
            Logs.Log($"Configs are loaded.");
            AddProgress(0.1f);

            Logs.Log($"Loading states...");
            await UniTask.WaitUntil(() => _statesController.IsLoaded);
            Logs.Log($"States are loaded.");
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