using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2
{
    interface ICommand
    {
        void Execute(object parameter);
    }
}
