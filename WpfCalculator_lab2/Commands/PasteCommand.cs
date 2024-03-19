using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfCalculator_lab2.Commands
{
    public class PasteCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;


        public PasteCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            object clipboardData = Clipboard.GetData(DataFormats.UnicodeText);
            if (clipboardData != null)
            {
                string data = clipboardData.ToString();
                _calcWindowService.showText(data.ToString());
            }
            else
                return;
            Clipboard.SetData(DataFormats.UnicodeText, _window.resultBox.Text);
        }
    }
}
