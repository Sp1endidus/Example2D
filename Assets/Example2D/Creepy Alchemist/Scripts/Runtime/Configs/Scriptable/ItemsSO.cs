using Example2D.Common.Editor.InspectorTools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example2D.CreepyAlchemist.Runtime.Configs.Scriptable {
    [CreateAssetMenu(fileName = "Items Settings", menuName = "Example2D/Creepy Alchemist/Items Settings")]
	public class ItemsSO : ScriptableObject {
        [SerializeField] private List<ItemSO> items;

        public List<ItemSO> Items => items;
    }

    [Serializable]
    public class ItemSO {
        [SerializeField]
        [StringAsEnum(typeof(EditorConfigsController), "ItemIds")]
        private string id;
        [SerializeField] private Sprite uiIcon;

        public string Id => id;
        public Sprite UiIcon => uiIcon;
    }
}