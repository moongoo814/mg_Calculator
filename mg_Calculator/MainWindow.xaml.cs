using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
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



namespace mg_Calculator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        double lastNumber; // 연산하기 전 값 저장 변수
        double result; // 연산 후 값 저장 변수
        bool Emptycheck = false;

        SelectedOperator selectedOperator;



        public enum SelectedOperator
        {
            plus,
            minus,
            multi,
            div
        }

        public class SimpleMath
        {

            public static double Plus(double n1, double n2)
            {
                return n1 + n2;
            }

            public static double Minus(double n1, double n2)
            {
                return n1 - n2;
            }

            public static double Multiple(double n1, double n2)
            {
                return n1 * n2;
            }

            public static double Divide(double n1, double n2)
            {
                return n1 / n2;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            ///Result Label code
            Grid.SetRow(ResultLabel, 0);
            Grid.SetColumnSpan(ResultLabel, 4);
            ResultLabel.HorizontalAlignment = HorizontalAlignment.Right;
            ResultLabel.VerticalAlignment = VerticalAlignment.Bottom;
            ResultLabel.Text = "0";
            ResultLabel.Margin = new Thickness(0, 0, 10, 0);
            ResultLabel.Foreground = Brushes.White;
            ResultLabel.FontSize = 80;


            ///Num 0 Button code
            Grid.SetColumn(ZeroButton, 0);
            Grid.SetRow(ZeroButton, 5);
            Grid.SetColumnSpan(ZeroButton, 2);
            ZeroButton.HorizontalContentAlignment = HorizontalAlignment.Left;
            ZeroButton.VerticalContentAlignment = VerticalAlignment.Center;
            ZeroButton.Content = "0";
            ZeroButton.Margin = new Thickness(5, 10, 10, 5);
            ZeroButton.Padding = new Thickness(20, 0, 0, 0);
            ZeroButton.Foreground = Brushes.White;
            ZeroButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            ZeroButton.FontSize = 30;
            ZeroButton.Click += numberButton_Click;

            ///Dot Button Code
            Grid.SetColumn(DotButton, 2);
            Grid.SetRow(DotButton, 5);
            DotButton.Content = ".";
            DotButton.Margin = new Thickness(5, 10, 10, 5);
            DotButton.Foreground = Brushes.White;
            DotButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            DotButton.FontSize = 30;
            DotButton.Click += DotButton_Click;

            ///Result Button code
            Grid.SetColumn(ResultButton, 3);
            Grid.SetRow(ResultButton, 5);
            ResultButton.Content = "=";
            ResultButton.Foreground = Brushes.White;
            ResultButton.Background = Brushes.Orange;
            ResultButton.Margin = new Thickness(5, 10, 10, 5);
            ResultButton.FontSize = 35;
            ResultButton.Click += ResultButton_Click;

            ///Num 1 Button code
            Grid.SetColumn(OneButton, 0);
            Grid.SetRow(OneButton, 4);
            OneButton.Content = "1";
            OneButton.Foreground = Brushes.White;
            OneButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            OneButton.Margin = new Thickness(5, 10, 10, 5);
            OneButton.FontSize = 30;
            OneButton.Click += numberButton_Click;

            ///Num 2 Button code
            Grid.SetColumn(TwoButton, 1);
            Grid.SetRow(TwoButton, 4);
            TwoButton.Content = "2";
            TwoButton.Foreground = Brushes.White;
            TwoButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            TwoButton.Margin = new Thickness(5, 10, 10, 5);
            TwoButton.FontSize = 30;
            TwoButton.Click += numberButton_Click;

            ///Num 3 Button code
            Grid.SetColumn(ThreeButton, 2);
            Grid.SetRow(ThreeButton, 4);
            ThreeButton.Content = "3";
            ThreeButton.Foreground = Brushes.White;
            ThreeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            ThreeButton.Margin = new Thickness(5, 10, 10, 5);
            ThreeButton.FontSize = 30;
            ThreeButton.Click += numberButton_Click;

            /// + Button code
            Grid.SetColumn(PlusButton, 3);
            Grid.SetRow(PlusButton, 4);
            PlusButton.Content = "+";
            PlusButton.Foreground = Brushes.White;
            PlusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9933"));
            PlusButton.Margin = new Thickness(5, 10, 10, 5);
            PlusButton.FontSize = 35;
            PlusButton.Click += OperationButton_click;

            ///Num 4 Button code
            Grid.SetColumn(Fourbutton, 0);
            Grid.SetRow(Fourbutton, 3);
            Fourbutton.Content = "4";
            Fourbutton.Foreground = Brushes.White;
            Fourbutton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            Fourbutton.Margin = new Thickness(5, 10, 10, 5);
            Fourbutton.FontSize = 30;
            Fourbutton.Click += numberButton_Click;

            ///Num 5 Button code
            Grid.SetColumn(FiveButton, 1);
            Grid.SetRow(FiveButton, 3);
            FiveButton.Content = "5";
            FiveButton.Foreground = Brushes.White;
            FiveButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            FiveButton.Margin = new Thickness(5, 10, 10, 5);
            FiveButton.FontSize = 30;
            FiveButton.Click += numberButton_Click;

            ///Num 6 Button code
            Grid.SetColumn(SixButton, 2);
            Grid.SetRow(SixButton, 3);
            SixButton.Content = "6";
            SixButton.Foreground = Brushes.White;
            SixButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            SixButton.Margin = new Thickness(5, 10, 10, 5);
            SixButton.FontSize = 30;
            SixButton.Click += numberButton_Click;

            /// - Button code
            Grid.SetColumn(MinusButton, 3);
            Grid.SetRow(MinusButton, 3);
            MinusButton.Content = "-";
            MinusButton.Foreground = Brushes.White;
            MinusButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9933"));
            MinusButton.Margin = new Thickness(5, 10, 10, 5);
            MinusButton.FontSize = 35;
            MinusButton.Click += OperationButton_click;

            ///Num 7 Button code
            Grid.SetColumn(SevenButton, 0);
            Grid.SetRow(SevenButton, 2);
            SevenButton.Content = "7";
            SevenButton.Foreground = Brushes.White;
            SevenButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            SevenButton.Margin = new Thickness(5, 10, 10, 5);
            SevenButton.FontSize = 30;
            SevenButton.Click += numberButton_Click;

            ///Num 8 Button code
            Grid.SetColumn(EightButton, 1);
            Grid.SetRow(EightButton, 2);
            EightButton.Content = "8";
            EightButton.Foreground = Brushes.White;
            EightButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            EightButton.Margin = new Thickness(5, 10, 10, 5);
            EightButton.FontSize = 30;
            EightButton.Click += numberButton_Click;

            ///Num 9 Button code
            Grid.SetColumn(NineButton, 2);
            Grid.SetRow(NineButton, 2);
            NineButton.Content = "9";
            NineButton.Foreground = Brushes.White;
            NineButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#404040"));
            NineButton.Margin = new Thickness(5, 10, 10, 5);
            NineButton.FontSize = 30;
            NineButton.Click += numberButton_Click;

            /// X Button code
            Grid.SetColumn(MultiButton, 3);
            Grid.SetRow(MultiButton, 2);
            MultiButton.Content = "X";
            MultiButton.Foreground = Brushes.White;
            MultiButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9933"));
            MultiButton.Margin = new Thickness(5, 10, 10, 5);
            MultiButton.FontSize = 30;
            MultiButton.Click += OperationButton_click;

            /// clear Button code
            Grid.SetColumn(ClearButton, 0);
            Grid.SetRow(ClearButton, 1);
            ClearButton.Content = "AC";
            ClearButton.Foreground = Brushes.Black;
            ClearButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
            ClearButton.Margin = new Thickness(5, 10, 10, 5);
            ClearButton.FontSize = 30;
            ClearButton.Click += ClearButton_Click;

            /// Buho Button code
            Grid.SetColumn(BuhoButton, 1);
            Grid.SetRow(BuhoButton, 1);
            BuhoButton.Content = "+/-";
            BuhoButton.Foreground = Brushes.Black;
            BuhoButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
            BuhoButton.Margin = new Thickness(5, 10, 10, 5);
            BuhoButton.FontSize = 30;
            BuhoButton.Click += BuhoButton_Click;

            /// Percent Button code
            Grid.SetColumn(PercentButton, 2);
            Grid.SetRow(PercentButton, 1);
            PercentButton.Content = "%";
            PercentButton.Foreground = Brushes.Black;
            PercentButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
            PercentButton.Margin = new Thickness(5, 10, 10, 5);
            PercentButton.FontSize = 30;
            PercentButton.Click += PercentButton_Click;

            /// Devide Button code
            Grid.SetColumn(DevideButton, 3);
            Grid.SetRow(DevideButton, 1);
            DevideButton.Content = "÷";
            DevideButton.Foreground = Brushes.White;
            DevideButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9933"));
            DevideButton.Margin = new Thickness(5, 10, 10, 5);
            DevideButton.FontSize = 35;
            DevideButton.Click += OperationButton_click;
        }


        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (Emptycheck == false) 
            {
                ResultLabel.Text = string.Empty;
                Emptycheck = true;
            }

            

            if (sender == ZeroButton)
            {
                selectedValue = 0;
                if(ResultLabel.Text.ToString() == "0")
                {
                    ResultLabel.Text = selectedValue.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }
            if(sender == OneButton)
            {
                selectedValue = 1;
                if(ResultLabel.Text.ToString() == "1")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if(sender == TwoButton)
            {
                selectedValue = 2;
                if (ResultLabel.Text.ToString() == "2")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == ThreeButton)
            {
                selectedValue = 3;
                if (ResultLabel.Text.ToString() == "3")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == Fourbutton)
            {
                selectedValue = 4;
                if (ResultLabel.Text.ToString() == "4")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == FiveButton)
            {
                selectedValue = 5;
                if (ResultLabel.Text.ToString() == "5")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == SixButton)
            {
                selectedValue = 6;
                if (ResultLabel.Text.ToString() == "6")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == SevenButton)
            {
                selectedValue = 7;
                if (ResultLabel.Text.ToString() == "7")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == EightButton)
            {
                selectedValue = 8;
                if (ResultLabel.Text.ToString() == "8")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }

            if (sender == NineButton)
            {
                selectedValue = 9;
                if (ResultLabel.Text.ToString() == "9")
                {
                    ResultLabel.Text.ToString();
                }
                else
                {
                    ResultLabel.Text += selectedValue.ToString();
                }
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Text = string.Empty;
            
            ResultLabel.Text = "0";
            Emptycheck = false;
        }

        private void BuhoButton_Click(object sender, RoutedEventArgs e)
        {
            double lastNumber;
            if (double.TryParse(ResultLabel.Text.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Text = lastNumber.ToString();
            }
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(ResultLabel.Text.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * 0.01;
                ResultLabel.Text = lastNumber.ToString();
            }
        }

        private void DevideButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MultiButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinuxButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            newNumber = double.Parse(ResultLabel.Text.ToString());
            switch(selectedOperator)
            {
                case SelectedOperator.plus:
                    result = SimpleMath.Plus(lastNumber, newNumber);
                    break;

                case SelectedOperator.minus:
                    result = SimpleMath.Minus(lastNumber, newNumber);
                    break;

                case SelectedOperator.multi:
                    result = SimpleMath.Multiple(lastNumber, newNumber);
                    break;

                case SelectedOperator.div:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }
            ResultLabel.Text = result.ToString();
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean a;
            a = ResultLabel.Text.ToString().Contains(".");
            if(ResultLabel.Text.ToString() == "0")
            {
                return;
            }
            else
            {
                if(a==false)
                {
                    ResultLabel.Text += ".";
                }
            }
        }

        private void OperationButton_click(object sender, RoutedEventArgs e)
        {

        }

        private void DevideButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
