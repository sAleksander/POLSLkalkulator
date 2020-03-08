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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string RESET_OPERATION = "!";
        private string operation = RESET_OPERATION;
        private string oldNumber = "0";
        private string currentStatus = "0";
        private bool specialClick = false;
        private bool firstOperation = true;
        private string message = "Out of Mem";

        private void test()
        {
            tLabel1.Content = oldNumber;
            tLabel2.Content = currentStatus;
        }

        private string adjustResult(string number)
        {
            if (oldNumber == message)
            {
                return message;
            }
            if (number.Length < 10)
            {
                return number;
            }
            else if (number.Contains("."))
            {
                string adjusted = "";
                for (int i = 0; i < 9; i++)
                {
                    adjusted += number[i];
                }
                return adjusted;
            }
            else
            {
                oldNumber = "0";
                return message;
            }
        }

        private void update()
        {
            string konw = display.Content.ToString();
            oldNumber = konw;
            specialClick = true;
        }

        private void handleFirstOperation()
        {
            if (!firstOperation)
            {
                calculations();
            }
            else
            {
                firstOperation = false;
            }

        }

        private void numberWriter(string number)
        {
            currentStatus = display.Content.ToString();
            if (specialClick)
            {
                currentStatus = "0";
                specialClick = false;
            }
            if (currentStatus.Length >= 9)
            {
                return;
            }
            else
            {
                if (number == ".")
                {
                    if (currentStatus.Contains('.'))
                    {
                        numberWriter("-");
                        return;
                    }
                    else
                    {
                        currentStatus += number;
                        display.Content = currentStatus;
                        return;
                    }
                }
                else if (currentStatus == "0")
                {
                    currentStatus = "";
                    currentStatus += number;
                    display.Content = currentStatus;
                }
                else
                {
                    currentStatus += number;
                    display.Content = currentStatus;
                }
            }
        }

        private void calculations()
        {
            test();
            double previous = 0.0;
            double current = 0.0;
            double result = 0.0;
            if (oldNumber != message)
            {
                previous = Convert.ToDouble(oldNumber);
                current = Convert.ToDouble(display.Content.ToString());
            }
            result = 0.0;
            switch (operation)
            {
                case "+":
                    result = previous + current;
                    break;
                case "-":
                    result = previous - current;
                    break;
                case "*":
                    result = previous * current;
                    break;
                case "/":
                    result = previous / current;
                    break;
            }
            display.Content = adjustResult(result.ToString());
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            numberWriter(".");
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            calculations();
            update();
            operation = RESET_OPERATION;
            firstOperation = true;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
            handleFirstOperation();
            update();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
            handleFirstOperation();
            update();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
            handleFirstOperation();
            update();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
            handleFirstOperation();
            update();
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (display.Content.ToString().Contains("-"))
            {
                display.Content = display.Content.ToString().Replace("-", "");
            }
            else
            {
                display.Content = "-" + display.Content.ToString();
            }
        }

        private void resetCalc()
        {
            display.Content = "0";
            operation = RESET_OPERATION;
            firstOperation = true;
            oldNumber = "0";
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            resetCalc();
        }


        private void One_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("1");
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("2");
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("3");
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("4");
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("5");
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("6");
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("7");
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("8");
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("9");
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            numberWriter("0");
        }
    }
}
