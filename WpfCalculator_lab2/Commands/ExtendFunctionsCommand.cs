using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCalculator_lab2.Commands
{
    public class ExtendFunctionsCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public ExtendFunctionsCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_window.extend_functions_button.Content != ">")
            {
                ColumnDefinition newColumn = new ColumnDefinition();
                newColumn.Width = new GridLength(1, GridUnitType.Star);
                _window.CalculatorGrid.ColumnDefinitions.Add(newColumn);

                ColumnDefinition newColumn2 = new ColumnDefinition();
                newColumn2.Width = new GridLength(1, GridUnitType.Star);
                _window.CalculatorGrid.ColumnDefinitions.Add(newColumn2);

                foreach (Button button in _calcWindowService.extendFunctionsButtons)
                {
                    button.Visibility = Visibility.Visible;
                }

                _window.extend_functions_button.Content = ">";
            }
            else
            {
                _window.CalculatorGrid.ColumnDefinitions.RemoveAt(5);
                _window.CalculatorGrid.ColumnDefinitions.RemoveAt(4);

                foreach (Button button in _calcWindowService.extendFunctionsButtons)
                {
                    button.Visibility = Visibility.Collapsed;
                }

                _window.extend_functions_button.Content = "≡";
            }
        }
    }
}
