using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNUnit
{
    class Linker
    {
        public String Link(String a, String b)
        {
            if (a == null || b == null) return null;

            return a+b;
        }   

        public String LinkWithException(String a, String b)
        {
            if (a == null || b == null) throw new ArgumentNullException("One of string is null");

            return a + b;
        }
    }
}
