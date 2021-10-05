using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ImageHeaderAttribute : Attribute
{

    public string AssetPath { get; private set; }

    public ImageHeaderAttribute(string assetPath)
    {
        this.AssetPath = assetPath;
    }
}

#if UNITY_EDITOR_WITH_ODIN
[OdinDrawer]
[DrawerPriority(0.2, 0, 0)]
public class ImageHeaderAttributeDrawer : OdinAttributeDrawer<ImageHeaderAttribute>
{
    protected override void DrawPropertyLayout(InspectorProperty property, ImageHeaderAttribute attribute, GUIContent label)
    {

        PropertyContext<Texture> texture;

        if (property.Context.Get(this, "texture", out texture))
        {
            texture.Value = AssetDatabase.LoadAssetAtPath<Texture>(attribute.AssetPath);
        }

        GUILayout.Label(texture.Value, EditorStyles.centeredGreyMiniLabel);
        this.CallNextDrawer(property, label);

    }
}
#endif