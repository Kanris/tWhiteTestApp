using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tWhiteTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowHandler m_MainWindowHandler; //main window handler

        public MainWindow()
        {
            InitializeComponent();

            m_MainWindowHandler = new MainWindowHandler();
            this.DataContext = m_MainWindowHandler.DataContext; //set data context
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var displayString = (sender as Button).Content.ToString(); //get button text (equals to operation)
                //MessageBox.Show(displayString);
                m_MainWindowHandler?.Calculate(displayString); //call calculation method
            }
            catch (DivideByZeroException ex) //catch divide by zero exception
            {
                MessageBox.Show($"Can't divide by zero", "Can't perform divide operation"); //display error to the user
            }
        }
    }
}
