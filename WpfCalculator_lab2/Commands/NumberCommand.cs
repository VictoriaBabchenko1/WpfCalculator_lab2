using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCalculator_lab2.Commands
{
    public class NumberCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public NumberCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            Button button = (Button)parameter;
            string buttonText = button.Content.ToString();

            if (_window.resultBox.Text == "0" || _calcWindowService.errors.Contains(_window.resultBox.Text))
                _window.resultBox.Clear();

            string text = _calcWindowService.clearNext ? buttonText : _window.resultBox.Text + buttonText;

            if (!_calcWindowService.operationCheck && _window.equationBox.Text != "")
                _calcWindowService.updateEquationBox("");

            _calcWindowService.showText(text, false);
        }
    }
}
