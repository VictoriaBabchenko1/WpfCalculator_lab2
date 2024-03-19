using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2.Commands
{
    public class PiCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;


        public PiCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (!_calcWindowService.operationCheck)
                _calcWindowService.updateEquationBox("");

            _calcWindowService.showText(Math.PI.ToString());
            _calcWindowService.isResult = true; // Constants cannot be changed
        }
    }
}
