using System.Linq;

namespace Example2D.CreepyAlchemist.Runtime.Configs {
    public static class EditorConfigsController {
        private static ConfigsController _configsController;
        public static ConfigsController ConfigsController {
            get {
                if (_configsController == null) {
                    _configsController = new ConfigsController();
                    _configsController.Initialize();
                }

                return _configsController;
            }
        }

        public static void Reset() {
            _configsController = null;
        }

        public static string[] ItemIds {
            get {
                return ConfigsController.Gameplay.Items.Keys.ToArray();
            }
        }
    }
}