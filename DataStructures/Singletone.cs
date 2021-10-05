using UnityEngine;

namespace XiCore.DataStructures
{
	/// <summary>
	/// Singletone pattern based on ScriptableObject class
	/// Try to avoid this pattern, use instead injections
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Singletone<T> : ScriptableObject where T : ScriptableObject
	{
		private static T Instance;
		/// <summary>
		/// Get object of this tipe but select one by name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static T GetInstance(string name) 
		{
			if (!Instance)
			{
				var collection = Resources.FindObjectsOfTypeAll<T>();
				foreach (var element in collection)
				{
					if (element.name != name) continue;
					Instance = element;
					break;
				}
			}

			if (!Instance)
			{
				Instance = CreateInstance<T>();
				Debug.LogWarningFormat("Instantiated clear singletone for { type: {0}, name: {1}", typeof(T).ToString(), name);
			}
			return Instance;
		}
		
	}

}
