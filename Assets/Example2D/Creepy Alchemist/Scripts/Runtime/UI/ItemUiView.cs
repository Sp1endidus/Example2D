using Example2D.CreepyAlchemist.Runtime.UI.Common;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.UI {
    public class ItemUiView : MonoBehaviour, IDraggable {
        public bool IsScreenObj => true;
        public string ScreenPrefabPath => "";
        public Transform Transform => transform;
        public GameObject GameObject => gameObject;

        [SerializeField] private GameObject visualRoot;

        public bool CanBeginDrag {
            get {
                return true;
            }
        }

        public void Hide() {
            visualRoot.SetActive(false);
        }

        public void Show() {
            visualRoot.SetActive(true);
        }
    }
}