// =============================================================================
// Generic pool class
// Author: Suleyman Yasir Kula
// Feel free to use/upgrade
// =============================================================================

using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace XiCore.DataStructures
{
	
	/// <summary>
	/// Single pool for type T
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GenericPool<T> where T : class
	{
		/// <summary>
		/// Objects stored in the pool
		/// </summary>
		private readonly Stack<T> pool;

		/// <summary>
		/// Blueprint to use for instantiation
		/// </summary>
		public T Blueprint { get; set; }

		/// <summary>
		/// A function that can be used to override default NewObject( T ) function
		/// </summary>
		public Func<T, T> CreateFunction;

		/// <summary>
		/// Actions that can be used to implement extra logic on pushed/popped objects
		/// </summary>
		public Action<T> OnPush, OnPop;

		// =============================================================================================================
		// Constructors
		// =============================================================================================================
		
		/// <summary>
		/// Generic pool constructor
		/// </summary>
		/// <param name="CreateFunction">Delegate, constructor of object T</param>
		/// <param name="OnPush">Callback on push method</param>
		/// <param name="OnPop">Call back on pop method</param>
		public GenericPool( Func<T, T> CreateFunction = null, Action<T> OnPush = null, Action<T> OnPop = null )
		{
			pool = new Stack<T>();

			this.CreateFunction = CreateFunction;
			this.OnPush = OnPush;
			this.OnPop = OnPop;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="blueprint">Object prototype</param>
		/// <param name="CreateFunction">Delegate, constructor of object T</param>
		/// <param name="OnPush">Callback on push method</param>
		/// <param name="OnPop">Call back on pop method</param>
		public GenericPool( T blueprint, Func<T, T> CreateFunction = null, Action<T> OnPush = null, Action<T> OnPop = null )
			: this( CreateFunction, OnPush, OnPop )
		{
			// Set the blueprint at creation
			Blueprint = blueprint;
		}

		// =============================================================================================================
		// Other methods
		// =============================================================================================================

		/// <summary>
		/// Populate the pool with the default blueprint
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public bool Populate( int count )
		{
			return Populate( Blueprint, count );
		}

		/// <summary>
		/// Populate the pool with a specific blueprint
		/// </summary>
		/// <param name="blueprint"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public bool Populate( T blueprint, int count )
		{
			if( count <= 0 )
				return true;

			// Create a single object first to see if everything works fine
			// If not, return false
			T obj = NewObject( blueprint );
			if( obj == null )
				return false;

			Push( obj );

			// Everything works fine, populate the pool with the remaining items
			for( int i = 1; i < count; i++ )
			{
				Push( NewObject( blueprint ) );
			}

			return true;
		}

		/// <summary>
		/// Fetch an item from the pool 
		/// </summary>
		/// <returns></returns>
		public T Pop()
		{
			T objToPop;

			if( pool.Count == 0 )
			{
				// Pool is empty, instantiate the blueprint
				objToPop = NewObject( Blueprint );
			}
			else
			{
				// Pool is not empty, fetch the first item in the pool
				objToPop = pool.Pop();
				while( objToPop == null )
				{
					// Some objects in the pool might have been destroyed (maybe during a scene transition),
					// consider that case
					if( pool.Count > 0 )
						objToPop = pool.Pop();
					else
					{
						objToPop = NewObject( Blueprint );
						break;
					}
				}
			}

			if( OnPop != null )
				OnPop( objToPop );

			return objToPop;
		}

		/// <summary>
		/// Fetch multiple items at once from the pool
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public T[] Pop( int count )
		{
			if( count <= 0 )
				return new T[0];

			T[] result = new T[count];
			for( int i = 0; i < count; i++ )
				result[i] = Pop();

			return result;
		}

		/// <summary>
		/// Pool an item
		/// </summary>
		/// <param name="obj"></param>
		public void Push( T obj )
		{
			if( obj == null ) return;

			if( OnPush != null )
				OnPush( obj );

			pool.Push( obj );
		}

		/// <summary>
		/// Pool multiple items at once
		/// </summary>
		/// <param name="objects"></param>
		public void Push( IEnumerable<T> objects )
		{
			if( objects == null ) return;

			foreach( T obj in objects )
				Push( obj );
		}

		/// <summary>
		/// Clear the pool
		/// </summary>
		/// <param name="destroyObjects"></param>
		public void Clear( bool destroyObjects = true )
		{
			if( destroyObjects )
			{
				// Destroy all the Objects in the pool
				foreach( T item in pool )
				{
					Object.Destroy( item as Object );
				}
			}

			pool.Clear();
		}

		/// <summary>
		/// Create an instance of the blueprint and return it
		/// </summary>
		/// <param name="blueprint"></param>
		/// <returns></returns>
		private T NewObject( T blueprint )
		{
			if( CreateFunction != null )
				return CreateFunction( blueprint );

			if( blueprint == null || !( blueprint is Object ) )
				return null;

			return Object.Instantiate( blueprint as Object ) as T;
		}
	}
}