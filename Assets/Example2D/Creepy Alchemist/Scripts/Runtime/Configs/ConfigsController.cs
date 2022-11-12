using Example2D.Common.Runtime.Utils;
using Example2D.CreepyAlchemist.Runtime.Configs.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Example2D.CreepyAlchemist.Runtime.Configs {
    public class ConfigsController : IInitializable {
        public GameplayConfigsController Gameplay { get; private set; }

        public bool IsLoaded { get; private set; }

        public void Initialize() {
            Logs.Log($"Initialize configs...");
            Gameplay = new GameplayConfigsController();
            Gameplay.Initialize();

            IsLoaded = true;
        }
    }
}