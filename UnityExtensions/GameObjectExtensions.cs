/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

using UnityEngine;

namespace XiCore.UnityExtensions

{
    public static class GameObjectExtensions
    {

        /// <summary>
        /// Get component if it is exists or create new
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrAddComponent<T>(this GameObject self) where T : Component
        {
            var comp = self.GetComponent<T>();
            if (comp == null)
                comp = self.AddComponent<T>();
            return comp;
        }
        
        /// <summary>
        /// Checks if a GameObject has been destroyed.
        /// </summary>
        /// <param name="gameObject">GameObject reference to check for destructed</param>
        /// <returns>If the game object has been marked as destroyed by UnityEngine</returns>
        public static bool IsDestroyed(Object gameObject)
        {
            // UnityEngine overloads the == operator for the GameObject type
            // and returns null when the object has been destroyed, but 
            // actually the object is still there but has not been cleaned up yet
            // if we test both we can determine if the object has been destroyed.
            return gameObject == null && !ReferenceEquals(gameObject, null);
        }
     
        /// <summary>
        /// Set layer to given value
        /// </summary>
        /// <param name="layer"></param>
        public static void SetLayer(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
        }
    }
}