using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicCalculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private double firstValue = 0;
        private double secondValue = 0;
        private double finalResult = 0;
        private string _currentOperator = "";
        private bool _isOperatorClicked = false;
        private bool _isEqualClicked = false;
        public MainWindow() {
            InitializeComponent();
        }

        // 数字按钮点击事件
        private void Button_Click(object sender, RoutedEventArgs e) {
            var button = (System.Windows.Controls.Button)sender;
            string buttonText = button.Content.ToString();

            if (_isOperatorClicked) {
                secondValue = double.Parse(buttonText);
                ResultTextBox.Text = buttonText;
                _isOperatorClicked = false;
            } else {
                if (ResultTextBox.Text == "0")
                    ResultTextBox.Text = buttonText;
                else
                    ResultTextBox.Text += buttonText;
            }

            ExpressionTextBox.Text += buttonText;
        }

        // 运算符按钮点击事件
        private void Operator_Click(object sender, RoutedEventArgs e) {
            var button = (System.Windows.Controls.Button)sender;
            _currentOperator = button.Content.ToString();
            firstValue = double.Parse(ResultTextBox.Text);
            _isOperatorClicked = true;

            if (_isEqualClicked) {
                ExpressionTextBox.Text = ResultTextBox.Text + _currentOperator;
                _isEqualClicked = false;
            } else {
                ExpressionTextBox.Text += _currentOperator;
            }
        }

        // 等号按钮点击事件
        private void Equal_Click(object sender, RoutedEventArgs e) {
            double newValue = double.Parse(ResultTextBox.Text);

            if (!_isEqualClicked) {
                _isEqualClicked = true;
                ExpressionTextBox.Text += "=";
                newValue = firstValue;
            } else {
                ExpressionTextBox.Text = newValue + _currentOperator + secondValue + "=";
            }

            switch (_currentOperator) {
                case "+":
                    finalResult = newValue + secondValue;
                    break;
                case "-":
                    finalResult = newValue - secondValue;
                    break;
                case "*":
                    finalResult = newValue * secondValue;
                    break;
                case "/":
                    if (secondValue != 0)
                        finalResult = newValue / secondValue;
                    else {
                        ResultTextBox.Text = "不能除以零！";
                        return;
                    }
                    break;
            }

            ResultTextBox.Text = finalResult.ToString();
        }

        // 清除按钮点击事件
        private void Clear_Click(object sender, RoutedEventArgs e) {
            ResultTextBox.Text = "0";
            firstValue = 0;
            secondValue = 0;
            _currentOperator = "";
            _isOperatorClicked = false;
            _isEqualClicked = false;
            finalResult = 0;
            ExpressionTextBox.Text = "";
        }
    }
}