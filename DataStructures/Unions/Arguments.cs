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
using System.Text;

namespace XiCore.DataStructures.Unions
{

    /// <summary>
    /// Access to variable arguments list
    /// </summary>
    public class Arguments 
    {
        // =============================================================================================================
        // GET ARGUMENT METHODS
        // =============================================================================================================
        
        public static Name GetName(int index, EName defaultValue = EName.None, params Variant[] args)
        {
            if (index < args.Length)
            {
                var value = args[index];
                if (value.VariantType == Variant.EVariantType.Name)
                    return value.AsName;
                else
                    throw new Exception(ArgumentErrorMessage("Arguments.GetName", "Name", index, args));
            }
            else
            {
                return new Name(defaultValue);
            }
        }

        public static float GetFloat(int index, float defaultValue = 0, params Variant[] args)
        {
            if (index < args.Length)
            {
                var value = args[index];
                if (value.VariantType == Variant.EVariantType.Float)
                    return value.AsFloat;
                else
                    throw new Exception(ArgumentErrorMessage("Arguments.GetFloat", "Float", index, args));
            }
            else
            {
                return defaultValue;
            }
        }

        public static int GetInteger(int index, int defaultValue = 0, params Variant[] args)
        {
            if (index < args.Length)
            {
                var value = args[index];
                if (value.VariantType == Variant.EVariantType.Integer)
                    return value.AsInteger;
                else
                    throw new Exception(ArgumentErrorMessage("Arguments.GetInteger", "Integer", index, args));
            }
            else
            {
                return defaultValue;
            }
        }

        public static bool GetBool(int index, bool defaultValue = false, params Variant[] args)
        {
            if (index < args.Length)
            {
                var value = args[index];
                if (value.VariantType == Variant.EVariantType.Bool)
                    return value.AsBool;
                else
                    throw new Exception(ArgumentErrorMessage("Arguments.GetBool", "Bool", index, args));
            }
            else
            {
                return defaultValue;
            }
        }
        
        // =============================================================================================================
        // CHECK ARGUMENTS QUANTITY METHODS
        // =============================================================================================================

        public static void RequiredMinimum(int min, int max = 0, params Variant[] args)
        {
            if (args.Length < min)
            {
                var argStr = ArgumentsToString(args);
                throw new Exception(
                    $"Arguments.Required: contract violation\n   expected min: {min}\n   given: {args.Length}\n  all arguments...:\n{argStr}");
            }
        }
        
        public static void RequiredMaximum(int max = 0, params Variant[] args)
        {
            if (args.Length > max)
            {
                var argStr = ArgumentsToString(args);
                throw new Exception(
                    $"Arguments.Required: contract violation\n   expected max: {max}\n   given: {args.Length}\n  all arguments...:\n{argStr}");
            }
        }
        
        public static void RequiredRange(int min, int max = 0, params Variant[] args)
        {
            if (args.Length < min || args.Length > max)
            {
                var argStr = ArgumentsToString(args);
                throw new Exception(
                    $"Arguments.Required: contract violation\n   expected min: {min} max: {max}\n   given: {args.Length}\n  all arguments...:\n{argStr}");
            }
        }

        private static string ArgumentErrorMessage(string name, string expected, int badPos, params Variant[] args)
        {
            var sb = new StringBuilder();
            var given = args[badPos].ToString();
            var argStr = ArgumentsToString(args, badPos);
            return
                $"{name}: contract violation\n   expected: {expected}\n   given: {given}\n  argument position: {badPos}\n  other arguments...:\n{argStr}";
        }
        
        private static string ArgumentsToString(Variant[] args)
        {
            var sb = new StringBuilder();
            sb.Append("(");
            for (var i = 0; i < args.Length; i++)
            {
                sb.Append("  ");
                sb.Append(args[i].ToString());
            }
            sb.Append(" )");
            return sb.ToString();
        }
        
        private static string ArgumentsToString(Variant[] args, int badIndex)
        {
            var sb = new StringBuilder();
            sb.Append("(");
            for (var i = 0; i < args.Length; i++)
            {
                sb.Append("  ");
                if (i == badIndex)
                    sb.Append("<bad>");
                else
                    sb.Append(args[i].ToString());
            }
            sb.Append(" )");
            return sb.ToString();
        }
    }
}