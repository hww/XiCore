// =============================================================================
// MIT License
// 
// Copyright (c) 2018 Valeriya Pudova (hww.github.io)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// =============================================================================

#if UNITY_EDITOR

#endif

namespace XiCore
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