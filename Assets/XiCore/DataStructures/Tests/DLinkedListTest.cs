﻿// =============================================================================
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
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using XiCore.DataStructures;

namespace XiCore.DataStructures.Tests
{
    [TestFixture]
    public sealed class DLinkedListTest
    {

        class MyClass
        {
            public DLinkedListNode<MyClass> link;
            public int value;
            public MyClass(int val)
            {
                value = val;
                link = new DLinkedListNode<MyClass>(this);
            }

            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                return value.Equals((obj as MyClass).value);
            }

            public override string ToString()
            {
                return value.ToString();
            }

        };

        [Test]
        public void DoubleLinkedList_StringList()
        {
            DLinkedList<string> stringsList = new DLinkedList<string>();
            stringsList.AddLast(new DLinkedListNode<string>("3"));
            stringsList.AddLast(new DLinkedListNode<string>("4"));
            stringsList.AddLast(new DLinkedListNode<string>("5"));
            stringsList.AddFirst(new DLinkedListNode<string>("2"));
            stringsList.AddFirst(new DLinkedListNode<string>("1"));
            stringsList.AddFirst(new DLinkedListNode<string>("0"));
            Debug.Log("String List: " + stringsList.ToString());
            string[] stringArray = stringsList.ToArray();
            Debug.Assert(stringArray[0] == "0");
            Debug.Assert(stringArray[1] == "1");
            Debug.Assert(stringArray[2] == "2");
            Debug.Assert(stringArray[3] == "3");
            Debug.Assert(stringArray[4] == "4");
            Debug.Assert(stringArray[5] == "5");
            Debug.Assert(stringsList.ToList().ToArray().ToString() == new string[] { "0", "1", "2", "3", "4", "5" }.ToString());
            Debug.Assert(stringsList.ToArray().ToString() == new string[] { "0", "1", "2", "3", "4", "5" }.ToString());
            string iteratorString = "";
            foreach (string v in stringsList)
            {
                iteratorString += v.ToString();
            }
            Debug.Assert(iteratorString == "012345");
        }
        [Test]
        public void DoubleLinkedList_IntList()
        {

            DLinkedList<int> intList = new DLinkedList<int>();
            intList.AddLast(new DLinkedListNode<int>(3));
            intList.AddLast(new DLinkedListNode<int>(4));
            intList.AddLast(new DLinkedListNode<int>(5));
            intList.AddFirst(new DLinkedListNode<int>(2));
            intList.AddFirst(new DLinkedListNode<int>(1));
            intList.AddFirst(new DLinkedListNode<int>(0));
            Debug.Log("Int List: " + intList.ToString());
            int[] intArray = intList.ToArray();
            Debug.Assert(intArray[0] == 0);
            Debug.Assert(intArray[1] == 1);
            Debug.Assert(intArray[2] == 2);
            Debug.Assert(intArray[3] == 3);
            Debug.Assert(intArray[4] == 4);
            Debug.Assert(intArray[5] == 5);
            Debug.Assert(intList.ToList().ToArray().ToString() == new int[] { 0, 1, 2, 3, 4, 5 }.ToString());
            Debug.Assert(intList.ToArray().ToString() == new int[] { 0, 1, 2, 3, 4, 5 }.ToString());

            intList.RemoveLast();
            Debug.Assert(intList.ToArray().ToString() == new int[] { 0, 1, 2, 3, 4 }.ToString());
            intList.RemoveFirst();
            Debug.Assert(intList.ToArray().ToString() == new int[] { 1, 2, 3, 4 }.ToString());
            intList.Remove(2);
            Debug.Assert(intList.ToArray().ToString() == new int[] { 1, 3, 4 }.ToString());
            intList.RemoveLast();
            Debug.Assert(intList.ToArray().ToString() == new int[] { 1, 3 }.ToString());
            intList.RemoveFirst();
            Debug.Assert(intList.ToArray().ToString() == new int[] { 3 }.ToString());
            intList.Remove(2);
            Debug.Assert(intList.ToArray().ToString() == new int[] { }.ToString());
        }
        [Test]
        public void DoubleLinkedList_ClassList()
        {
            DLinkedList<MyClass> intusiveList = new DLinkedList<MyClass>();
            intusiveList.AddLast(new MyClass(1).link);
            intusiveList.AddLast(new MyClass(2).link);
            intusiveList.AddFirst(new MyClass(0).link);
            Debug.Log("Class List: " + intusiveList.ToString ( ));
            MyClass[] classArray = intusiveList.ToArray();
            Debug.Assert(classArray[0].value == 0);
            Debug.Assert(classArray[1].value == 1);
            Debug.Assert(classArray[2].value == 2);
        }
    }
}