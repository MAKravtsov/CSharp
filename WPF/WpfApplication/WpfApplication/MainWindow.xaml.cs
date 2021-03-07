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

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftop = ""; // Левый операнд
        string operation = ""; // Знак операции
        string rightop = ""; // Правый операнд

        public MainWindow()
        {
            InitializeComponent();

            foreach (var child in LayoutRoot.Children)
            {
                if (child is Button button)
                {
                    button.Click += OnClick;
                }
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            string str = ((Button) e.OriginalSource).Content.ToString();

            textBlock.Text += str;

            bool isNum = int.TryParse(str, out int num);

            if (isNum)
            {
                if (string.IsNullOrEmpty(operation))
                {
                    leftop += str;
                    return;
                }

                rightop += str;
                return;
            }

            switch (str)
            {
                // Если равно, то выводим результат операции
                // Очищаем поле и переменные
                case "=":
                    Update_RightOp();
                    textBlock.Text += rightop;
                    operation = "";
                    break;
                // Получаем операцию
                case "CLEAR":
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                    break;
                default:
                {
                    // Если правый операнд уже имеется, то присваиваем его значение левому
                    // операнду, а правый операнд очищаем
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = str;
                    break;
                }
            }
        }

        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);
            // И выполняем операцию
            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
            }
        }
    }
}
