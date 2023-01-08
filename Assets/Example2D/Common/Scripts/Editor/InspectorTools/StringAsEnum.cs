using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Example2D.Common.Editor.InspectorTools {
    [CustomPropertyDrawer(typeof(StringAsEnumAttribute))]
    public class StringAsEnum : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            var attr = attribute as StringAsEnumAttribute;
            var staticProp = attr.Type.GetProperty(attr.PropName);

            if (staticProp == null) {
                EditorGUI.HelpBox(position, "Attribute values null or empty!", MessageType.Error);
                EditorGUI.PropertyField(position, property);
                return;
            }

            var values = staticProp.GetValue(attr.Type) as string[];

            int index = 0;
            bool hasMatch = false;
            for (int i = 0; i < values.Length; i++) {
                if (values[i] == property.stringValue) {
                    index = i;
                    hasMatch = true;
                    break;
                }
            }

            if (!hasMatch) {
                EditorGUI.HelpBox(position, "Entry not found!", MessageType.Error);
                EditorGUI.PropertyField(position, property);
                return;
            }

            index = EditorGUI.Popup(position, index, values);
            property.stringValue = values[index];
        }
    }

    public class StringAsEnumAttribute : PropertyAttribute {

        public Type Type { get; private set; }
        public string PropName { get; private set; }

        public StringAsEnumAttribute(Type type, string propName) {
            Type = type;
            PropName = propName;
        }
    }
}