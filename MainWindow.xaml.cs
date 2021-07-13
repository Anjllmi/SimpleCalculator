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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber = 0;
        private double number = 0;
        char? operationSign = null;
        Operation? operation = null;

        public MainWindow()
        {
            InitializeComponent();
            
            
            //Crea Event Handlers para algunos botones
            Button_Clear.Click += Button_Clear_Click;
            Button_ClearAll.Click += Button_ClearAll_Click;
            Button_Equal.Click += Button_Equal_Click;
            Button_PlusMinus.Click += Button_PlusMinus_Click;

            Button_Percentage.Click += Button_Operation_Click;
            Button_Division.Click += Button_Operation_Click;
            Button_Multiply.Click += Button_Operation_Click;
            Button_Subtract.Click += Button_Operation_Click;
            Button_Sum.Click += Button_Operation_Click;
            Button_Comma.Click += Button_Comma_Click;
        }

        private void Button_Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!Label_Result.Content.ToString().Contains(","))
            {
                Label_Result.Content += ",";
            }
        }

        private void Button_PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(Label_Result.Content.ToString(),out double value);
            Label_Result.Content = value * (-1);
        }

        private void Button_Equal_Click(object sender, RoutedEventArgs e)
        {
            if (operation != null)
            {
                double.TryParse(Label_LastResult.Content.ToString().Substring(0, Label_LastResult.Content.ToString().Length - 1), out lastNumber);
                double.TryParse(Label_Result.Content.ToString(), out number);

                switch (operation)
                {
                    case Operation.Sum:
                        Label_LastResult.Content = lastNumber.Sum(number);
                        break;
                    case Operation.Subtract:
                        Label_LastResult.Content = lastNumber.Subtract(number);
                        break;
                    case Operation.Multiply:
                        Label_LastResult.Content = lastNumber.Multiply(number);
                        break;
                    case Operation.Division:
                        Label_LastResult.Content = lastNumber.Divide(number);
                        break;
                    case Operation.Percentage:
                        Label_LastResult.Content = lastNumber.Percentage(number);
                        break;
                }
                Label_LastResult.Content = $"{Label_LastResult.Content}";
            }
            else
            {
                Label_LastResult.Content = $"{Label_Result.Content}";
            }
            operation = null;
            Label_Result.Content = "0";
        }

        private void Button_ClearAll_Click(object sender, RoutedEventArgs e)
        {
            Label_Result.Content = "0";
            Label_LastResult.Content = "0";
            operation = null;
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Label_Result.Content = "0";
        }
        
        private void Button_Backspace_Click(object sender, RoutedEventArgs e)
        {
            Label_Result.Content = Label_Result.Content.ToString()
                .Substring(0, Label_Result.Content.ToString().Length - 1);   
        }

        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            if (operation != null && 
                (Label_LastResult.Content.ToString().Contains("+") 
                || Label_LastResult.Content.ToString().Contains("-")
                || Label_LastResult.Content.ToString().Contains("x")
                || Label_LastResult.Content.ToString().Contains("÷")
                || Label_LastResult.Content.ToString().Contains("%")))
            {
                double.TryParse(Label_LastResult.Content.ToString().Substring(0, Label_LastResult.Content.ToString().Length - 1), out lastNumber);
                double.TryParse(Label_Result.Content.ToString(), out number);

                switch (operation)
                {
                    case Operation.Sum:
                        Label_LastResult.Content = lastNumber.Sum(number);
                        break;
                    case Operation.Subtract:
                        Label_LastResult.Content = lastNumber.Subtract(number);
                        break;
                    case Operation.Multiply:
                        Label_LastResult.Content = lastNumber.Multiply(number);
                        break;
                    case Operation.Division:
                        Label_LastResult.Content = lastNumber.Divide(number);
                        break;
                    case Operation.Percentage:
                        Label_LastResult.Content = lastNumber.Percentage(number);
                        break;
                }

                if (sender == Button_Sum) operation = Operation.Sum;
                if (sender == Button_Subtract) operation = Operation.Subtract;
                if (sender == Button_Multiply) operation = Operation.Multiply;
                if (sender == Button_Division) operation = Operation.Division;
                if (sender == Button_Percentage) operation = Operation.Percentage;

                switch (operation)
                {
                    case Operation.Sum:
                        operationSign = '+';
                        break;
                    case Operation.Subtract:
                        operationSign = '-';
                        break;
                    case Operation.Multiply:
                        operationSign = 'x';
                        break;
                    case Operation.Division:
                        operationSign = '÷';
                        break;
                    case Operation.Percentage:
                        operationSign = '%';
                        break;
                }
                Label_LastResult.Content = $"{Label_LastResult.Content}{operationSign}";
            }
            else if(operation==null && Label_LastResult.Content.ToString().Equals("0"))
            {
                if (sender == Button_Sum) operation = Operation.Sum;
                if (sender == Button_Subtract) operation = Operation.Subtract;
                if (sender == Button_Multiply) operation = Operation.Multiply;
                if (sender == Button_Division) operation = Operation.Division;
                if (sender == Button_Percentage) operation = Operation.Percentage;

                switch (operation)
                {
                    case Operation.Sum:
                        operationSign = '+';
                        break;
                    case Operation.Subtract:
                        operationSign = '-';
                        break;
                    case Operation.Multiply:
                        operationSign = 'x';
                        break;
                    case Operation.Division:
                        operationSign = '÷';
                        break;
                    case Operation.Percentage:
                        operationSign = '%';
                        break;
                }

                Label_LastResult.Content = $"{Label_Result.Content}{operationSign}";
            }
            else
            {
                if (sender == Button_Sum) operation = Operation.Sum;
                if (sender == Button_Subtract) operation = Operation.Subtract;
                if (sender == Button_Multiply) operation = Operation.Multiply;
                if (sender == Button_Division) operation = Operation.Division;
                if (sender == Button_Percentage) operation = Operation.Percentage;

                switch (operation)
                {
                    case Operation.Sum:
                        operationSign = '+';
                        break;
                    case Operation.Subtract:
                        operationSign = '-';
                        break;
                    case Operation.Multiply:
                        operationSign = 'x';
                        break;
                    case Operation.Division:
                        operationSign = '÷';
                        break;
                    case Operation.Percentage:
                        operationSign = '%';
                        break;
                }

                Label_LastResult.Content = $"{Label_LastResult.Content}{operationSign}";
            }
            Label_Result.Content = "0";
        }

        //private static Func<int, int, int> FSum = (a, b) => a + b;

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(Label_Result.Content.ToString(), out double value);
            Label_Result.Content = value != 0 ? $"{Label_Result.Content}{(sender as Button).Content}" : (sender as Button).Content.ToString();
        }
    }

    public enum Operation
    {
        Sum,
        Subtract,
        Multiply,
        Division,
        Percentage
    }

    public static class OperationsExtensions
    {
        public static double Sum(this double a, double b) => a + b;

        public static double Subtract(this double a, double b) => a - b;

        public static double Multiply(this double a, double b) => a * b;

        public static double Divide(this double a, double b) => a / b;

        public static double Percentage(this double a, double b) => a / 100 * b;
    }
}
