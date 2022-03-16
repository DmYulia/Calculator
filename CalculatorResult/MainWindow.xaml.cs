using System;
using static System.Convert;
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

namespace CalculatorResult
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Задаем переменные, для работы "логики" калькулятора
        string output = "";
        string operaton = "";
        double temp = 0;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        
        //Обрабатываем содержимое нажатой кнопки
        //и в зависимости от полученного имени вносим в TextBlock
        //те или иные цифры или точку для десятичных чисел
        private void NumPudClick(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;
            switch (name)
            {
                case "ZeroBtn":
                    output += "0";
                    OutputText.Text = output;
                    break;

                case "OneBtn":
                    output += "1";
                    OutputText.Text = output;
                    break;

                case "TwoBtn":
                    output += "2";
                    OutputText.Text = output;
                    break;

                case "ThreeBtn":
                    output += "3";
                    OutputText.Text = output;
                    break;

                case "FourBtn":
                    output += "4";
                    OutputText.Text = output;
                    break;

                case "FiveBtn":
                    output += "5";
                    OutputText.Text = output;
                    break;

                case "SixBtn":
                    output += "6";
                    OutputText.Text = output;
                    break;

                case "SevenBtn":
                    output += "7";
                    OutputText.Text = output;
                    break;

                case "EightBtn":
                    output += "8";
                    OutputText.Text = output;
                    break;

                case "NineBtn":
                    output += "9";
                    OutputText.Text = output;
                    break;

                case "PointBtn":
                    if (output.Contains(","))
                    {
                        break;
                    }
                    output += ",";
                    OutputText.Text = output;
                    break;
            }
        }

        //Обрабатываем нажатия на кнопки арифметических действий
        private void MinusClick(object sender, RoutedEventArgs e)
        {
            temp = ToDouble(output);
            output = "";
            operaton = "Minus";
        }

        private void PlusClick(object sender, RoutedEventArgs e)
        {
            temp = ToDouble(output);
            output = "";
            operaton = "Plus";
        }

        private void DivideClick(object sender, RoutedEventArgs e)
        {
            temp = ToDouble(output);
            output = "";
            operaton = "Divide";
        }

        private void PowerClick(object sender, RoutedEventArgs e)
        {
            temp = ToDouble(output);
            output = "";
            operaton = "Power";
        }

        //Обрабатываем нажатие на "ИТОГО =" в зависимости от ранее нажатого арифметического оператора
        private void ResultClick(object sender, RoutedEventArgs e)
        {
            double outputTemp;
            switch (operaton)
            {
                case "Minus":
                    outputTemp = temp - ToDouble(output);
                    output = outputTemp.ToString();
                    OutputText.Text = output;
                    break;

                case "Plus":
                    outputTemp = temp + ToDouble(output);
                    output = outputTemp.ToString();
                    OutputText.Text = output;
                    break;

                case "Power":
                    outputTemp = temp * ToDouble(output);
                    output = outputTemp.ToString();
                    OutputText.Text = output;
                    break;

                case "Divide":
                        try
                        {
                            if (ToDouble(output) != 0)
                            {
                                outputTemp = temp / ToDouble(output);
                                output = outputTemp.ToString();
                            }
                            else
                            {
                                throw new Exception("Ошибка операции!");
                            }
                        }
                        catch(Exception ex)
                        {
                            output = ex.Message;
                        }
                        OutputText.Text = output;
                    break;
            }
        }

        //Обрабатываем нажатие на "+/-" (смена знака числа)
        double inv = -1;
        private void InvertClick(object sender, RoutedEventArgs e)
        {
            inv *= ToDouble(output);
            output = inv.ToString();
            OutputText.Text = output;
        }

        //Обрабатываем нажатие на "АС" (очистка дисплея)
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            temp = 0;
            operaton = "";
            output = "";
            OutputText.Text = output;
        }

    }
}
