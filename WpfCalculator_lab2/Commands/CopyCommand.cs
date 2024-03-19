using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCalculator_lab2.Commands
{
    public class CopyCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;


        public CopyCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.errors.Contains(_window.resultBox.Text))
                return;

            Clipboard.SetData(DataFormats.UnicodeText, _window.resultBox.Text);
        }
    }
}
