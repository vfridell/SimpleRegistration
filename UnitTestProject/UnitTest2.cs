using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CheckCapitalize()
        {
            string s = "foo";
            string sUpper = Capitalize(s);
            Assert.IsTrue(Char.IsUpper(sUpper[0]));
            Assert.IsTrue(sUpper.Substring(1).All(c => Char.IsLower(c)));
        }

        [TestMethod]
        public void CheckCapitalize2()
        {
            string s = "foo";
            Capitalize(s);
            Assert.IsTrue(Char.IsUpper(s[0]));
            Assert.IsTrue(s.Substring(1).All(c => Char.IsLower(c)));
        }

        [TestMethod]
        public void CheckTotalEven()
        {
            int[] array = new int[5] { 2, 3, 6, 8, 9 };
            Assert.AreEqual(16, TotalEven(array));
        }

        [TestMethod]
        public void CheckTotalEven2()
        {
            int[] array = new int[5] { 2, 3, 6, 8, 9 };
            Assert.AreEqual(16, TotalEven2(array));
        }

        [TestMethod]
        public void CheckFirstRepeat()
        {
            int[] array = new int[10] { 2, 3, 6, 8, 9, 100, 90, 8, 100, 2 };
            Assert.AreEqual(8, FirstRepeat(array));
        }

        [TestMethod]
        public void CheckFirstRepeatNull()
        {
            int[] array = new int[10] { 2, 3, 6, 8, 9, 101, 91, 81, 1045, 22 };
            Assert.AreEqual(null, FirstRepeat(array));
        }

        public string Capitalize(string s)
        {
            return Char.ToUpper(s[0]) +  s.Substring(1);
        }

        public void Capitalize2(string s)
        {
            //s[0] = char.ToUpper(s[0]);
            s = Char.ToUpper(s[0]) + s.Substring(1);
        }

        public int TotalEven(int [] array)
        {
            int total = 0;
            foreach (int i in array) total += (i % 2 == 0) ? i : 0;
            return total;
        }

        public int TotalEven2(int[] array)
        {
            return array.Where(i => i % 2 == 0).Sum(i => i);
        }

        public int? FirstRepeat(int [] array)
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach(int i in array)
            {
                if (hashSet.Contains(i)) return i;
                hashSet.Add(i);
            }
            return null;
        }
    }
}
