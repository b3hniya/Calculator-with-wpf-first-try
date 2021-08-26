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

namespace Project1
{
    public partial class MainWindow : Window
    {
        //-------------------PROPERTIES ARE HERE--------------------------
        private double _firstNumber;
        private double _secondNumber;
        private Operations _selectendOperation;

        public double ResultNumber
        {
            get => Convert.ToDouble(resultNumber.Content.ToString());
            set => resultNumber.Content = value.ToString();
        }

        //---------------------METHODS ARE HERE---------------------------
        public MainWindow()
            => InitializeComponent();

        private void AcBtn_Click(object sender, RoutedEventArgs e)
            => _firstNumber = _secondNumber = ResultNumber = 0;

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
            => _secondNumber = ResultNumber *= -1;

        private void PrecentageBtn_Click(object sender, RoutedEventArgs e)
            => _secondNumber = ResultNumber /= 100;

        private void PointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultNumber.ToString().Contains("."))
                resultNumber.Content = resultNumber.Content.ToString() + ".";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            var number = (sender as Button).Content.ToString();

            if (ResultNumber == 0) 
                resultNumber.Content = number;
            else 
                resultNumber.Content += number;

            _secondNumber = ResultNumber;
        }

        private void OperationSelection_Click(object sender, RoutedEventArgs e)
        {
            var op = (sender as Button).Content.ToString();

            if (op == "/")
                _selectendOperation = Operations.Divide;
            if (op == "*")
                _selectendOperation = Operations.Multiply;
            if (op == "+")
                _selectendOperation = Operations.Addition;
            if (op == "-")
                _selectendOperation = Operations.Subtract;

            _firstNumber = ResultNumber;
            _secondNumber = 0;
            ResultNumber = 0;
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {

            if (_selectendOperation == Operations.Divide)
                ResultNumber = CalculatorMath.Division(_firstNumber, _secondNumber);

            if (_selectendOperation == Operations.Addition)
                ResultNumber = CalculatorMath.Addition(_firstNumber, _secondNumber);

            if (_selectendOperation == Operations.Multiply)
                ResultNumber = CalculatorMath.Multiplication(_firstNumber, _secondNumber);

            if (_selectendOperation == Operations.Subtract)
                ResultNumber = CalculatorMath.Subtraction(_firstNumber, _secondNumber);

            _firstNumber = ResultNumber;
        }
    }
}
