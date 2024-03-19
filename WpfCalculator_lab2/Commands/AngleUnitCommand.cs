using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCalculator_lab2.Commands
{
    public class AngleUnitCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;


        public AngleUnitCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            List<Angles.Units> units = new List<Angles.Units>()
            {
                Angles.Units.RADIANS,
                Angles.Units.DEGREES,
                Angles.Units.GRADIANS
            };

            Button button = (Button)parameter;
            _calcWindowService.angleUnit = units.ElementAtOrDefault(units.IndexOf(_calcWindowService.angleUnit) + 1);
            button.Content = _calcWindowService.angleUnitSymbols[_calcWindowService.angleUnit];
        }
    }
}
