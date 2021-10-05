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
using System;

namespace XiCore.DataStructures
{
    public interface IResetable
    {
        void Reset();
    }
    // TODO! Maybe kill this file because there is GenericPool 
    public class ObjectPool<T> where T : class, new()
    {
        private readonly List<T> objectList;
        private int nextAvailableIndex = 0;

        private readonly Action<T> resetAction;
        private readonly Action<T> onetimeInitAction;

        public ObjectPool(
            int initialBufferSize, 
            Action<T> resetAction = null, 
            Action<T> onetimeInitAction = null)
        {
            objectList = new List<T>(initialBufferSize);
            this.resetAction = resetAction;
            this.onetimeInitAction = onetimeInitAction;
        }

        public T New()
        {
            if (nextAvailableIndex < objectList.Count)
            {
                // an allocated object is already available; just reset it
                T t = objectList[nextAvailableIndex];
                nextAvailableIndex++;
                var resetable = t as IResetable;
                resetable?.Reset();
                resetAction?.Invoke(t);

                return t;
            }
            else
            {
                // no allocated object is available
                T t = new T();
                objectList.Add(t);
                nextAvailableIndex++;
                var resetable = t as IResetable;
                resetable?.Reset();
                onetimeInitAction?.Invoke(t);

                return t;
            }
        }

        public void ResetAll()
        {
            nextAvailableIndex = 0;
        }
    }
}