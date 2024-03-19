using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCalculator_lab2.Commands;

namespace WpfCalculator_lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICommand _numberCommand;
        private ICommand _clearCommand;
        private ICommand _ceCommand;
        private ICommand _decimalCommand;
        private ICommand _doubleOperandFunctionCommand;
        private ICommand _functionCommand;
        private ICommand _trigonometricFuncCommand;
        private ICommand _trigModeCommand;
        private ICommand _angleUnitCommand;
        private ICommand _piCommand;
        private ICommand _eCommand;
        private ICommand _copyCommand;
        private ICommand _pasteCommand;
        private ICommand _backCommand;
        private ICommand _extendFunctionsCommand;
        private CalculatorWindowService _calculatorWindowService;

        public MainWindow()
        {
            InitializeComponent();
            _calculatorWindowService = new CalculatorWindowService(this);

            _numberCommand = new NumberCommand(this, _calculatorWindowService);
            _clearCommand = new ClearCommand(this, _calculatorWindowService);
            _ceCommand = new CE_Command(this, _calculatorWindowService);
            _ceCommand = new CE_Command(this, _calculatorWindowService);
            _decimalCommand = new DecimalCommand(this, _calculatorWindowService);
            _doubleOperandFunctionCommand = new DoubleOperandFunctionCommand(this, _calculatorWindowService);
            _functionCommand = new FunctionCommand(this, _calculatorWindowService);
            _trigonometricFuncCommand = new TrigonometricFuncCommand(this, _calculatorWindowService);
            _trigModeCommand = new TrigModeCommand(this, _calculatorWindowService);
            _angleUnitCommand = new AngleUnitCommand(this, _calculatorWindowService);
            _piCommand = new PiCommand(this, _calculatorWindowService);
            _eCommand = new ECommand(this, _calculatorWindowService);
            _copyCommand = new CopyCommand(this, _calculatorWindowService);
            _pasteCommand = new PasteCommand(this, _calculatorWindowService);
            _backCommand = new BackCommand(this, _calculatorWindowService);
            _extendFunctionsCommand = new ExtendFunctionsCommand(this, _calculatorWindowService);
        }

        private void numberClick(object sender, RoutedEventArgs e)
        {
            _numberCommand.Execute(sender);
        }

        private void angle_unit_button_Click(object sender, RoutedEventArgs e)
        {
            _angleUnitCommand.Execute(sender);
        }

        private void trig_mode_button_Click(object sender, RoutedEventArgs e)
        {
            _trigModeCommand.Execute(sender);
        }

        private void function(object sender, RoutedEventArgs e)
        {
            _functionCommand.Execute(sender);
        }

        private void trigFunction(object sender, RoutedEventArgs e)
        {
            _trigonometricFuncCommand.Execute(sender);
        }

        private void doubleOperandFunction(object sender, RoutedEventArgs e)
        {
            _doubleOperandFunctionCommand.Execute(sender);
        }

        private void decimal_button_Click(object sender, RoutedEventArgs e)
        {
            _decimalCommand.Execute(sender);
        }

        private void pi_button_Click(object sender, RoutedEventArgs e)
        {
            _piCommand.Execute(sender);
        }

        private void e_button_Click(object sender, RoutedEventArgs e)
        {
            _eCommand.Execute(sender);
        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            _clearCommand.Execute(null);
        }

        private void ce_previous_button_Click(object sender, RoutedEventArgs e)
        {
            _ceCommand.Execute(null);
        }

        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            _calculatorWindowService.calculateResult();
        }

        private void copy_button_Click(object sender, RoutedEventArgs e)
        {
            _copyCommand.Execute(sender);
        }

        private void paste_button_Click(object sender, RoutedEventArgs e)
        {
            _pasteCommand.Execute(sender);
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            _backCommand.Execute(sender);
        }

        private void extend_functions_button_Click(object sender, RoutedEventArgs e)
        {
            _extendFunctionsCommand.Execute(sender);
        }
    }
}
