using UnityEditor;
using UnityEngine;

namespace XiCore.Fields.Editor
{
    [CustomPropertyDrawer(typeof(VariaticFloat))]
    public class VariaticFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var drawerWidth = position.width;
            var lableWidth = EditorGUIUtility.labelWidth;
            var singleColumnWidth = drawerWidth - lableWidth;
            var twoColumnsWith = singleColumnWidth / 2;
            var twoColumnsLabelWidth = twoColumnsWith / 2;
            var twoColumnsValueWidth = twoColumnsWith - twoColumnsLabelWidth;
            var valueProperty = property.FindPropertyRelative("value");
            var rangeProperty = property.FindPropertyRelative("range");
            var value = valueProperty.floatValue;
            var range = rangeProperty.floatValue;
            
            var rangeAttrs = fieldInfo.GetCustomAttributes(typeof(RangeAttribute), true);
            if (rangeAttrs.Length > 0)
            {
                var rangeAttr = (RangeAttribute) rangeAttrs[0];
                var minLimit = rangeAttr.min;
                var maxLimit = rangeAttr.max;
                
                position = EditorGUI.PrefixLabel(position, label);
                
                //EditorGUIUtility.labelWidth = smallLabelWidth;
                //position.width = smallColumnWidth;
                //EditorGUI.LabelField(position, "Value:", value.ToString());
                //position.x += smallColumnWidth;
                //EditorGUI.LabelField(position, "Range:", range.ToString());

                //position.y += base.GetPropertyHeight(property, label);

                // --------------------------------------------------------------
                position.x = lableWidth;
                EditorGUIUtility.labelWidth = twoColumnsLabelWidth;
                EditorGUI.LabelField(position, "Value:");
                position.x += twoColumnsLabelWidth;
                position.width = singleColumnWidth - twoColumnsLabelWidth;
                position.height = EditorGUIUtility.singleLineHeight;
                value = EditorGUI.Slider(position, value, minLimit, maxLimit);
                // --------------------------------------------------------------
                position.x = lableWidth;
                position.y += EditorGUIUtility.singleLineHeight;
                // --------------------------------------------------------------
                EditorGUIUtility.labelWidth = twoColumnsLabelWidth;
                EditorGUI.LabelField(position, "Range:");
                position.x += twoColumnsLabelWidth;
                position.width = singleColumnWidth - twoColumnsLabelWidth;
                range = EditorGUI.Slider(position, range, minLimit, maxLimit);
                valueProperty.floatValue = value;
                rangeProperty.floatValue = range;
            }
            else
            {   
                var minLimit = int.MinValue;
                var maxLimit = int.MaxValue;
                position = EditorGUI.PrefixLabel(position, label);
                EditorGUIUtility.labelWidth = twoColumnsLabelWidth;
                position.width = twoColumnsWith - 10;
                EditorGUI.PropertyField(position, valueProperty, new GUIContent("Value"));
                position.x += twoColumnsWith + 10;
                EditorGUI.PropertyField(position, rangeProperty, new GUIContent("Range"));

                valueProperty.floatValue = Mathf.Clamp(valueProperty.floatValue, minLimit, maxLimit);
                rangeProperty.floatValue = Mathf.Clamp(rangeProperty.floatValue, minLimit, maxLimit);

            }
            EditorGUIUtility.labelWidth = 0;
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var rangeAttrs = fieldInfo.GetCustomAttributes(typeof(RangeAttribute), true);
            if (rangeAttrs.Length > 0)
                return base.GetPropertyHeight(property, label) * 2;
            else
                return base.GetPropertyHeight(property, label);
        }
    }
}