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

using System.Collections.Generic;
using XiCore.StringTools;

namespace XiCore.DataStructures
{
    using Interfaces;
    
    public enum EFindOptions
    {
        Find,
        Add
    }

    public class NameEntry
    {
        public readonly int NextHash;
        public readonly string Name;

        public NameEntry (string name, int nextHash)
        {
            Name = name;
            NextHash = nextHash;
        }
    }

    public struct Name : Inspectable
    {
        // -- Constructors ------------------------------------------------------------------------

        public Name ( int n ) { Hash = n; }
        public Name ( EName name ) { Hash = (int)name; }
        public Name ( Name other ) { Hash = other.Hash; }
        public Name (string name, EFindOptions options = EFindOptions.Add)
        {
            UnityEngine.Debug.Assert ( name != null );
            UnityEngine.Debug.Assert ( Initialized );
            
            if (!Initialized) PreInitialize();
            
            Hash = 0;
	        if ( name != NullName )
	        {
		        //	Search for existing entry.
		        int hashIndex = GetStrigHash ( name ) & HashTableIndexMask;
                int tempHash = NamesHash[ hashIndex ];
                while ( tempHash != 0 )
                {
                    if ( name == Names[ tempHash ].Name ) 
                    {
                        Hash = tempHash;
                        break;
                    }
                    tempHash = Names[ tempHash ].NextHash;
                }
                if (tempHash == 0 && options == EFindOptions.Add)
		        {
                    //	Add a new entry.
                    Hash = Names.Count;
                    Names.Add(new NameEntry ( name, NamesHash[ hashIndex ] ));
			        NamesHash[ hashIndex ] = Hash;
			        MemorySizeForNames += name.Length;
                }
                UnityEngine.Debug.Assert ( Hash <= 0xffff );
            }
        }

        // -- Validation ------------------------------------------------------------------------

        public bool IsValid { get { return Hash >= 0 && Hash < Names.Count; } }

        public bool IsKeyword  { get { return IsValid && Names[ Hash ].Name[ 0 ] == ':'; } }

        public bool IsIdentifier  { get { return IsValid && Names[ Hash ].Name[ 0 ] != ':'; } }

        // -- Debugging -------------------------------------------------------------------------

        private const string NOT_VALID_STRING = "#<name NotValid>";
        private const string NOT_INITIALIZED_STRING = "#<name NotInitialized>";
        
        public override string ToString ( )
        {
            if (Initialized)
            {
                if (Hash < Names.Count)
                    return $"#<name {Names[Hash].Name}>";
                return NOT_VALID_STRING;
            }
            return NOT_INITIALIZED_STRING;
        }
        
        // -- Cast to other type  --------------------------------------------------------------
        
        // explicit conversion: var str = (string)fooName
        public static explicit operator string ( Name name ) { return Names[ name.Hash ].Name; }

        // implicit conversion: Name name = EName.None
        public static implicit operator Name ( EName name ) { return new Name(name); }

        public string AsString => Names[ Hash ].Name;

        // -- Comparison ------------------------------------------------------------------------

        public override bool Equals ( object obj )
        {
            if ( obj == null || GetType ( ) != obj.GetType ( ) )
                return false;
            return Hash == ((Name)obj).Hash ;
        }
        public override int GetHashCode ( ) { return Hash; }
        public static bool operator == ( Name x, Name y ) { return x.Hash == y.Hash; }
        public static bool operator != ( Name x, Name y ) { return x.Hash != y.Hash; }

        // -- Debugging -----------------------------------------------------------------------------

        public string Inspect ( InspectOptions options = InspectOptions.PrettyPrint)
        {
            if ( options == InspectOptions.PrettyPrint )
                return SpecialForm.ToSpecialFormString ( this ) ;
            else
                return ToString ( );
        }

        // -- Fields -----------------------------------------------------------------------------

        public readonly int Hash;

        // -- Static methods ---------------------------------------------------------------------

        public static void PreInitialize ( )
        {
            foreach ( EName name in System.Enum.GetValues ( typeof ( EName ) ) )
            {
                var namestring = name.ToString ( );
                if ( (int)name >= (int)EName.SchemeNames )
                    namestring = Humanizer.Decamelize ( namestring );
                var nameindex = (int)name;
                int hashIndex = GetStrigHash ( name.ToString ( ) ) & HashTableIndexMask;
                Names.Add ( new NameEntry ( namestring, NamesHash[ hashIndex ] ) );
                NamesHash[ hashIndex ] = nameindex;
                MemorySizeForNames += namestring.Length;
            }
            Initialized = true;
        }

        public static void DeInitialize ( )
        {
            for ( var i = 0 ; i < NamesHash.Length ; i++ )
                NamesHash[ i ] = 0;
            Names.Clear ( );
            MemorySizeForNames = 0;
            Initialized = false;
        }

        public static int GetNamesCount ( ) { return Names.Count; }

        public static NameEntry GetEntry ( int i ) { return Names[ i ]; }

        public static bool IsInitialized => Initialized;

        public static int GetStrigHash ( string str )
        {
            var result = 0;
            int sh = 0;
            for ( var i = 0 ; i < str.Length ; i++ )
            {
                result ^= ( str[ i ] & 0xff ) << sh;
                sh = ( sh + 1 ) & 3;
            }
            return result;
        }

        // -- Static fields  ---------------------------------------------------------------------

        private const int HashTableSize = 4096;
        private const int HashTableIndexMask = HashTableSize - 1;
        private const int InitialNamesQuantity = 4096;

        /* 
          * The first element reserved for NullName 
          *
          * Array: nameHash[]                         Array: names[]
          * -----------------------------      0      ------------------------------
          * | [0]      0 (means first)  |------------>| name:     "None"           |    
          * -----------------------------             | hashNext: 1                |---+
          * | [1]      2                |-----+       ------------------------------   |
          * -----------------------------     |       | name:     "bar"            |<--+
          * | ...     ...               |     |       | hashNext: 0 (means last)   |
          * -----------------------------     |       ------------------------------
          * | [N]      0                |     +------>| name:     "baz"            |
          * -----------------------------             | hashNext: 0 (means last)   |
          *                                          ------------------------------
          */

        private static readonly string NullName = EName.None.ToString();
        private static readonly List<NameEntry> Names = new List<NameEntry> ( InitialNamesQuantity );
        private static readonly int[] NamesHash = new int[ HashTableSize ];
        private static bool Initialized;
        private static int MemorySizeForNames;
    }
    
    public static partial class SpecialForm
    {
        public static bool IsSpecialForm ( Name name )
        {
            return name.Hash == (int)EName.Quote ||
                   name.Hash == (int)EName.Quasiquote ||
                   name.Hash == (int)EName.Unquote ||
                   name.Hash == (int)EName.UnquoteSplicing;
        }

        public static string ToSpecialFormString ( Name name )
        {
            switch ( (EName)name.Hash )
            {
                case EName.Quote:
                    return "'";
                case EName.Quasiquote:
                    return "`";
                case EName.Unquote:
                    return ",";
                case EName.UnquoteSplicing:
                    return ",@";
                default:
                    return name.ToString();
            }
        }
    }
}
