using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using System.IO;
using System.Threading;

/// <summary>
/// Test UI with TestStack.White
/// </summary>
namespace tWhiteTestApp.MainWindowTests
{
    [TestClass]
    public class MainWindowTests
    {
        private const string BINARY_TO_LAUNCH = @"tWhiteTestApp.exe"; //binary to launch
        private const string WINDOW_NAME = "Calculator";
        private static string m_ApplicationPath; //path to application to launch

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var applicationDirectory = Directory.GetCurrentDirectory();//path to the binary
            m_ApplicationPath = Path.Combine(applicationDirectory, BINARY_TO_LAUNCH); //initialize path to application
        }

        #region SuccessfulCalculation

        [TestMethod]
        public void SuccessfulPlusCalculation()
        {
            var window = WindowExtension.GetAppWindow(out Application application, m_ApplicationPath, WINDOW_NAME); //get window

            //test data
            var firstNumber = -15;
            var secondNumber = 2;

            window.SetTextBox("tbFirstNumber", firstNumber.ToString()); //set first textBox value

            Thread.Sleep(1000);

            window.SetTextBox("tbSecondNumber", secondNumber.ToString()); //set second textBox value

            Thread.Sleep(1000);

            window.ClickButton("btnPlus"); //perform calculation

            Thread.Sleep(1000);

            var result = window.GetTextBoxValue("tbResults"); //get result text
            var expected = $"Calculation result> {firstNumber} + {secondNumber} = {firstNumber + secondNumber}\n"; //set expected results

            Thread.Sleep(3000);

            application.Close(); //close opened application

            Assert.AreEqual(expected, result); //evaluate results
        }

        [TestMethod]
        public void SuccessfulMinusCalculation()
        {
            var window = WindowExtension.GetAppWindow(out Application application, m_ApplicationPath, WINDOW_NAME); //get window

            //test data
            var firstNumber = -15;
            var secondNumber = 2;

            window.SetTextBox("tbFirstNumber", firstNumber.ToString()); //set first textBox value

            Thread.Sleep(1000);

            window.SetTextBox("tbSecondNumber", secondNumber.ToString()); //set second textBox value

            Thread.Sleep(1000);

            window.ClickButton("btnMinus"); //perform calculation

            Thread.Sleep(1000);

            var result = window.GetTextBoxValue("tbResults"); //get result text
            var expected = $"Calculation result> {firstNumber} - {secondNumber} = {firstNumber - secondNumber}\n"; //set expected results

            Thread.Sleep(3000);

            application.Close(); //close opened application

            Assert.AreEqual(expected, result); //evaluate results
        }

        [TestMethod]
        public void SuccessfulMultiplyCalculation()
        {
            var window = WindowExtension.GetAppWindow(out Application application, m_ApplicationPath, WINDOW_NAME); //get window

            //test data
            var firstNumber = -15;
            var secondNumber = 2;

            window.SetTextBox("tbFirstNumber", firstNumber.ToString()); //set first textBox value

            Thread.Sleep(1000);

            window.SetTextBox("tbSecondNumber", secondNumber.ToString()); //set second textBox value

            Thread.Sleep(1000);

            window.ClickButton("btnMultiply"); //perform calculation

            Thread.Sleep(1000);

            var result = window.GetTextBoxValue("tbResults"); //get result text
            var expected = $"Calculation result> {firstNumber} * {secondNumber} = {firstNumber * secondNumber}\n"; //set expected results

            Thread.Sleep(3000);

            application.Close(); //close opened application

            Assert.AreEqual(expected, result); //evaluate results
        }

        [TestMethod]
        public void SuccessfulDivideCalculation()
        {
            var window = WindowExtension.GetAppWindow(out Application application, m_ApplicationPath, WINDOW_NAME); //get window

            //test data
            var firstNumber = -15.0;
            var secondNumber = 2.0;

            window.SetTextBox("tbFirstNumber", firstNumber.ToString()); //set first textBox value

            Thread.Sleep(1000);

            window.SetTextBox("tbSecondNumber", secondNumber.ToString()); //set second textBox value

            Thread.Sleep(1000);

            window.ClickButton("btnDivide"); //perform calculation

            Thread.Sleep(1000);

            var result = window.GetTextBoxValue("tbResults"); //get result text
            var expected = $"Calculation result> {firstNumber} / {secondNumber} = {firstNumber / secondNumber}\n"; //set expected results

            Thread.Sleep(3000);

            application.Close(); //close opened application

            Assert.AreEqual(expected, result); //evaluate results
        }

        #endregion

        #region exception

        [TestMethod]
        public void CantDivideByZero()
        {
            var window = WindowExtension.GetAppWindow(out Application application, m_ApplicationPath, WINDOW_NAME); //get window

            //test data
            var firstNumber = -15.0;
            var secondNumber = 0;

            window.SetTextBox("tbFirstNumber", firstNumber.ToString()); //set first textBox value

            Thread.Sleep(1000);

            window.SetTextBox("tbSecondNumber", secondNumber.ToString()); //set second textBox value

            Thread.Sleep(1000);

            window.ClickButton("btnDivide"); //perform calculation

            Thread.Sleep(1000);

            var messageBox = window.MessageBox("Can't perform divide operation"); //check message box with given caption

            Assert.IsNotNull(messageBox); //check is message box was created

            messageBox.Close(); //close message box
            application.Close(); //close appliation
        }

        #endregion
    }
}
