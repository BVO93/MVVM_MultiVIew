using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Mulitview.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;


        public DelegateCommand(Action<Object> execute, Func<object, bool> canExecute = null) // canExecute is optional
        {
           
            _execute = execute;
            _canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged.Invoke(this, EventArgs.Empty);
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute is null ? true : _canExecute(parameter);

            // if null return true, else evaluate parameter.
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
