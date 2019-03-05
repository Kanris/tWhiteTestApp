using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tWhiteTestApp
{
    /// <summary>
    /// Contains data for databinding in MainWindow.xaml
    /// </summary>
    public class MainWindowDataContext : INotifyPropertyChanged
    {
        #region fields

        private double m_FirstNum; //contain data from tbFirstNumber
        private double m_SecondNum = 4; //contain data from tbSecondNumber

        private string m_CalculationResults; //contain data from tbResults

        #endregion

        //properties to notify window that value was changed
        #region properties

        public double FirstNumber
        {
            set
            {
                m_FirstNum = value;
                OnPropertyChanged();
            }
            get
            {
                return m_FirstNum;
            }
        }

        public double SecondNumber
        {
            set
            {
                m_SecondNum = value;
                OnPropertyChanged();
            }
            get
            {
                return m_SecondNum;
            }
        }

        public string CalculationResults
        {
            set
            {
                m_CalculationResults = value;
                OnPropertyChanged();
            }
            get
            {
                return m_CalculationResults;
            }
        }

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region methods

        public void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        #endregion
    }
}
