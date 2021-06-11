using ConsoleAppTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleAppTests {
    public class Tests {
        [SetUp]
        public void Setup() {
        }
        private const string result = "Entered numbers: {0} {1}\r\nSum: {2}\r\nSubtraction: {3}\r\nMultiplication: {4}\r\nDivision: {5}\r\n";
        private static IEnumerable<TestCaseData> TestSource() {
            yield return new TestCaseData("2", "3", string.Format(result, 2, 3, 5, -1, 6, 0));
            yield return new TestCaseData("2.05", "3.25", string.Format(result, 2.05, 3.25, 5.3, -1.2, 10, 0));//float 
            yield return new TestCaseData("0.05", "0.25", string.Format(result, 2, 3, 5, -1, 10, 0));//float 
            yield return new TestCaseData("0,05", "0,25", string.Format(result, 2, 3, 5, -1, 10, 0));//comma as pointer of decimal places 
            yield return new TestCaseData("0.000025", "100.762225", string.Format(result, 2, 3, 5, -1, 10, 0));//double 
            yield return new TestCaseData("-20.05", "0.25", string.Format(result, 2, 3, 5, -1, 10, 0));//negative 
            yield return new TestCaseData("-20.05", "-45.25", string.Format(result, 2, 3, 5, -1, 10, 0));//negative 
            yield return new TestCaseData("-20.05", "0", string.Format(result, 2, 3, 5, -1, 10, 0));//with 0 argument 
            yield return new TestCaseData("0", "15", string.Format(result, 2, 3, 5, -1, 10, 0));//with 0 argument 
            yield return new TestCaseData("0", "0", string.Format(result, 2, 3, 5, -1, 10, 0));//with 0 argument 
            yield return new TestCaseData("199999293", "199999292", string.Format(result, 2, 3, 5, -1, 10, 0));//with big numbers 
            yield return new TestCaseData("2000000000", "2000000000", string.Format(result, 2, 3, 5, -1, 10, 0));//check int overflow 
            yield return new TestCaseData("-199999293", "-199999292", string.Format(result, 2, 3, 5, -1, 10, 0));//with big numbers 
            yield return new TestCaseData("-2000000000", "-2000000000", string.Format(result, 2, 3, 5, -1, 10, 0));//check int overflow 
            yield return new TestCaseData(" 2", "3", string.Format(result, 2, 3, 5, -1, 10, 0));//numbers with spaces 
            yield return new TestCaseData("2", "3 ", string.Format(result, 2, 3, 5, -1, 10, 0));//numbers with spaces 
                                                                                                //Negative cases
            yield return new TestCaseData("", "", string.Format(result, 2, 3, 5, -1, 10, 0));//empty strings 
            yield return new TestCaseData(" ", " ", string.Format(result, 2, 3, 5, -1, 10, 0));//blank spaces
            yield return new TestCaseData(null, null, string.Format(result, 2, 3, 5, -1, 10, 0));//null
            yield return new TestCaseData("a", "b", string.Format(result, 2, 3, 5, -1, 10, 0));//letters 
            yield return new TestCaseData("@", "#", string.Format(result, 2, 3, 5, -1, 10, 0));//symbols 
            yield return new TestCaseData(".", "5.5", string.Format(result, 2, 3, 5, -1, 10, 0));//symbols 
            yield return new TestCaseData("Встраиваемый гипсовый светильник 79131 от ТМ Pride предназначен для монтирования его в гипсокартонный потолок. Подходит гипсовый светильник для любых помещений", "5.5", string.Format(result, 2, 3, 5, -1, 10, 0));//large text 
        }

        [TestCaseSource(nameof(TestSource))]
        public void Test1(string argument1, string argument2, string expectedResult) {
            var output = new StringWriter();
            Console.SetOut(output);
            Program.Main(new[] { argument1, argument2 });
            var result = output.ToString();
            Assert.AreEqual(expectedResult,output.ToString());
        }
    }
}