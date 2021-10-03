using System.Runtime.CompilerServices;
using UnityEngine;

namespace XiCore
{
    public static class ColorExtensions 
    {
        // =======================================================================
        // REPLACE ONE OF COMPONENTS
        // =======================================================================

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithR(this Color vec, float r)
        {
            return new Color(r, vec.g, vec.b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithG(this Color vec, float g)
        {
            return new Color(vec.r, g, vec.b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithB(this Color vec, float b)
        {
            return new Color(vec.r, vec.g, b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithA(this Color vec, float a)
        {
            return new Color(vec.r, vec.g, vec.b, a);
        }
        // =======================================================================
        // REPLACE TWO COMPONENTS
        // =======================================================================

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithRG(this Color vec, float r, float g)
        {
            return new Color(r, g, vec.b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithRB(this Color vec, float r, float b)
        {
            return new Color(r, vec.g, b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color WithGB(this Color vec, float g, float b)
        {
            return new Color(vec.r, g, b, vec.a);
        }

        // =======================================================================
        // SWAP TWO COMPONENTS
        // =======================================================================

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color SwapRG(this Color vec)
        {
            return new Color(vec.g, vec.r, vec.b, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color SwapRB(this Color vec)
        {
            return new Color(vec.b, vec.g, vec.r, vec.a);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color SwapGB(this Color vec)
        {
            return new Color(vec.r, vec.b, vec.g, vec.a);
        }
    }
}