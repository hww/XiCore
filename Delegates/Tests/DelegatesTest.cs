using NUnit.Framework;
using UnityEngine;

namespace XiCore.Delegates.Test
{
    [TestFixture]
    public sealed class DelegatesTest
    {
        System.Func<int, int, int> unityDelegate;

        static int count;
        const int quantity = 5000;

        [Test]
        public void StandartDelegate()
        {
            double time1, time2;

            Debug.Log($"Standart delegate");
            time1 = Time.realtimeSinceStartup;
            for (int i = 0; i < quantity; i++)
                unityDelegate += AddFunction;
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Add delegate time: {time2-time1}");

            count = 0;
            time1 = Time.realtimeSinceStartup;
            unityDelegate(1, 2);
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Call delegate time: {time2-time1} quantity: {count}");

            time1 = Time.realtimeSinceStartup;
            for (int i = 0; i < quantity; i++)
                unityDelegate -= AddFunction;
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Remove delegate time: {time2-time1}");
        }
        [Test]
        public void FastFuncDelegate()
        {
            FastFunc<int, int, int> fastFunc = new FastFunc<int, int, int>();
            double time1, time2;
            Debug.Log("$FastFunc delegate");
            time1 = Time.realtimeSinceStartup;
            for (int i = 0; i < quantity; i++)
                fastFunc.Add(AddFunction);
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Add delegate time: {time2-time1}");

            count = 0;
            time1 = Time.realtimeSinceStartup;
            fastFunc.Call(1, 2);
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Call delegate time: {time2-time1} quantity: {count}");

            time1 = Time.realtimeSinceStartup;
            for (int i = 0; i < quantity; i++)
                fastFunc.Remove(AddFunction);
            time2 = Time.realtimeSinceStartup;
            Debug.Log($"  Remove delegate time: {time2-time1}");

        }

        static int AddFunction(int a, int b)
        {
            count++;
            return a + b;
        }
    }
}
