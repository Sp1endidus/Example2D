using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Example2D.Common.Runtime.Utils {
	public static class InstantiateController {

        public static T InstantiateComponent<T>(string addressablePath,
            Transform parent) where T : Component {
            return InstantiateGameObject(addressablePath, parent).GetComponent<T>();
        }

        public static GameObject InstantiateGameObject(string addressablePath,
            Transform parent) {
            var asyncOperation = Addressables.InstantiateAsync(addressablePath, parent);
            return asyncOperation.WaitForCompletion();
        }

        public static void InstantiateGameObject(string addressablePath,
            Transform parent, Action<GameObject> callback = null) {
            var asyncOperation = Addressables.InstantiateAsync(addressablePath, parent);
            asyncOperation.Completed += result => {
                callback(result.Result);
            };
        }

        public static void InstantiateComponent<T>(string addressablePath,
            Transform parent, Action<T> callback = null) where T : Component {
            var asyncOperation = Addressables.InstantiateAsync(addressablePath, parent);
            asyncOperation.Completed += result => {
                callback(result.Result.GetComponent<T>());
            };
        }

        public static T LoadAsset<T>(string addressablePath) {
            var asyncOperation = Addressables.LoadAssetAsync<T>(addressablePath);
            return asyncOperation.WaitForCompletion();
        }

        public static void LoadAssetAsync<T>(string addressablePath,
            Action<T> callback) {
            var asyncOperation = Addressables.LoadAssetAsync<T>(addressablePath);
            asyncOperation.Completed += result => {
                callback(result.Result);
            };
        }

        public static bool AssetExists(object key, Type type) {
            foreach (var locator in Addressables.ResourceLocators) {
                if (locator.Locate(key, type, out var locs))
                    return true;
            }
            return false;
        }
    }
}