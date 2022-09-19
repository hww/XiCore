using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XiCore.Fields
{ 
    //
    // Summary:
    //     Describes an integer range.
    [System.Serializable]
    public struct RangeInt
    {
        //
        // Summary:
        //     The starting index of the range, where 0 is the first position, 1 is the second,
        //     2 is the third, and so on.
        public int start;
        //
        // Summary:
        //     The length of the range.
        public int length;

        //
        // Summary:
        //     The end index of the range (not inclusive).
        public int end { get => start + length; }
    }
}