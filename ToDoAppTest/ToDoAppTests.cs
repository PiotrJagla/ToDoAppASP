using Org.BouncyCastle.Asn1.Cmp;
using TODOapp;

namespace ToDoAppTest
{
    [TestClass]
    public class ToDoAppTests
    {
        [TestMethod]
        public void addSpacesToStringTest()
        {
            Assert.IsTrue(
                StringManipulation.addSpaceBeforeBigLetter("CiekaweCzyDziala") == "Ciekawe Czy Dziala"
            );

        }

        [TestMethod]
        public void removeCharFromString()
        {
            Assert.IsTrue(
                StringManipulation.removeCharFromString("Remove all Spaces", ' ') == "RemoveallSpaces"
            );
        }

        [TestMethod]
        public void extractStringsSeparatedByCharTest()
        {
            List<string> stringsSeparatedByFunctions = StringManipulation.extractStrinsSeparatedByChar(
                "-To-Jest--Wydzielone-Przez-myslniki-", '-'
            );

            List<string> expectedListOfStrings = new List<string>();
            expectedListOfStrings.Add("To");
            expectedListOfStrings.Add("Jest");
            expectedListOfStrings.Add("Wydzielone");
            expectedListOfStrings.Add("Przez");
            expectedListOfStrings.Add("myslniki");

            for (int iii = 0; iii < expectedListOfStrings.Count; ++iii)
            {
                Assert.IsTrue(expectedListOfStrings[iii] == stringsSeparatedByFunctions[iii]);
            }
        }

        [TestMethod]
        public void inputValidationTest_CorrectInput()
        {
            string taskName = "Do the dishes";
            string taskDeadline = "2022-09-18 20-45-15";
            string taskImportance = "Not important";

            Assert.IsTrue(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));
        }

        [TestMethod]
        public void inputValidationTest_IncorrectName()
        {
            string taskName = "Do the dishes and do meal and do washing and you can do sleep";
            string taskDeadline = "2022-09-18 20-45-15";
            string taskImportance = "Not important";

            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));
        }

        [TestMethod]
        public void inputValidationTest_IncorrectDeadline()
        {
            string taskName = "Do the dishes";
            string taskDeadline = "2022-18-30  20-45-15";
            string taskImportance = "Not important";

            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));

            taskDeadline = "2011-02-29 20-45-15";
            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));

            taskDeadline = "2022-02-15 25-45-15";
            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));

            taskDeadline = "2022-02-15 20-45-61";
            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));

            taskDeadline = "2022-04-31 20-45-15";
            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));
        }

        [TestMethod]
        public void inputValidationTest_IncorrectImportance()
        {
            string taskName = "Do the dishes";
            string taskDeadline = "2022-05-04 20-45-15";
            string taskImportance = "the most important";

            Assert.IsFalse(InputValidation.isInputCorrect(
                taskName, taskDeadline, taskImportance));
        }
    }
}