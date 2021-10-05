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

//using UnityEngine.ResourceManagement;

namespace XiCore
{
    /*
    public static class IAsyncOperationExtensions
    {
        public static AsyncOperationAwaiter GetAwaiter(this IAsyncOperation operation)
        {
            return new AsyncOperationAwaiter(operation);
        }

        public static AsyncOperationAwaiter<T> GetAwaiter<T>(this IAsyncOperation<T> operation) where T : Object
        {
            return new AsyncOperationAwaiter<T>(operation);
        }

        public readonly struct AsyncOperationAwaiter : INotifyCompletion
        {
            readonly IAsyncOperation _operation;

            public AsyncOperationAwaiter(IAsyncOperation operation)
            {
                _operation = operation;
            }

            public bool IsCompleted => _operation.Status != AsyncOperationStatus.None;

            public void OnCompleted(Action continuation) => _operation.Completed += (op) => continuation?.Invoke();

            public object GetResult() => _operation.Result;
        }

        public readonly struct AsyncOperationAwaiter<T> : INotifyCompletion where T : Object
        {
            readonly IAsyncOperation<T> _operation;

            public AsyncOperationAwaiter(IAsyncOperation<T> operation)
            {
                _operation = operation;
            }

            public bool IsCompleted => _operation.Status != AsyncOperationStatus.None;

            public void OnCompleted(Action continuation) => _operation.Completed += (op) => continuation?.Invoke();

            public T GetResult() => _operation.Result;
        }
    }
    */
}