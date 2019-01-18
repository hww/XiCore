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

namespace Plugins.VARP.Utilities
{
	public static class FastNumberToString
	{

		private const int BackedStringsCount = 200;
		private static readonly string[] BakedStrings;
		
		static FastNumberToString()
		{
			BakedStrings = new string[BackedStringsCount];
			for (var i = 0; i < BackedStringsCount; i++)
				BakedStrings[i] = i.ToString();
		}

		/// <summary>
		/// Convert integer to string fast way
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string IntegerToString(int value)
		{
			if (value >= 0 && value < BackedStringsCount)
				return BakedStrings[value];
			else
				return value.ToString();
		}
	}
}
