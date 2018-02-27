using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGenerator;

namespace ModelTest
{
    [TestClass]
    public class PGModelTest
    {
        [TestMethod]
        public void TestGetRandomString()
        {
            Debug.Print($"{PasswordGeneratorModel.GetRandomString(4)}");
        }

        [TestMethod]
        public void TestGetPaswordList()
        {
            int i = 0;
            foreach (var var in PasswordGeneratorModel.GetPasswords(5, 10))
            {
                Debug.Print($"{i++} - {var}");
            }
        }
    }
}