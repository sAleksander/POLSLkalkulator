﻿using System;
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

        private string adjustResult(string number)
        {
            if (number.Length < 10)
            {
                return number;
            }
            else if(number.Contains("."))
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
                return "Out of Mem!";
            }
        }

        private void update()
        {
            string konw = display.Content.ToString();
            oldNumber = konw;
            specialClick = true;
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
            double previous = Convert.ToDouble(oldNumber);
            double current = Convert.ToDouble(display.Content.ToString());
            double result = 0;

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

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            display.Content = "0";
            oldNumber = "0";
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

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            numberWriter(".");
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            calculations();
            update();
            operation = RESET_OPERATION;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
            update();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
            update();
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
            update();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
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
    }
}

// TO DO 
/*
DODAC uzywanie operacji bez ciaglego klikania rowna się
Dodac obcinanie stringa jesli bedzie dluzszy niz 9
 */
