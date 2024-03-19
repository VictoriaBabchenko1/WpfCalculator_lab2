using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static WpfCalculator_lab2.CalculatorWindowService;


namespace WpfCalculator_lab2.Commands
{
    public class FunctionCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public FunctionCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.errors.Contains(_window.resultBox.Text))
                return;

            Button button = (Button)parameter;
            string buttonText = button.Content.ToString();
            double number = _calcWindowService.getNumber();
            string equation = "";
            string result = "";

            switch (buttonText)
            {
                case "!":
                    if (number < 0 || number.ToString().Contains(","))
                    {
                        _calcWindowService.showError(INVALID_INPUT);
                        return;
                    }

                    if (number > 3248)
                    {
                        _calcWindowService.showError(OVERFLOW);
                        return;
                    }
                    double res = 1;
                    if (number == 1 || number == 0)
                        result = res.ToString();
                    else
                    {
                        for (int i = 2; i <= number; i++)
                        {
                            res *= i;
                        }
                    }
                    equation = "fact(" + number.ToString() + ")";
                    result = res.ToString();
                    break;

                case "ln":
                    equation = "ln(" + number + ")";
                    result = Math.Log(number).ToString();
                    break;

                case "log":
                    equation = "log(" + number + ")";
                    result = Math.Log10(number).ToString();
                    break;

                case "√":
                    equation = "√(" + number + ")";
                    result = Math.Sqrt(number).ToString();
                    break;

                case "-n":
                    equation = "negative(" + number + ")";
                    result = decimal.Negate((decimal)number).ToString();
                    break;

                case "%":
                    equation = (number / 100).ToString();
                    result = (number / 100).ToString();
                    break;
            }

            if (_calcWindowService.operationCheck)
            {
                equation = _window.equationBox.Text + equation;
                _calcWindowService.functionCheck = true;
            }

            _calcWindowService.updateEquationBox(equation);
            _calcWindowService.showText(result);
        }
    }
}
