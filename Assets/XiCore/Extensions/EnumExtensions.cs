using System;

namespace XiCore.Extensions
{
    public static class EnumExtensions
    {
        public static bool HasFlagUnsafe<TEnum>(this TEnum lhs, TEnum rhs) where TEnum :
#if CSHARP_7_3_OR_NEWER
            unmanaged, Enum
#else
            struct
#endif
        {

            unsafe
            {
#if CSHARP_7_3_OR_NEWER
                switch (sizeof(TEnum))
                {
                    case 1:
                        return (*(byte*)(&lhs) & *(byte*)(&rhs)) > 0;
                    case 2:
                        return (*(ushort*)(&lhs) & *(ushort*)(&rhs)) > 0;
                    case 4:
                        return (*(uint*)(&lhs) & *(uint*)(&rhs)) > 0;
                    case 8:
                        return (*(ulong*)(&lhs) & *(ulong*)(&rhs)) > 0;
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }

#else
                switch (UnsafeUtility.SizeOf<TEnum>())
                {
                    case 1:
                        {
                            byte valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            byte valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 2:
                        {
                            ushort valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            ushort valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 4:
                        {
                            uint valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            uint valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    case 8:
                        {
                            ulong valLhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref lhs, &valLhs);
                            ulong valRhs = 0;
                            UnsafeUtility.CopyStructureToPtr(ref rhs, &valRhs);
                            return (valLhs & valRhs) > 0;
                        }
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }
#endif
            }
        }

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf(values, src) + 1;
            return values.Length == j ? values[0] : values[j];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(values, src) - 1;
            return j < 0 ? values[values.Length - 1] : values[j];
        }

        public static T ToEnum<T>(this string name) where T : struct
        {
            if (Enum.TryParse(name, out T result))
                return result;
            throw new SystemException($"Unexpected KeyCode {name}");
        }
    }

    public static class BoolExtensions
    {
        public static string ToYesNoText(this bool val)
        {
            return val ? "Yes" : "No";
        }
        public static string ToEnabledDisabledText(this bool val)
        {
            return val ? "Enabled" : "Disabled";
        }
        public static string ToOnOffText(this bool val)
        {
            return val ? "On" : "Off";
        }
    }
}