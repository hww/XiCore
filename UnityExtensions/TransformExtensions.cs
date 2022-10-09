/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

using UnityEngine;

namespace XiCore.UnityExtensions
{
    public static class TransformExtensions 
    {
        public static Transform DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            return transform;
        }
        
        public static Transform DestroyImmediateAllChildren(this Transform transform)
        {
            foreach (Transform child in transform) {
                GameObject.DestroyImmediate(child.gameObject);
            }
            return transform;
        }
        
        /// <summary>
        /// Get game object path
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public static string GetFullPath(this Transform transform)
        {
            string path = transform.name;
            while (transform.parent != null)
            {
                transform = transform.parent;
                path = transform.name + "/" + path;
            }
            return path;
        }
        
        /// <summary>
        /// Get game object path
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public static string GetFullPath(this GameObject go)
        {
            return GetFullPath(go.transform);
        }
    }
}
