using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2.Commands
{
    public class CE_Command : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public CE_Command(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.historyResultsList.Count > 0)
            {
                _calcWindowService.historyResultsList.RemoveAt(_calcWindowService.historyResultsList.Count - 1);
                if (_calcWindowService.historyResultsList.Count > 0)
                {
                    _calcWindowService.operationCheck = false;
                    _calcWindowService.previousText = null;
                    _calcWindowService.updateEquationBox("");
                    _calcWindowService.showText(_calcWindowService.historyResultsList[_calcWindowService.historyResultsList.Count - 1].ToString());
                }
                else
                {
                    _window.resultBox.Text = "0";
                    _calcWindowService.resetFontSize();
                }
            }
        }
    }
}
