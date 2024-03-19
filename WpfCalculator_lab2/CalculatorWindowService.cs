using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCalculator_lab2
{
    public class CalculatorWindowService
    {
        private readonly MainWindow _window;

        private const int defaultFontSize = 60;
        // True if there is an on going math operation
        public bool operationCheck;
        // True if a function (sin, tan, ln, log etc) was called on the number during another mathematical operation
        public bool functionCheck;
        // True if the result box is to be cleared when a number is entered
        public bool clearNext;
        // True if the text in the result box is the result of some computation
        public bool isResult;
        // True if the text in the result box has not been changed after clicking an operator
        public bool isOldText;
        public string previousText;

        public enum TrigModes
        {
            STANDARD,  // Default mode
            HYPERBOLIC,
            ARC
        }
        public TrigModes currentTrigMode;
        public Dictionary<TrigModes, string> trigModeSymbols = new Dictionary<TrigModes, string>()
        {
            { TrigModes.STANDARD, "STD" },
            { TrigModes.ARC, "ARC" },
            { TrigModes.HYPERBOLIC, "HYP" }
        };

        public Angles.Units angleUnit;
        public Dictionary<Angles.Units, string> angleUnitSymbols = new Dictionary<Angles.Units, string>()
        {
            { Angles.Units.RADIANS, "RAD" }, // Default
            { Angles.Units.DEGREES, "DEG" },
            { Angles.Units.GRADIANS, "GRAD" }
        };

        public static string OVERFLOW = "Overflow";
        public static string INVALID_INPUT = "Invalid input";
        public static string NOT_A_NUMBER = "NaN";
        public string[] errors = { OVERFLOW, INVALID_INPUT, NOT_A_NUMBER };

        public Operations currentOperation = Operations.NULL;
        public List<double> historyResultsList = new List<double>();
        public enum Operations
        {
            ADDITION,
            SUBTRACTION,
            DIVISION,
            MULTIPLICATION,
            POWER,
            NULL // Represents no operation (used to reset the status)
        }

        public List<Button> extendFunctionsButtons;

        public CalculatorWindowService(MainWindow window)
        {
            _window = window;
            _window.angle_unit_button.Content = angleUnitSymbols[angleUnit];
            _window.trig_mode_button.Content = trigModeSymbols[currentTrigMode];

            extendFunctionsButtons = new List<Button>()
            {
                _window.angle_unit_button,
                _window.trig_mode_button,
                _window.fact_button,
                _window.power_button,
                _window.sqrt_button,
                _window.pi_button,
                _window.e_button,
                _window.sin_button,
                _window.cos_button,
                _window.tan_button,
                _window.nlog_button,
                _window.log_button
            };
        }

        public void showText(string text, bool clear = true)
        {
            try
            {
                if (double.Parse(text) == 0) { }
            }
            catch (Exception)
            {
                showError(INVALID_INPUT);
                return;
            }

            if (text.Length > 30)
                return;
            if (text.Length > 12)
                _window.resultBox.FontSize = 35;
            if (text.Length > 24)
                _window.resultBox.FontSize = 30;

            clearNext = clear;
            _window.resultBox.Text = text;
        }

        public void showError(string text)
        {
            _window.resultBox.Text = text;
            previousText = null;
            operationCheck = false;
            clearNext = true;
            updateEquationBox("");
            currentOperation = Operations.NULL;
            resetFontSize();
        }

        public void updateEquationBox(string equation, bool append = false)
        {
            if (equation.Length > 15)
                _window.equationBox.FontSize = 30;

            if (!append)
                _window.equationBox.Text = equation;
            else
                _window.equationBox.Text += equation;
        }

        public double getNumber()
        {
            double number = double.Parse(_window.resultBox.Text);
            return number;
        }

        public void resetFontSize()
        {
            _window.resultBox.FontSize = defaultFontSize;
        }

        public void calculateResult()
        {
            if (currentOperation == Operations.NULL)
                return;

            double a = double.Parse(previousText);  // first operand
            double b = double.Parse(_window.resultBox.Text); // second operand
            double result;

            switch (currentOperation)
            {
                case Operations.DIVISION:
                    result = a / b;
                    break;
                case Operations.MULTIPLICATION:
                    result = a * b;
                    break;
                case Operations.ADDITION:
                    result = a + b;
                    break;
                case Operations.SUBTRACTION:
                    result = a - b;
                    break;
                case Operations.POWER:
                    result = Math.Pow(a, b);
                    break;
                default:
                    return;
            }

            if (errors.Contains(_window.resultBox.Text))
                return;

            operationCheck = false;
            previousText = null;
            string equation;

            if (!functionCheck)
                equation = _window.equationBox.Text + b.ToString();
            else
            {
                equation = _window.equationBox.Text;
                functionCheck = false;
            }

            updateEquationBox(equation);
            historyResultsList.Add(result);
            showText(result.ToString());
            currentOperation = Operations.NULL;
            isResult = true;
        }
    }
}
