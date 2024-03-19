using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2.Commands
{
    public class DecimalCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;


        public DecimalCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (!_window.resultBox.Text.Contains(","))
            {
                string text = _window.resultBox.Text += ",";
                _calcWindowService.showText(text, false);
            }
        }
    }
}
