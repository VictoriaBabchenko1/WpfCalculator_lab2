using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2.Commands
{
    public class ClearCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public ClearCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            _window.resultBox.Text = "0";
            _calcWindowService.operationCheck = false;
            _calcWindowService.previousText = null;
            _calcWindowService.updateEquationBox("");
            _calcWindowService.resetFontSize();
        }
    }
}
