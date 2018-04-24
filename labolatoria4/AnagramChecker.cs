using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestNUnit
{
    class AnagramChecker : IAnagramChecker
    {
        public bool IsAnagram(string word1, string word2)
        {
            if(word1 == null || word2 == null) return false;
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            String a = rgx.Replace(word1, "").ToLower();
            String b = rgx.Replace(word2, "").ToLower();
            if (a.Length == 0 || b.Length == 0 || a.Length != b.Length) return false;
            Console.WriteLine("|" +a + "| |" + b+"|");
            Console.WriteLine(String.Concat(a.OrderBy(c => c)) + " " + String.Concat(a.OrderBy(c => c)));
            return String.Concat(a.OrderBy(c => c)).Equals(String.Concat(b.OrderBy(c => c)));
        }
    }
}
