using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XiCore.Fields
{
    [System.Serializable]
    public struct RangeIntMinMax
    {
        public int start;
        public int end;

        public int length { get => end - start; }
    }
}
