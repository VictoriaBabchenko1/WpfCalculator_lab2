using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static WpfCalculator_lab2.CalculatorWindowService;

namespace WpfCalculator_lab2.Commands
{
    public class DoubleOperandFunctionCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public DoubleOperandFunctionCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.errors.Contains(_window.resultBox.Text))
                return;

            if (_calcWindowService.operationCheck && !_calcWindowService.isOldText)
                _calcWindowService.calculateResult();

            Button button = (Button)parameter;

            _calcWindowService.operationCheck = true;
            _calcWindowService.previousText = _window.resultBox.Text;
            string buttonText = button.Content.ToString();
            string equation = _calcWindowService.previousText + " " + buttonText + " ";
            switch (buttonText)
            {
                case "/":
                    _calcWindowService.currentOperation = Operations.DIVISION;
                    break;
                case "x":
                    _calcWindowService.currentOperation = Operations.MULTIPLICATION;
                    break;
                case "-":
                    _calcWindowService.currentOperation = Operations.SUBTRACTION;
                    break;
                case "+":
                    _calcWindowService.currentOperation = Operations.ADDITION;
                    break;
                case "^":
                    _calcWindowService.currentOperation = Operations.POWER;
                    break;
            }
            _calcWindowService.updateEquationBox(equation);
            _calcWindowService.resetFontSize();
            _calcWindowService.showText(_window.resultBox.Text);
            _calcWindowService.isOldText = true;
        }
    }
}
