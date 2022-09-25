/* Copyright(c) 2021 Valeriya Pudova(hww.github.io) read more at the license file */

using UnityEngine;

namespace XiCore.Extensions
{
    public static class Vector2Extensions
    {
        /** Returns a copy of this vector with the given x component. */

        public static Vector2 WithX(this Vector2 vec, float x)
        {
            return new Vector2(x, vec.y);
        }

        /** Returns a copy of this vector with the given y component. */

        public static Vector2 WithY(this Vector2 vec, float y)
        {
            return new Vector2(vec.x, y);
        }

        public static Vector2 WithXY(this Vector2 vec, float x, float y)
        {
            return new Vector2(x, y);
        }

        /** Returns a copy of this vector with the given x component. */

        public static Vector2 WithAddX(this Vector2 vec, float x)
        {
            return new Vector2(vec.x + x, vec.y);
        }

        /** Returns a copy of this vector with the given y component. */

        public static Vector2 WithAddY(this Vector2 vec, float y)
        {
            return new Vector2(vec.x, vec.y + y);
        }

        public static Vector2 WithAddXY(this Vector2 vec, float x, float y)
        {
            return new Vector2(vec.x + x, vec.y + y);
        }
    }
}