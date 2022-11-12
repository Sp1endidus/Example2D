using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example2D.Common.Runtime.Utils {
	public static class Logs {
		public static void Log(object message) {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }

        public static void LogWarning(object message) {
#if UNITY_EDITOR
            Debug.LogWarning(message);
#endif
        }

        public static void LogError(object message) {
#if UNITY_EDITOR
            Debug.LogError(message);
#endif
        }
    }
}