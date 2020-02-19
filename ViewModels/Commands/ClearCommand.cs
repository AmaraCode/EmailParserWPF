using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmailParserWPF.ViewModels.Commands
{
    public class ClearCommand : ICommand
    {
        private Action _execute;
        public event EventHandler CanExecuteChanged;

        public ClearCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true; //temporary
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
