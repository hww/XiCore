using UnityEditor;
using UnityEngine;

namespace XiCore.Fields.Editor
{
    [CustomPropertyDrawer(typeof(RandomFloat))]
    public class FloatRangeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var drawerWidth = position.width;
            var lableWidth = EditorGUIUtility.labelWidth;
            var columnWidth = drawerWidth - lableWidth;
            var smallColumnWidth = columnWidth / 2;
            var smallLabelWidth = smallColumnWidth / 2;

            var minProperty = property.FindPropertyRelative("min");
            var maxProperty = property.FindPropertyRelative("max");
            var min = minProperty.floatValue;
            var max = maxProperty.floatValue;
            
            var rangeAttrs = fieldInfo.GetCustomAttributes(typeof(RangeAttribute), true);
            if (rangeAttrs.Length > 0)
            {
                var rangeAttr = (RangeAttribute) rangeAttrs[0];
                var minLimit = rangeAttr.min;
                var maxLimit = rangeAttr.max;
                
                position = EditorGUI.PrefixLabel(position, label);
                
                EditorGUIUtility.labelWidth = smallLabelWidth;
                position.width = smallColumnWidth;
                EditorGUI.LabelField(position, "Min:", min.ToString());
                position.x += smallColumnWidth;
                EditorGUI.LabelField(position, "Max:", max.ToString());

                position.y += base.GetPropertyHeight(property, label);

                position.x = lableWidth;
                position.width = columnWidth;
                EditorGUI.MinMaxSlider(position, ref min, ref max, minLimit, maxLimit);
                minProperty.floatValue = min;
                maxProperty.floatValue = max;
            }
            else
            {   
                var minLimit = int.MinValue;
                var maxLimit = int.MaxValue;
                position = EditorGUI.PrefixLabel(position, label);
                EditorGUIUtility.labelWidth = smallLabelWidth;
                position.width = smallColumnWidth;
                EditorGUI.PropertyField(position, minProperty, new GUIContent("Min"));
                position.x += position.width + 10;
                EditorGUI.PropertyField(position, maxProperty, new GUIContent("Max"));

                minProperty.floatValue = Mathf.Clamp(minProperty.floatValue, minLimit, maxLimit);
                maxProperty.floatValue = Mathf.Clamp(maxProperty.floatValue, minLimit, maxLimit);

                if (minProperty.floatValue > maxProperty.floatValue)
                    maxProperty.floatValue = minProperty.floatValue;

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