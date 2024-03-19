using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static WpfCalculator_lab2.CalculatorWindowService;

namespace WpfCalculator_lab2.Commands
{
    public class TrigModeCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public TrigModeCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            List<TrigModes> modes = new List<TrigModes>()
            {
                TrigModes.STANDARD,
                TrigModes.ARC,
                TrigModes.HYPERBOLIC
            };

            Button button = (Button)parameter;
            _calcWindowService.currentTrigMode = modes.ElementAtOrDefault(modes.IndexOf(_calcWindowService.currentTrigMode) + 1);
            button.Content = _calcWindowService.trigModeSymbols[_calcWindowService.currentTrigMode];

            if (_calcWindowService.currentTrigMode == TrigModes.STANDARD)
            {
                _window.sin_button.Content = "sin";
                _window.cos_button.Content = "cos";
                _window.tan_button.Content = "tan";
            }

            if (_calcWindowService.currentTrigMode == TrigModes.HYPERBOLIC)
            {
                _window.sin_button.Content = "sinh";
                _window.cos_button.Content = "cosh";
                _window.tan_button.Content = "tanh";
            }

            if (_calcWindowService.currentTrigMode == TrigModes.ARC)
            {
                _window.sin_button.Content = "asin";
                _window.cos_button.Content = "acos";
                _window.tan_button.Content = "atan";
            }
        }
    }
}
