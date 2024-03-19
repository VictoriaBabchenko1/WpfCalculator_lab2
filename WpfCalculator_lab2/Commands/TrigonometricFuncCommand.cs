using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static WpfCalculator_lab2.CalculatorWindowService;

namespace WpfCalculator_lab2.Commands
{
    public class TrigonometricFuncCommand : ICommand
    {
        private readonly MainWindow _window;
        private CalculatorWindowService _calcWindowService;

        public TrigonometricFuncCommand(MainWindow window, CalculatorWindowService calculatorWindowService)
        {
            _window = window;
            _calcWindowService = calculatorWindowService;
        }

        public void Execute(object parameter)
        {
            if (_calcWindowService.errors.Contains(_window.resultBox.Text))
                return;

            Button button = (Button)parameter;
            string buttonText = button.Content.ToString();
            string equation = "";
            string result = "";
            double number = _calcWindowService.getNumber();

            switch (_calcWindowService.currentTrigMode)
            {
                // Standard trig functions
                case TrigModes.STANDARD:
                    double radianAngle = Angles.Converter.radians(number, _calcWindowService.angleUnit);
                    switch (buttonText)
                    {
                        case "sin":
                            equation = "sin(" + number.ToString() + ")";
                            result = Math.Sin(radianAngle).ToString();
                            break;

                        case "cos":
                            equation = "cos(" + number.ToString() + ")";
                            result = Math.Cos(radianAngle).ToString();
                            break;

                        case "tan":
                            equation = "tan(" + number.ToString() + ")";
                            result = Math.Tan(radianAngle).ToString();
                            break;
                    }
                    break;

                // Hyperbolic trig functions
                case TrigModes.HYPERBOLIC:
                    switch (buttonText)
                    {
                        case "sinh":
                            equation = "sinh(" + number + ")";
                            result = Math.Sinh(number).ToString();
                            break;

                        case "cosh":
                            equation = "cosh(" + number + ")";
                            result = Math.Cosh(number).ToString();
                            break;

                        case "tanh":
                            equation = "tanh(" + number + ")";
                            result = Math.Tanh(number).ToString();
                            break;
                    }
                    break;

                // Arc trig functions
                case TrigModes.ARC:
                    switch (buttonText)
                    {
                        case "asin":
                            equation = "asin(" + number + ")";
                            result = Math.Asin(number).ToString();
                            break;

                        case "acos":
                            equation = "acos(" + number + ")";
                            result = Math.Acos(number).ToString();
                            break;

                        case "atan":
                            equation = "atan(" + number + ")";
                            result = Math.Atan(number).ToString();
                            break;
                    }
                    break;
            }

            // We need to convert the result to the given angle unit if arc trig functions are used
            if (_calcWindowService.currentTrigMode == TrigModes.ARC)
            {
                switch (_calcWindowService.angleUnit)
                {
                    case Angles.Units.DEGREES:
                        result = Angles.Converter.degrees(double.Parse(result), Angles.Units.RADIANS).ToString();
                        break;
                    case Angles.Units.GRADIANS:
                        result = Angles.Converter.gradians(double.Parse(result), Angles.Units.RADIANS).ToString();
                        break;
                    default:  // 'result' is in radians by default
                        break;
                }
            }

            if (_calcWindowService.operationCheck)
            {
                equation = _window.equationBox.Text + equation;
                _calcWindowService.functionCheck = true;
            }

            _calcWindowService.updateEquationBox(equation);
            _calcWindowService.showText(result);
        }
    }

}
