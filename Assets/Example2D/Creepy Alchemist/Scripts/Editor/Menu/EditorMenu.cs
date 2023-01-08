using Example2D.Common.Editor.Googlesheets;
using Example2D.CreepyAlchemist.Runtime.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Editor {
    public static class EditorMenu {
        private static readonly string _settingsPath
            = "Assets/Example2D/Creepy Alchemist/Content/Configs/GoogleSheetSettings.asset";
        private static GoogleSheetSettings _settings;
        public static GoogleSheetSettings Settings {
            get {
                if (_settings == null) {
                    _settings = AssetDatabase.LoadAssetAtPath<GoogleSheetSettings>(_settingsPath);
                }
                return _settings;
            }
        }

        private static GoogleSpreadsheetData GetSpreadsheetDataByName(string name) {
            foreach (var config in Settings.Configs) {
                if (config.Name == name) {
                    return config;
                }
            }
            return null;
        }

        [MenuItem("Example2D/CreepyAlchemist/Open/Gameplay")]
        private static void OpenGameplay() {
            EditorUtility.DisplayProgressBar("Opening", "Opening Google Sheet", 0.5f);
            GoogleSheetLoader.Open(GetSpreadsheetDataByName("Gameplay").SpreadsheetId);
            EditorUtility.ClearProgressBar();
        }

        [MenuItem("Example2D/CreepyAlchemist/Pull/Gameplay")]
        private static void PullGameplay() {
            EditorUtility.DisplayProgressBar("Pulling", "Pulling Google Sheet", 0.5f);
            GoogleSheetLoader.Pull(Settings, "Gameplay");
            EditorConfigsController.Reset();
            EditorUtility.ClearProgressBar();

        }
    }
}