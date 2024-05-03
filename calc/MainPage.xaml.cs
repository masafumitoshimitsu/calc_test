using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace calc
{
    public sealed partial class MainPage : Page
    {
        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;
        private double memory = 0.0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Content.ToString().Trim();

            switch (pressed)
            {
                case "+":
                case "-":
                case "×":
                case "÷":
                    // 演算子が押された場合、前の演算子を新しいもので更新
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (!string.IsNullOrEmpty(operand1))
                        {
                            // すでに入力されている演算子で計算を行い、新しい演算子をセット
                            PerformCalculation();
                            operand1 = result.ToString();  // 結果を新たなオペランド1とする
                        }
                        else
                        {
                            operand1 = input;  // 入力をオペランド1とする
                        }

                        operation = pressed[0];
                        input = string.Empty;
                    }
                    break;
                case "=":
                    // 等号が押された場合、計算を実行
                    if (!string.IsNullOrEmpty(input))
                    {
                        PerformCalculation();
                        UpdateCalcResult(result);
                        operand1 = string.Empty;  // オペランドをクリア
                        input = result.ToString();  // 結果を新たな入力とする
                    }
                    operation = '\0';  // 演算子をクリア
                    break;
                case "C":
                    input = string.Empty;
                    calc_result.Text = "0";
                    break;
                case "AC":
                    ClearAll();
                    break;
                case "M+":
                case "M-":
                    // M+ と M- ボタン: メモリ加算または減算
                    if (!string.IsNullOrEmpty(input))
                    {
                        memory += (pressed == "M+") ? double.Parse(input) : -double.Parse(input);
                    }
                    else
                    {
                        memory += (pressed == "M+") ? result : -result;
                    }
                    break;
                case "MRC":
                    UpdateCalcResult(memory);
                    break;
                default:
                    HandleNumberInput(pressed);
                    break;
            }
        }

        // 計算を実行するメソッド
        private void PerformCalculation()
        {
            operand2 = input;
            double num1 = double.Parse(operand1);
            double num2 = double.Parse(operand2);

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '×':
                    result = num1 * num2;
                    break;
                case '÷':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        calc_result.Text = "Error";
                    break;
            }
        }

        // 全てをクリアするメソッド
        private void ClearAll()
        {
            input = operand1 = operand2 = string.Empty;
            calc_result.Text = "0";
            result = 0.0;
            memory = 0.0;
            operation = '\0';  // 演算子もクリア
        }

        private void HandleNumberInput(string pressed)
        {
            if (input == "0" || input.Length == 0)
            {
                if (pressed == "0" || pressed == "00")
                {
                    input = "0";
                }
                else
                {
                    input = pressed; // Reset input to non-zero number
                }
            }
            else
            {
                input += pressed; // Append the number
            }

            if (input.Length <= 20)
                calc_result.Text = input;
        }

        private void UpdateCalcResult(double result)
        {
            // 結果を文字列に変換し、表示
            string resultText = result.ToString();
            if (resultText.Length > 20)
                resultText = resultText.Substring(0, 20);
            calc_result.Text = resultText;
        }
    }
}
