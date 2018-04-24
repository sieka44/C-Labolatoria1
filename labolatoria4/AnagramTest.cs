using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNUnit
{
    [TestFixture]
    class AnagramTest
    {
        [TestCase]
        public void StringIsAnagram()
        {
            String s = "god";
            String s1 = "dog";
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsTrue(anagramChecker.IsAnagram(s, s1));
        }
        [TestCase]
        public void StringNull()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram(null, "ASD"));
        }
        [TestCase]
        public void StringEmpty()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram("", "ASD"));
        }
        [TestCase]
        public void StringNullEmpty()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram(null, ""));
        }
        [TestCase]
        public void StringLoverBiggerCase()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsTrue(anagramChecker.IsAnagram("asd", "ASD"));
        }
        [TestCase]
        public void OnlySpecialChars()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram("%%@#$", "@#%      #$%"));
        }

        [TestCase]
        public void OnlyWhiteChars()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsFalse(anagramChecker.IsAnagram("  ", "        "));
        }

        [TestCase]
        public void AnagramWithWhiteChars()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsTrue(anagramChecker.IsAnagram(" a      a  b", " ba        a           "));
        }

        [TestCase]
        public void AnagramBigAndSmallCharsWithSpecialChar()
        {
            IAnagramChecker anagramChecker = new AnagramChecker();
            Assert.IsTrue(anagramChecker.IsAnagram("!!!!ASDAS....@##$@DA#$%SD A ASDA ASD", "a@#%(&*sdasda%%sd A ASDA ASD          "));
        }
    }
}
