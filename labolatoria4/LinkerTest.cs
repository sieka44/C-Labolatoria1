using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNUnit
{
    [TestFixture]
    class LinkerTest
    {
        [TestCase]
        public void JoinStringNull()
        {
            Linker linker = new Linker();
            String outcome = linker.Link("blah", null);
            Assert.IsNull(outcome);
        } 
        [TestCase]
        public void JoinNullString()
        {
            Linker linker = new Linker();
            String outcome = linker.Link(null,"blah");
            Assert.IsNull(outcome);
        }
        [TestCase]
        public void JoinNullNull()
        {
            Linker linker = new Linker();
            String outcome = linker.Link(null, null);
            Assert.IsNull(outcome);
        }
        [TestCase]
        public void JoinEmpty()
        {
            Linker linker = new Linker();
            String outcome = linker.Link("", "");
            Assert.IsEmpty(outcome);
        }
        [TestCase]
        public void Join()
        {
            Linker linker = new Linker();
            String outcome = linker.Link("aba", "bab");
            Assert.AreEqual(outcome, "ababab");
        }
        [TestCase]
        public void JoinNullEx()
        {
            Linker linker = new Linker();
            var ex = Assert.Throws<ArgumentNullException>(() => linker.LinkWithException(null, "yes"));
            Assert.AreEqual(ex.Message,(new ArgumentNullException("One of string is null")).Message);
        }
        [TestCase]
        public void JoinNullNullEx()
        {
            Linker linker = new Linker();
            var ex = Assert.Throws<ArgumentNullException>(() => linker.LinkWithException(null, null));
            Assert.AreEqual(ex.Message, (new ArgumentNullException("One of string is null")).Message);
        }
        [TestCase]
        public void JoinEx()
        {
            Linker linker = new Linker();
            var ex = linker.LinkWithException("no", "yes");
            Assert.AreEqual("noyes", ex);
        }
    }
}
