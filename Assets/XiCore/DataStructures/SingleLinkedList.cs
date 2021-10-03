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

using System.Collections;
using System.Collections.Generic;

#pragma warning disable CSE0003

namespace XiCore.DataStructures
{
    using Interfaces;
    
    internal class SingleNodeBase<TNodeType> : IEnumerable<SingleNodeBase<TNodeType>> where TNodeType : class
    {
        public SingleNodeBase<TNodeType> next;

        public SingleNodeBase(SingleNodeBase<TNodeType> next)
        {
            this.next = next;
        }
        public TNodeType Super => this as TNodeType;

        #region IEnumerable<T> Members

        public IEnumerator<SingleNodeBase<TNodeType>> GetEnumerator()
        {
            var node = this;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return GetEnumerator();
        }

        #endregion
    }


    // Simple single-linked list template for Structure.
    internal class SListNode<T> : SingleNodeBase<SListNode<T>>, IListNode<T> where T : struct
    {
        public T element;
        private SListNode(T inElement, SListNode<T> inNext) : base(inNext)
        {
            element = inElement;
        }

        public T Data => element;
    }

    // Simple single-linked list template for class
    internal class CIntrusiveListNode<T> : SingleNodeBase<CIntrusiveListNode<T>>, IListNode<T> where T : class
    {
        public CIntrusiveListNode(CIntrusiveListNode<T> inNext = null) : base(inNext)
        {
        }

        public T Data => this as T;
    }

    // Simple single-linked list template for class
    internal class CListNode<T> : SingleNodeBase<CListNode<T>>, IListNode<T>  where T : class
    {
        public T element;
        public CListNode(T inElement, CListNode<T> inNext = null) : base(inNext)
        {
            element = inElement;
        }

        public T Data => element;
    }
}