using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeAffinity.TestFuzzer;
using CodeAffinity.TestFuzzer.UnitTest.TestModels;
using System;

namespace CodeAffinity.TestFuzzer.UnitTest
{
    [TestClass]
    public class UnitTestFuzzer
    {
        [TestMethod]
        public void CanNewTestFuzzer()
        {
            Fuzzer<EhTestModel> fuzzer = new Fuzzer<EhTestModel>();
            Assert.IsNotNull(fuzzer);
        }

        [TestMethod]
        public void FuzzStringProperty(){
            EhTestModel model = new EhTestModel();
            Fuzzer<EhTestModel> fuzzer = new Fuzzer<EhTestModel>();

            model = fuzzer.Fuzzify();

            Assert.AreNotSame(default(string), model.Name);
            Assert.AreNotSame(default(int), model.Age);
        }
    }
}
