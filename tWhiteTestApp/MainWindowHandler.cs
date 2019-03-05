using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tWhiteTestApp
{
    /// <summary>
    /// Contains method to perform in MainWindow.xaml.cs
    /// </summary>
    public class MainWindowHandler
    {
        #region fields

        private MainWindowDataContext m_DataContext; //main window data context
        private delegate double DoubleDelegate(); //delegate to perform calculation

        #endregion fields

        #region properties

        /// <summary>
        /// returns data context of MainWindow
        /// </summary>
        public MainWindowDataContext DataContext
        {
            get
            {
                return m_DataContext;
            }
        }

        #endregion properties

        #region initialize

        /// <summary>
        /// Initialize fields
        /// </summary>
        public MainWindowHandler()
        {
            m_DataContext = new MainWindowDataContext(); //initialize data context
        }

        #endregion initialize

        #region perform calculation methods

        /// <summary>
        /// Perform Calculation base on the input operation
        /// </summary>
        /// <param name="operation">Operation sign</param>
        public void Calculate(string operation)
        {
            switch (operation)
            {
                case "+":
                    PerformPlusCalculation();
                    break;

                case "-":
                    PerformMinusCalculation();
                    break;

                case "*":
                    PerformMultiplyCalculation();
                    break;

                case "/":
                    PerformDivideCalculation();
                    break;
            }
        }

        /// <summary>
        /// Perform and display in CalculationResults Plus operation
        /// </summary>
        private void PerformPlusCalculation()
        {
            if (IsDataContextReady())
            {
                m_DataContext.CalculationResults += PerformCalculation('+', () => m_DataContext.FirstNumber + m_DataContext.SecondNumber);
            }
        }

        /// <summary>
        /// Perform and display in CalculationResults Minus operation
        /// </summary>
        private void PerformMinusCalculation()
        {
            if (IsDataContextReady())
            {
                m_DataContext.CalculationResults += PerformCalculation('-', () => m_DataContext.FirstNumber - m_DataContext.SecondNumber);
            }
        }

        /// <summary>
        /// Perform and display in CalculationResults Multiply operation
        /// </summary>
        private void PerformMultiplyCalculation()
        {
            if (IsDataContextReady())
            {
                m_DataContext.CalculationResults += PerformCalculation('*', () => m_DataContext.FirstNumber * m_DataContext.SecondNumber);
            }
        }

        /// <summary>
        /// Perform and display in CalculationResults Divide operation
        /// </summary>
        private void PerformDivideCalculation()
        {
            if (IsDataContextReady())
            {
                if (IsDividerZero())
                    throw new DivideByZeroException();

                m_DataContext.CalculationResults += PerformCalculation('/', () => m_DataContext.FirstNumber / m_DataContext.SecondNumber );
            }
        }

        /// <summary>
        /// Generic method that parform operation and form result for methods
        /// </summary>
        private string PerformCalculation(char operation, DoubleDelegate operationToPerform)
        {
            return $"Calculation result> {m_DataContext.FirstNumber} {operation} {m_DataContext.SecondNumber} = {operationToPerform?.Invoke().ToString()}\n";
        }

        #endregion perform calculation methods

        #region check data

        /// <summary>
        /// Check is DataContext is not null
        /// </summary>
        /// <returns>True if datacontext has reference; False if datacontext is null</returns>
        private bool IsDataContextReady()
        {
            return !ReferenceEquals(m_DataContext, null);
        }

        /// <summary>
        /// Check is SecondNumber is equal to zero
        /// </summary>
        /// <returns>True if SecondNumber is Equal to zero; False if SecondNubmer is Not Equal to zero</returns>
        private bool IsDividerZero()
        {
            return DataContext.SecondNumber == 0;
        }

        #endregion check data
    }
}
