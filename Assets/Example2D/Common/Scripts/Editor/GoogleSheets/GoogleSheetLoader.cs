using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Google.Apis.Sheets.v4;
using Codice.Client.BaseCommands.BranchExplorer;

namespace Example2D.Common.Editor.Googlesheets {
    public static class GoogleSheetLoader {
        private static SpreadsheetLoader _spreadsheetLoader = new SpreadsheetLoader();

        public static void Open(GoogleSpreadsheetData spreadsheetData, string name) {
            foreach (var sheet in spreadsheetData.Sheets) {
                if (sheet.Name == name) {
                    Open(spreadsheetData, sheet);
                }
            }
        }

        public static void Open(GoogleSpreadsheetData spreadsheetData, GoogleSheetData sheetData) {
            Open(spreadsheetData.SpreadsheetId, sheetData.SheetId);
        }

        public static void Open(string spreadsheetId, int sheetId) {
            Application.OpenURL($"https://docs.google.com/spreadsheets/d/{spreadsheetId}/#gid={sheetId}");
        }

        public static void Open(string spreadsheetId) {
            Application.OpenURL($"https://docs.google.com/spreadsheets/d/{spreadsheetId}");
        }

        public static void Pull(GoogleSheetSettings settings, string name) {
            foreach (var config in settings.Configs) {
                if (config.Name == name) {
                    SaveSheetToJsonFile(config, settings.ConfigsRoot);
                    return;
                }
            }
        }

        public static void Pull(GoogleSheetSettings settings, int index) {
            SaveSheetToJsonFile(settings.Configs[index], settings.ConfigsRoot);
        }

        public static void Pull(GoogleSheetSettings settings) {
            foreach (var config in settings.Configs) {
                SaveSheetToJsonFile(config, settings.ConfigsRoot);
            }
        }

        private static void SaveSheetToJsonFile(GoogleSpreadsheetData data, string configsPath) {
            foreach (var itemSheet in data.Sheets) {
                var parser = GetSpreadsheetParser(itemSheet.Parser);
                var sheetData = _spreadsheetLoader.Load(parser, data.SpreadsheetId,
                    itemSheet.SheetId, itemSheet.Range);
                SaveConfigFile(Path.Combine(configsPath, data.Name, $"{itemSheet.Name}.json"), sheetData);
            }
        }

        private static ISpreadsheetParser GetSpreadsheetParser(SpreadsheetParserType parserType) {
            var targetType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => typeof(ISpreadsheetParser).IsAssignableFrom(x)
                && !x.IsInterface && !x.IsAbstract
                && x.GetCustomAttribute<ParserTypeAttribute>()?.ParserType == parserType);

            if (targetType != null) {
                return Activator.CreateInstance(targetType) as ISpreadsheetParser;
            }

            return null;
        }

        private static void SaveConfigFile(string configPath, string configData) {
            File.WriteAllText(configPath, configData);
            AssetDatabase.Refresh();
        }
    }
}