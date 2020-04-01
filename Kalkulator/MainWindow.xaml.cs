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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            if ((string)labelScreen.Content == "Podaj działanie:")
            {
                labelScreen.Content = "";
            }
            if ((string)labelScreen.Content == "0")
            {
                labelScreen.Content = "";
            }

            var button = sender as Button;
            string num = button.Content.ToString();

            
            
            if (num == ",")
            {
                string lab = (string)labelScreen.Content;
                string labLast = lab.Substring(lab.Length-1, 1);
                if (labLast == "," || labLast == "-" || labLast == "+" || labLast == "*" || labLast == "/")
                {
                    return;
                }
            }
            
            labelScreen.Content += num;
            
        }

        private void btnSuma_Click(object sender, RoutedEventArgs e)
        {
            
            string suma = (string)labelScreen.Content;
            
            double newSuma = 0.0;
            int indexOfOp = 0;
            char op = ' ';
            double a = 0, b = 0;
            if (suma != "")
            {

                if (suma.Contains('+'))
                {
                    op = '+';
                    indexOfOp = suma.IndexOf('+');

                }
                else if (suma.Contains('-'))
                {
                    op = '-';
                    indexOfOp = suma.IndexOf('-');
                }
                else if (suma.Contains('*'))
                {
                    op = '*';
                    indexOfOp = suma.IndexOf('*');
                }
                else if (suma.Contains('/'))
                {
                    op = '/';
                    indexOfOp = suma.IndexOf('/');
                }
                else
                {
                    return;
                }

                try
                {
                    a = Convert.ToDouble(suma.Substring(0, indexOfOp));
                    b = Convert.ToDouble(suma.Substring(indexOfOp + 1, suma.Length - indexOfOp - 1));
                }
                catch (Exception)
                {
                    MessageBox.Show($"Podałeś wyrażenie z wieloma operatorami!");                    
                }
                

                switch (op)
                {
                    case '+':
                        newSuma = a + b;
                        break;
                    case '-':
                        newSuma = a - b;
                        break;
                    case '*':
                        newSuma = a * b;
                        break;
                    case '/':
                        newSuma = a / b;
                        break;
                    default:
                        break;
                }
                
                labelScreen.Content = newSuma.ToString();

            }
        }

        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string op = button.Content.ToString();

            labelScreen.Content += op;
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            labelScreen.Content = "";
        }
    }
}
