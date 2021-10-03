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

using System.Collections.Generic;

namespace XiCore.DataStructures
{
    
    /// <summary>
    /// C# composed container
    /// </summary>
    public class HybridTable<TKey, TValue> where TValue : class, new()
    {
        public HybridTable()
        {      
            Items = new List<TValue>();
            ItemsDictionary = new Dictionary<TKey, int>();
        }
        
        public HybridTable(int capacity)
        {      
            Items = new List<TValue>(capacity);
            ItemsDictionary = new Dictionary<TKey, int>(capacity);
        }
        
        /// <summary>
        /// Get quantity of elements
        /// </summary>
        public int Count => Items.Count;

        /// <summary>
        /// Get element by index
        /// </summary>
        public TValue this[int idx] => Items[idx];

        public TValue this[TKey key]
        {
            get { return Items[ItemsDictionary[key]]; }
            set
            {            
                Items.Add(value);
                ItemsDictionary[key] = Items.Count - 1;
            }
        }
        
        public bool TryGetValue(TKey key, out TValue value)
        {
            int idx;
            if (ItemsDictionary.TryGetValue(key, out idx))
            {
                value = Items[idx];
                return true;
            }
            value = null;
            return false;
        }
        
        public TValue GetValue(TKey key)
        {
            int idx;
            if (ItemsDictionary.TryGetValue(key, out idx))
                return Items[idx];
            UnityEngine.Debug.LogError($"Can't find key string {key.ToString()}");
            return null;
        }
        
        /// <summary>
        /// Clear whole table
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            ItemsDictionary.Clear();
        }

        public System.Array ToArray() => Items.ToArray();

        private readonly List<TValue> Items;
        private readonly Dictionary<TKey, int> ItemsDictionary;
    }
}