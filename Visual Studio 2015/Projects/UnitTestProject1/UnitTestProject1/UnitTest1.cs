using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectForTesting;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LatinSentenceSplitter asd = new LatinSentenceSplitter();
            string[] mas = asd.Split("Hello World");
            string[] mas1 = { "Hello", "World" };
            CollectionAssert.AreEqual(mas, mas1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            LatinSentenceSplitter asd = new LatinSentenceSplitter();
            string[] mas = asd.Split("Hellо World");
            string[] mas1 = { "Hellо", "World" };
            CollectionAssert.AreEqual(mas, mas1);
        }
    }
    }

