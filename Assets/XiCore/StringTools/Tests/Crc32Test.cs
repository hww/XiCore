using NUnit.Framework;
using XiCore.StringTools;

namespace XiCore.StringTools.Tests
{
    public class Crc32Test
    {
        [Test]
        public void CRC32Test()
        {
            Assert.That(GetCRC32S("vector"),       Is.EqualTo("012F77FE"));
            Assert.That(GetCRC32S("string"),       Is.EqualTo("0B3952E7"));
            Assert.That(GetCRC32S("float"),        Is.EqualTo("0F182EC3"));
            Assert.That(GetCRC32S("angle"),        Is.EqualTo("13812CD6"));
            Assert.That(GetCRC32S("state"),        Is.EqualTo("2E6743E3"));
            Assert.That(GetCRC32S("direction"),    Is.EqualTo("7194CBE7"));
            Assert.That(GetCRC32S("color"),        Is.EqualTo("71E73C6C"));
            Assert.That(GetCRC32S("boolean"),      Is.EqualTo("8B4E76FF"));
            Assert.That(GetCRC32S("vec4"),         Is.EqualTo("93BD2E95"));
            Assert.That(GetCRC32S("script-lambda"),Is.EqualTo("9ED499E1"));
            Assert.That(GetCRC32S("function"),     Is.EqualTo("AB3EB31F"));
            Assert.That(GetCRC32S("int32"),        Is.EqualTo("C7CB275C"));
        }                                          
        private string GetCRC32S(string str)
        {
            return CRC32.Crc32(str).ToString("X8");
        }
    }
}