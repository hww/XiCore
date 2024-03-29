﻿using NUnit.Framework;

namespace XiCore.StringTools.Tests
{
    public class HashToolsTest
    {
        [Test]
        public void HashToolsSHA()
        {
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToSHA("HelloWorld"), Is.EqualTo(HashTools.StringToSHA("HelloWorld")));
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToSHA("HelloWorld"), Is.Not.EqualTo(HashTools.StringToSHA("ByeByeWorld")));
            
        }
        
        [Test]
        public void StringToHash()
        {
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("HelloWorld"), Is.EqualTo(HashTools.StringToHash("HelloWorld")));
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("HelloWorld"), Is.Not.EqualTo(HashTools.StringToHash("ByeByeWorld")));
            
        }
        
        [Test]
        public void StringToHashRegion()
        {
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("HelloWorld".ToCharArray(), 1, 4), Is.EqualTo(HashTools.StringToHash("HelloWorld".ToCharArray(),1,4)));
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("HelloWorld".ToCharArray(), 1, 4), Is.Not.EqualTo(HashTools.StringToHash("ByeByeWorld".ToCharArray(),1,4)));
        }
        
        [Test]
        public void StringToHashUpToCharacter()
        {
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("Hello World".ToCharArray(), 1, ' '), 
                Is.EqualTo(HashTools.StringToHash("Hello World".ToCharArray(),1,' ')));
            // Use the Assert class to test conditions
            Assert.That(HashTools.StringToHash("Hello World".ToCharArray(), 1, ' '), 
                Is.Not.EqualTo(HashTools.StringToHash("ByeBye World".ToCharArray(),1,' ')));
        }
    }
}
