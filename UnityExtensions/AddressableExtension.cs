/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

namespace XiCore.UnityExtensions
{
    /// <summary>
    /// https://gametorrahod.com/unity-addressables-7c417e14fe2c
    /// </summary>
    public static class AddressableExtension
    {
        /*
  public static bool IsNullOrEmpty(this AssetReference aref)
  {
      return aref == null || aref.RuntimeKey == Hash128.Parse("");
  }


  /// <summary>
  /// Use addressables in game play mode
  /// </summary>
  /// <returns></returns>
  public static async UniTask<T> LoadAssetX<T>(this AssetReference aref) where T : Object
  {
#if UNITY_EDITOR
      if (!Application.isPlaying)
          return (T)aref.editorAsset;
#endif
      return await aref.LoadAsset<T>();
  }

  /// <summary>
  /// Use addressables in game play mode
  /// </summary>
  /// <param name="key"></param>
  /// <param name="pathForEditor"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static async UniTask<T> LocadAssetX<T>(string key, string pathForEditor) where T : Object
  {
#if UNITY_EDITOR   
      if (!Application.isPlaying)
          return AssetDatabase.LoadAssetAtPath<T>(pathForEditor);
#endif
      return await Addressables.LoadAsset<T>(key);
  }

  /// <summary>
  /// Release the refferenced asset
  /// </summary>
  /// <param name="obj"></param>
  /// <typeparam name="T"></typeparam>
  public static void ReleaseAsset<T>(T obj) where T : Object
  {
      Addressables.ReleaseAsset(obj);
  }

  /// <summary>
  /// Release an nstantiated object
  /// </summary>
  /// <param name="obj"></param>
  /// <typeparam name="T"></typeparam>
  public static void ReleaseInstance<T>(T obj) where T : Object
  {
      Addressables.ReleaseInstance(obj);
  }
  */
    }
}