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

namespace XiCore.DataStructures
{
	using System.Collections.Generic;

	/// <summary>
	/// Allow to manager multiple named pools of same type.
	/// </summary>
	public static class GenericPoolManager
	{
		/// <summary>
		/// Pool container for given type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		private static class PoolsOfType<T> where T : class
		{
			/// <summary>
			/// Pool with poolName = null
			/// </summary>
			private static GenericPool<T> defaultPool;

			/// <summary>
			/// Named pools
			/// </summary>
			private static Dictionary<string, GenericPool<T>> namedPools;

			/// <summary>
			/// Get pool for type T and given poolName (*optional)
			/// 
			/// NOTE: The argument poolName equal null will be more performance
			/// efficient.
			/// </summary>
			/// <param name="poolName"></param>
			/// <returns></returns>
			public static GenericPool<T> GetPool( string poolName = null )
			{
				if( poolName == null )
				{
					if( defaultPool == null )
						defaultPool = new GenericPool<T>();

					return defaultPool;
				}
				else
				{
					GenericPool<T> result;

					if( namedPools == null )
					{
						namedPools = new Dictionary<string, GenericPool<T>>();

						result = new GenericPool<T>();
						namedPools.Add( poolName, result );
					}
					else if( !namedPools.TryGetValue( poolName, out result ) )
					{
						result = new GenericPool<T>();
						namedPools.Add( poolName, result );
					}

					return result;
				}
			} 
		}

		/// <summary>
		/// NOTE: if you don't need two or more pools of same type,
		/// leave poolName as null for better performance
		/// </summary>
		/// <param name="poolName"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static GenericPool<T> GetPool<T>( string poolName = null ) where T : class
		{
			return PoolsOfType<T>.GetPool( poolName );
		}

		/// <summary>
		/// NOTE: if you don't need two or more pools of same type,
		/// leave poolName as null for better performance
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="poolName"></param>
		/// <typeparam name="T"></typeparam>
		public static void Push<T>( T obj, string poolName = null ) where T : class
		{
			PoolsOfType<T>.GetPool( poolName ).Push( obj );
		}

		/// <summary>
		/// NOTE: if you don't need two or more pools of same type,
		/// leave poolName as null for better performance
		/// </summary>
		/// <param name="poolName"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Pop<T>( string poolName = null ) where T : class
		{
			return PoolsOfType<T>.GetPool( poolName ).Pop();
		}

		/// <summary>
		/// Extension method as a shorthand for Push function
		/// 
		/// NOTE: if you don't need two or more pools of same type,
		/// leave poolName as null for better performance
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="poolName"></param>
		/// <typeparam name="T"></typeparam>
		public static void Pool<T>( this T obj, string poolName = null ) where T : class
		{
			PoolsOfType<T>.GetPool( poolName ).Push( obj );
		}
	}

}
