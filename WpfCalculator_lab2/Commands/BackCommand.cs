using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2.Commands
{
    public class BackCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public BackCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.isResult)
                return;

            string text;

            if (_window.resultBox.Text.Length == 1)
                text = "0";
            else
                text = _window.resultBox.Text.Substring(0, _window.resultBox.Text.Length - 1);

            _calcWindowService.showText(text, false);
        }
    }
}
