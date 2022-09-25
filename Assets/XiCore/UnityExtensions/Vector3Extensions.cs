/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

using System.Runtime.CompilerServices;
using UnityEngine;

namespace XiCore.Extensions
{
    public static class Vector3Extensions
    {
        /** Returns a copy of this vector with the given x component. */

        public static Vector3 WithX(this Vector3 vec, float x)
        {
            return new Vector3(x, vec.y, vec.z);
        }

        /** Returns a copy of this vector with the given y component. */

        public static Vector3 WithY(this Vector3 vec, float y)
        {
            return new Vector3(vec.x, y, vec.z);
        }

        /** Returns a copy of this vector with the given z component. */

        public static Vector3 WithZ(this Vector3 vec, float z)
        {
            return new Vector3(vec.x, vec.y, z);
        }

        public static Vector3 WithXY(this Vector3 vec, float x, float y)
        {
            return new Vector3(x, y, vec.z);
        }

        public static Vector3 WithYZ(this Vector3 vec, float y, float z)
        {
            return new Vector3(vec.x, y, z);
        }

        public static Vector3 WithXZ(this Vector3 vec, float x, float z)
        {
            return new Vector3(x, vec.y, z);
        }

        /** Swap coponents. */

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SwapXY(this Vector3 vec)
        {
            return new Vector3(vec.y, vec.x, vec.z);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SwapXZ(this Vector3 vec)
        {
            return new Vector3(vec.z, vec.y, vec.x);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 SwapYZ(this Vector3 vec)
        {
            return new Vector3(vec.x, vec.z, vec.y);
        }

        // The angle between dirA and dirB around axis
        public static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
        {
            var da = Vector3.Dot(dirA, axis);
            var db = Vector3.Dot(dirB, axis);

            if (Mathf.Abs(da) > 0.9f || Mathf.Abs(db) > 0.9f)
                return 0f;

            dirA = dirA - axis * da;
            dirB = dirB - axis * db;

            // Project A and B onto the plane orthogonal target axis
            //dirA = dirA - Vector3.Project (dirA, axis);
            //dirB = dirB - Vector3.Project (dirB, axis);

            // Find (positive) angle between A and B
            var angle = Vector3.Angle(dirA, dirB);

            // Return angle multiplied with 1 or -1
            return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
        }
    }
}