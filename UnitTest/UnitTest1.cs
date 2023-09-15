using NUnit.Framework;
using System;
using TestAkv;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("()()()", "BALANCED")]
        [TestCase("{{[[(())]]}}", "BALANCED")]
        [TestCase("()()()}", "NOT BALANCED(6)")]
        [TestCase("[{{[[(())]]}}", "NOT BALANCED(0)")]

        public void Test1(string value, string result)
        {
            var resultOfMethod = "";
            if (BalanceVerificator.areBracketsBalanced(value) > -1)
                resultOfMethod = $"NOT BALANCED({BalanceVerificator.areBracketsBalanced(value)})";
            else
                resultOfMethod = "BALANCED";
            Assert.AreEqual(resultOfMethod, result);

        }
        [TestCase("s()()")]
        [TestCase("")]
        public void Test2(string value)
        {
            Assert.That(() => BalanceVerificator.areBracketsBalanced(value), Throws.TypeOf<IllegalArgumentException>());
        }
        [TestCase(null)]
        public void Test3(string value)
        {
            Assert.That(() => BalanceVerificator.areBracketsBalanced(value), Throws.TypeOf<NullReferenceException>());
        }
    }
}