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

using System;
using System.Runtime.InteropServices;

namespace XiCore.DataStructures.Unions
{
    [StructLayout ( LayoutKind.Explicit )]
    public struct Variant
    {
        public static Variant Null;

        public enum EVariantType : byte
        {
            Undefined,
            Integer,
            Float,
            Bool,
            Name
        }

        [FieldOffset ( 0 )]
        public int AsInteger;
        [FieldOffset ( 0 )]
        public float AsFloat;
        [FieldOffset ( 0 )]
        public bool AsBool;
        [FieldOffset ( 0 )]
        public Name AsName;

        [FieldOffset ( 4 )]
        public EVariantType VariantType;

        // -- Setters ------------------------------------------------------------------------

        public void Set( int value )
        {
            VariantType = EVariantType.Integer;
            AsInteger = value;
        }
        public void Set ( float value )
        {
            VariantType = EVariantType.Float;
            AsFloat = value;
        }
        public void Set ( bool value )
        {
            VariantType = EVariantType.Bool;
            AsBool = value;
        }
        public void Set ( Name value )
        {
            VariantType = EVariantType.Name;
            AsName = value;
        }

        // -- Cast type ------------------------------------------------------------------------

        public override string ToString ( )
        {
            switch ( VariantType )
            {
                case EVariantType.Undefined:
                    return "<undefined>";
                case EVariantType.Integer:
                    return AsInteger.ToString();
                case EVariantType.Float:
                    return AsFloat.ToString();
                case EVariantType.Bool:
                    return AsBool.ToString();
                case EVariantType.Name:
                    return AsName.ToString();
            }
           throw new Exception();
        }

        // implicit conversion bool name = variantVariable
        public static implicit operator bool(Variant right)
        {
            if ( right.VariantType == EVariantType.Bool )
                return right.AsBool;
            throw new Exception ( );
        }
        // implicit conversion int name = variantVariable
        public static implicit operator int ( Variant right )
        {
            if ( right.VariantType == EVariantType.Integer )
                return right.AsInteger;
            if ( right.VariantType == EVariantType.Float )
                return (int)right.AsFloat;
            throw new Exception ( );
        }
        // implicit conversion float name = variantVariable
        public static implicit operator float ( Variant right )
        {
            if ( right.VariantType == EVariantType.Float )
                return right.AsFloat;
            if ( right.VariantType == EVariantType.Integer )
                return right.AsInteger;
            throw new Exception ( );
        }
        // implicit conversion Name name = variantVariable
        public static implicit operator Name ( Variant right )
        {
            if ( right.VariantType == EVariantType.Name )
                return right.AsName;
            throw new Exception ( );
        }

        // explicit conversion (Variant)true
        public static explicit operator Variant ( bool value )
        {
            return new Variant { AsBool = value, VariantType = EVariantType.Bool };
        }
        // explicit conversion (Variant)100
        public static explicit operator Variant ( int value )
        {
            return new Variant { AsInteger = value, VariantType = EVariantType.Integer };
        }
        // explicit conversion (Variant)0.1f
        public static explicit operator Variant ( float value )
        {
            return new Variant { AsFloat = value, VariantType = EVariantType.Float };
        }
        // explicit conversion (Variant)Name.Intern("hello")
        public static explicit operator Variant ( Name value )
        {
            return new Variant { AsName = value, VariantType = EVariantType.Name };
        }
        // explicit conversion (Variant)EName.Null
        public static explicit operator Variant ( EName value )
        {
            return new Variant { AsName = new Name(value), VariantType = EVariantType.Name };
        }
        // -- Comparison ------------------------------------------------------------------------

        public override bool Equals ( object obj )
        {
            if (!(obj is Variant)) return false;
            var other = (Variant)obj;
            return VariantType == other.VariantType && AsInteger == other.AsInteger;
        }

        public override int GetHashCode ( )
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return AsInteger ^ (int)VariantType;
        }

        public string Inspect()
        {
            return $"#<variant:{TypeNames[(int)VariantType]} {ToString()}>";
        }

        private static readonly string[] TypeNames = {"Undefined", "Integer", "Float", "Bool", "Name" };
    }

}
